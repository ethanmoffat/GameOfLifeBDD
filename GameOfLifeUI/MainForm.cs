using System;
using System.Collections.Generic;
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

      private Thread _worker;
      private CancellationTokenSource _ctSource;

      private readonly IWorldController _worldController;
      private readonly ISimulationController _simulationController;
      private readonly IWorldProvider _worldProvider;
      private readonly ISimulationStateProvider _simulationStateProvider;

      private volatile int _simSpeedDelay = 300;

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
         GenerationList.Format += GenerationList_Format;
         Disposed += MainForm_Disposed;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Text = TITLE_TEXT;
         SetInitialState();
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_simulationStateProvider.CurrentState == SimulationState.Running)
         {
            _ctSource.Cancel();
            _worker.Join();
         }
      }

      private void MainForm_Disposed(object sender, EventArgs e)
      {
         if (_ctSource != null)
            _ctSource.Dispose();
      }

      private void WorldGrid_GridCellClicked(object sender, GridClickedEventArgs e)
      {
         var wp = new WorldPoint(e.Location.X, e.Location.Y);
         if (e.Cell.Activated)
            _worldController.SetWorldCellState(new[] {wp}, new List<WorldPoint>());
         else
            _worldController.SetWorldCellState(new List<WorldPoint>(), new[] {wp});
      }

      private void GenerationList_Format(object sender, ListControlConvertEventArgs e)
      {
         e.Value = string.Format("{0}: {1} Live cells",
            GenerationList.Items.Count,
            ((World)e.ListItem).Cells.Count(x => x.IsAlive));
      }

      private void GoButton_Click(object sender, EventArgs e)
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

      private void SimulationSpeed_Scroll(object sender, EventArgs e)
      {
         SimulationSpeedLabel.Text = string.Format("{0} ms", SimulationSpeed.Value);
         _simSpeedDelay = SimulationSpeed.Value;
      }

      private void NextState()
      {
         var st = _simulationStateProvider.CurrentState;

         RunButton.Enabled = st == SimulationState.Initial;

         PauseButton.Enabled = st == SimulationState.Running;
         PauseButton.Visible = st != SimulationState.Paused;

         ResumeButton.Enabled = st == SimulationState.Paused;
         ResumeButton.Visible = st == SimulationState.Paused;

         ResetButton.Enabled = st == SimulationState.Paused;

         GenerationList.Enabled = st != SimulationState.Running;

         switch (st)
         {
            case SimulationState.Initial: SetInitialState(); break;
            case SimulationState.Running: SetRunningState(); break;
            case SimulationState.Paused: SetPausedState(); break;
            default: throw new ArgumentOutOfRangeException();
         }
      }

      private void SetInitialState()
      {
         _worldController.CreateDefaultWorld();
         WorldGrid.ResetAllCells();
         WorldGrid.UnlockAllCells();
         GenerationList.Items.Clear();
      }

      private void SetRunningState()
      {
         WorldGrid.LockAllCells();

         if (_ctSource != null)
            _ctSource.Dispose();
         _ctSource = new CancellationTokenSource();

         _worker = new Thread(_doWork);
         _worker.Start(_ctSource.Token);
      }

      private void SetPausedState()
      {
         _ctSource.Cancel();
         WorldGrid.UnlockAllCells();
      }

      private void _doWork(object param)
      {
         var ct = (CancellationToken) param;
         while (!ct.IsCancellationRequested)
         {
            _worldController.CalculateNextGeneration();
            UpdateGridFromWorld(_worldProvider.CurrentWorld);
            GenerationList.Invoke(new Action(UpdatePastGenerationsList));

            if (_worldProvider.CurrentWorld.Cells.All(x => !x.IsAlive) &&
                _worldProvider.PreviousGenerations.Last().Cells.All(x => !x.IsAlive))
            {
               _simulationController.PauseSimulation();
               Invoke(new Action(NextState));
               break;
            }

            Thread.Sleep(_simSpeedDelay);
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

      private void UpdatePastGenerationsList()
      {
         GenerationList.SuspendLayout();
         GenerationList.Items.Add(_worldProvider.PreviousGenerations.Last());
         GenerationList.SelectedItem = _worldProvider.PreviousGenerations.Last();
         GenerationList.ResumeLayout();
      }

      private bool IsInDisplayGridBounds(Cell cell)
      {
         return cell.Y >= WorldGrid.GridBounds.Y && cell.Y <= WorldGrid.GridBounds.Height && cell.X >= WorldGrid.GridBounds.X && cell.X <= WorldGrid.GridBounds.Width;
      }

      private void GenerationList_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_simulationStateProvider.CurrentState != SimulationState.Paused) return;

         if (GenerationList.SelectedItem == _worldProvider.PreviousGenerations.Last())
            WorldGrid.UnlockAllCells();
         else
            WorldGrid.LockAllCells();

         UpdateGridFromWorld(GenerationList.SelectedItem as World);
      }
   }
}
