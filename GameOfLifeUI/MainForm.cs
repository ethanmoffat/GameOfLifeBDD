using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GameOfLife;
using GameOfLife.Actions;
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

      private void WorldGrid_GridCellClicked(object sender, GridClickedEventArgs e)
      {
         var wp = new WorldPoint(e.Location.X, e.Location.Y);
         if (e.Cell.Activated)
            _worldController.SetWorldCellState(new[] {wp}, new List<WorldPoint>());
         else
            _worldController.SetWorldCellState(new List<WorldPoint>(), new[] {wp});
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

      private void NextState()
      {
         switch (_simulationStateProvider.CurrentState)
         {
            case SimulationState.Initial:
               RunButton.Enabled = true;
               PauseButton.Enabled = false;
               PauseButton.Visible = true;
               ResumeButton.Enabled = false;
               ResumeButton.Visible = false;
               ResetButton.Enabled = false;
               SetInitialState();
               break;
            case SimulationState.Running:
               RunButton.Enabled = false;
               PauseButton.Enabled = true;
               PauseButton.Visible = true;
               ResumeButton.Enabled = false;
               ResumeButton.Visible = false;
               ResetButton.Enabled = false;
               SetRunningState();
               break;
            case SimulationState.Paused:
               RunButton.Enabled = false;
               PauseButton.Enabled = false;
               PauseButton.Visible = false;
               ResumeButton.Enabled = true;
               ResumeButton.Visible = true;
               ResetButton.Enabled = true;
               SetPausedState();
               break;
            default:
               throw new ArgumentOutOfRangeException();
         }
      }

      private void SetInitialState()
      {
         _worldController.CreateDefaultWorld();
         WorldGrid.ResetAllCells();
      }

      private void SetRunningState()
      {
         WorldGrid.LockAllCells();
         _worker = new Thread(_doWork);
         _ctSource = new CancellationTokenSource();
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
            UpdateGridFromWorld();

            //stop running if no live cells...
            //if (_worldProvider.CurrentWorld.Cells.All(x => !x.IsAlive))
            //   break;

            Thread.Sleep(300);
         }
      }

      private void UpdateGridFromWorld()
      {
         foreach (var cell in _worldProvider.CurrentWorld.Cells)
            if (IsInDisplayGridBounds(cell) &&
                cell.IsAlive != WorldGrid[cell.Y, cell.X].Activated)
               WorldGrid[cell.Y, cell.X].ToggleActivate();
      }

      private bool IsInDisplayGridBounds(Cell cell)
      {
         return cell.Y >= WorldGrid.GridBounds.Y && 
                cell.Y <= WorldGrid.GridBounds.Height &&
                cell.X >= WorldGrid.GridBounds.X && 
                cell.X <= WorldGrid.GridBounds.Width;
      }
   }
}
