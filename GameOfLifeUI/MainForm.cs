using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GameOfLife;
using GameOfLife.Controllers;
using GameOfLife.Services;

namespace GameOfLifeUI
{
   public partial class MainForm : Form
   {
      public const string TITLE_TEXT = "Game of Life Simulation";

      private const string FILENAME_WORLD = "seed.gol";
      private const string FILENAME_SESSION = "session.gols";
      private const string FILTER_WORLD = "Game of Life Seed Files|*.gol|All Files|*.*";
      private const string FILTER_SESSION = "Game of Life Session Files|*.gols|All Files|*.*";

      private Thread _worker;
      private CancellationTokenSource _ctSource;

      private readonly IWorldController _worldController;
      private readonly ISimulationController _simulationController;
      private readonly IWorldProvider _worldProvider;
      private readonly ISimulationStateProvider _simulationStateProvider;

      private FormWindowState _windowState;

      public MainForm(IWorldController worldController,
                      ISimulationController simulationController,
                      IWorldProvider worldProvider,
                      ISimulationStateProvider simulationStateProvider)
      {
         _worldController = worldController;
         _simulationController = simulationController;
         _worldProvider = worldProvider;
         _simulationStateProvider = simulationStateProvider;

         InitializeComponent();

         WorldGrid.GridCellClicked += WorldGrid_GridCellClicked;
         WorldGrid.GridCellMouseOver += WorldGrid_GridCellMouseOver;
         GenerationList.Format += GenerationList_Format;
         Disposed += MainForm_Disposed;
      }


      #region Form Events

      private void MainForm_Load(object sender, EventArgs e)
      {
         Text = TITLE_TEXT;
         _windowState = WindowState;
         SetInitialState();
      }

      protected override void OnResize(EventArgs e)
      {
         //hack that allows the grid to be resized on the maximize event
         //Calls OnResizeEnd when Maximize happens (which triggers event in grid)
         if (_windowState != WindowState)
         {
            _windowState = WindowState;
            if (_windowState == FormWindowState.Maximized)
            {
               base.OnResize(e);
               OnResizeEnd(e);
            }
         }

         base.OnResize(e);
      }

      protected override void OnResizeEnd(EventArgs e)
      {
         base.OnResizeEnd(e); //call grid's resize first or we get a deadlock

         //update grid from world after resize
         if (_simulationStateProvider.CurrentState != SimulationState.Running)
            UpdateGridFromWorld(_worldProvider.CurrentWorld);
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_simulationStateProvider.CurrentState == SimulationState.Running)
         {
            var result = MessageBox.Show("Exit while simulation is running?",
                                         "Exit Confirmation",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               _ctSource.Cancel();
               _worker.Join();
            }
            else
               e.Cancel = true;
         }
      }

      private void MainForm_Disposed(object sender, EventArgs e)
      {
         if (_ctSource != null)
            _ctSource.Dispose();
      }

      #endregion

      #region Form Menu Events

      private void OpenMenuItem_Click(object sender, EventArgs e)
      {
         OpenFile.FileName = FILENAME_WORLD;
         OpenFile.Filter = FILTER_WORLD;

         var result = OpenFile.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            World w;
            try
            {
               w = WorldSerialize.DeserializeWorldFromString(File.ReadAllText(OpenFile.FileName));
            }
            catch(Exception ex)
            {
               ShowExceptionDialogIO(ex, "read");
               return;
            }

            _worldController.ResetWorldCells();
            _worldController.SetWorldCellState(w.Cells.Select(cell => new WorldPoint(cell.X, cell.Y)), new List<WorldPoint>());
            UpdateGridFromWorld(_worldProvider.CurrentWorld);
         }
      }

      private void SaveMenuItem_Click(object sender, EventArgs e)
      {
         SaveFile.FileName = FILENAME_WORLD;
         SaveFile.Filter = FILTER_WORLD;

         var worldToSave = GenerationList.SelectedItem ?? _worldProvider.CurrentWorld;
         var result = SaveFile.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            try
            {
               var text = WorldSerialize.SerializeWorldToString(worldToSave);
               File.WriteAllText(SaveFile.FileName, text);
            }
            catch (Exception ex)
            {
               ShowExceptionDialogIO(ex, "write");
            }
         }
      }

      private void OpenSessionMenuItem_Click(object sender, EventArgs e)
      {
         OpenFile.FileName = FILENAME_SESSION;
         OpenFile.Filter = FILTER_SESSION;

         var result = OpenFile.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            try
            {
               using (var tr = new StreamReader(OpenFile.FileName))
               {
                  if (tr.ReadLine() != "[Speed]")
                     throw new Exception("Bad file format");
                  int simSpeedDelay = Convert.ToInt32(tr.ReadLine());
                  if (tr.ReadLine() != "[CurrentWorld]")
                     throw new Exception("Bad file format");
                  var currentWorld = WorldSerialize.DeserializeWorldFromString(tr.ReadLine());
                  if (tr.ReadLine() != "[PastGenerations]")
                     throw new Exception("Bad file format");
                  var generations = new List<World>();
                  while (!tr.EndOfStream)
                     generations.Add(WorldSerialize.DeserializeWorldFromString(tr.ReadLine()));

                  _simulationController.SetSimulationDelay(simSpeedDelay);
                  _worldController.ResetWorldCells();
                  _worldController.SetWorldCellState(currentWorld.Cells.Select(cell => new WorldPoint(cell.X, cell.Y)), new List<WorldPoint>());
                  _worldController.SetGenerations(generations);
               }
            }
            catch (Exception ex)
            {
               ShowExceptionDialogIO(ex, "read");
               return;
            }

            SimulationSpeed.Value = _simulationStateProvider.SimulationDelay;
            UpdateSimulationSpeedLabelFromValue();
            UpdateGridFromWorld(_worldProvider.CurrentWorld);
            RefreshGenerationListFromCache();
         }
      }

      private void SaveSessionMenuItem_Click(object sender, EventArgs e)
      {
         SaveFile.FileName = FILENAME_SESSION;
         SaveFile.Filter = FILTER_SESSION;

         var result = SaveFile.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            var fullText = "[Speed]\n";
            fullText += _simulationStateProvider.SimulationDelay + "\n";
            fullText += "[CurrentWorld]\n";
            fullText += WorldSerialize.SerializeWorldToString(_worldProvider.CurrentWorld) + "\n";
            fullText += "[PastGenerations]\n";
            fullText = _worldProvider.PreviousGenerations.Aggregate(fullText, (current, world) => current + (WorldSerialize.SerializeWorldToString(world) + "\n"));

            try
            {
               File.WriteAllText(SaveFile.FileName, fullText);
            }
            catch (Exception ex)
            {
               ShowExceptionDialogIO(ex, "write");
            }
         }
      }

      private void ExitMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void GosperGliderPatternMenuItem_Click(object sender, EventArgs e)
      {
         _worldController.ResetWorldCells();
         _worldController.SetWorldCellState(CommonSeedPatterns.GosperGliderGun, new List<WorldPoint>());
         UpdateGridFromWorld(_worldProvider.CurrentWorld);
      }

      private void RandomPatternMenuItem_Click(object sender, EventArgs e)
      {
         var randomPattern = CommonSeedPatterns.GetRandomPattern(WorldGrid.GridBounds.Height, WorldGrid.GridBounds.Width);
         _worldController.ResetWorldCells();
         _worldController.SetWorldCellState(randomPattern, new List<WorldPoint>());
         UpdateGridFromWorld(_worldProvider.CurrentWorld);
      }

      private void ClearWorldMenuItem_Click(object sender, EventArgs e)
      {
         _worldController.ResetWorldCells();
         UpdateGridFromWorld(_worldProvider.CurrentWorld);
      }

      private void SimulateFutureMenuItem_Click(object sender, EventArgs e)
      {
         //todo: need to track progress of calculation somehow. New form required.
      }

      private void ResetToGenerationMenuItem_Click(object sender, EventArgs e)
      {
         var selectedNdx = GenerationList.SelectedIndex;
         var newGenerations = _worldProvider.PreviousGenerations.ToList();
         newGenerations.RemoveRange(selectedNdx + 1, newGenerations.Count - selectedNdx - 1);
         _worldController.SetGenerations(newGenerations);
         RefreshGenerationListFromCache();
      }

      private void AboutMenuItem_Click(object sender, EventArgs e)
      {
         //todo: need to create about box. New form probably required (might be able to get away with message box)
      }

      #endregion

      #region Grid Events

      private void WorldGrid_GridCellClicked(object sender, GridClickedEventArgs e)
      {
         var wp = new WorldPoint(e.Location.X, e.Location.Y);
         if (e.Cell.Activated)
            _worldController.SetWorldCellState(new[] {wp}, new List<WorldPoint>());
         else
            _worldController.SetWorldCellState(new List<WorldPoint>(), new[] {wp});
      }

      private void WorldGrid_GridCellMouseOver(object sender, EventArgs e)
      {
         var cell = sender as WorldGridCell;
         MouseOverCellLabel.Text = cell == null || !cell.Enabled ? "" : string.Format("{0}x{1}", cell.Row, cell.Column);
      }

      #endregion

      #region Button Events

      private void RunButton_Click(object sender, EventArgs e)
      {
         _simulationController.RunSimulation();
         NextState();
      }

      private void PauseButton_Click(object sender, EventArgs e)
      {
         _simulationController.PauseSimulation();
         NextState();
      }

      private void ResumeButton_Click(object sender, EventArgs e)
      {
         _simulationController.ResumeSimulation();
         NextState();
      }

      private void ResetButton_Click(object sender, EventArgs e)
      {
         _simulationController.ResetSimulation();
         NextState();
      }

      #endregion

      #region Other Control Events

      private void GenerationList_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_simulationStateProvider.CurrentState != SimulationState.Paused) return;

         if (GenerationList.SelectedItem == _worldProvider.PreviousGenerations.Last())
            WorldGrid.UnlockAllCells();
         else
            WorldGrid.LockAllCells();

         UpdateGridFromWorld(GenerationList.SelectedItem);
      }

      private void GenerationList_Format(object sender, ListControlConvertEventArgs e)
      {
         e.Value = string.Format("{0}: {1} Live cells",
            GenerationList.Items.Count,
            ((World)e.ListItem).Cells.Count(x => x.IsAlive));
      }

      private void SimulationSpeed_Scroll(object sender, EventArgs e)
      {
         _simulationController.SetSimulationDelay(SimulationSpeed.Value);
         UpdateSimulationSpeedLabelFromValue();
      }

      #endregion

      #region State Transitions

      private void NextState()
      {
         var st = _simulationStateProvider.CurrentState;

         UpdateButtonState(st);
         UpdateMenuItemState(st);

         switch (st)
         {
            case SimulationState.Initial: SetInitialState(); break;
            case SimulationState.Running: SetRunningState(); break;
            case SimulationState.Paused: SetPausedState(); break;
            default: throw new ArgumentOutOfRangeException();
         }
      }

      private void UpdateButtonState(SimulationState st)
      {
         RunButton.Enabled = st == SimulationState.Initial;

         PauseButton.Enabled = st == SimulationState.Running;
         PauseButton.Visible = st != SimulationState.Paused;

         ResumeButton.Enabled = st == SimulationState.Paused;
         ResumeButton.Visible = st == SimulationState.Paused;

         ResetButton.Enabled = st == SimulationState.Paused;

         GenerationList.Enabled = st != SimulationState.Running;
      }

      private void UpdateMenuItemState(SimulationState st)
      {
         OpenMenuItem.Enabled = st != SimulationState.Running;
         SaveMenuItem.Enabled = st != SimulationState.Running;

         SeedWithPatternMenuItem.Enabled = st != SimulationState.Running;
         foreach (var item in SeedWithPatternMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
            item.Enabled = SeedWithPatternMenuItem.Enabled;
         ClearWorldMenuItem.Enabled = st != SimulationState.Running;

         SimulateFutureMenuItem.Enabled = st == SimulationState.Initial;
         ResetToGenerationMenuItem.Enabled = st == SimulationState.Paused;
      }

      private void SetInitialState()
      {
         _worldController.CreateDefaultWorld();

         WorldGrid.ResetAllCells();
         WorldGrid.UnlockAllCells();

         GenerationList.Items.Clear();

         UpdateMenuItemState(SimulationState.Initial);
      }

      private void SetRunningState()
      {
         WorldGrid.LockAllCells();

         if (_ctSource != null)
            _ctSource.Dispose();
         _ctSource = new CancellationTokenSource();

         _worker = new Thread(RunSimulation_ThreadProc);
         _worker.Start(_ctSource.Token);
      }

      private void SetPausedState()
      {
         _ctSource.Cancel();
         WorldGrid.UnlockAllCells();
      }

      #endregion

      #region Helper Methods

      private void RunSimulation_ThreadProc(object param)
      {
         var ct = (CancellationToken) param;
         while (!ct.IsCancellationRequested)
         {
            _worldController.CalculateNextGeneration();
            UpdateGridFromWorld(_worldProvider.CurrentWorld);
            GenerationList.Invoke(new Action(AddLatestGenerationToGenerationsList));

            if (_worldProvider.CurrentWorld.Cells.All(x => !x.IsAlive) &&
                _worldProvider.PreviousGenerations.Last().Cells.All(x => !x.IsAlive))
            {
               _simulationController.PauseSimulation();
               Invoke(new Action(NextState));
               break;
            }

            Thread.Sleep(_simulationStateProvider.SimulationDelay);
         }
      }

      private void UpdateGridFromWorld(World world)
      {
         if (world == null) return;

         WorldGrid.ResetAllCells();

         foreach (var cell in world.Cells)
            if (IsInDisplayGridBounds(cell) && cell.IsAlive)
               WorldGrid[cell.Y, cell.X].ToggleActivate();
      }

      private void AddLatestGenerationToGenerationsList()
      {
         GenerationList.SuspendLayout();
         GenerationList.Items.Add(_worldProvider.PreviousGenerations.Last());
         GenerationList.SelectedItem = _worldProvider.PreviousGenerations.Last();
         GenerationList.ResumeLayout();
      }

      private void RefreshGenerationListFromCache()
      {
         GenerationList.SuspendLayout();
         GenerationList.Items.Clear();
         GenerationList.Items.AddRange(_worldProvider.PreviousGenerations.OfType<object>().ToArray());
         GenerationList.SelectedIndex = GenerationList.Items.Count - 1;
         GenerationList.ResumeLayout();
      }

      private void UpdateSimulationSpeedLabelFromValue()
      {
         SimulationSpeedLabel.Text = string.Format("{0} ms", _simulationStateProvider.SimulationDelay);
      }

      private bool IsInDisplayGridBounds(Cell cell)
      {
         return cell.Y >= WorldGrid.GridBounds.Y && cell.Y <= WorldGrid.GridBounds.Height && cell.X >= WorldGrid.GridBounds.X && cell.X <= WorldGrid.GridBounds.Width;
      }

      private static void ShowExceptionDialogIO(Exception ex, string type)
      {
         MessageBox.Show(string.Format("Unable to {1} the specified file: \n\n\"{0}\"", ex.Message, type),
            "Error opening file",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
      }

      #endregion
   }
}
