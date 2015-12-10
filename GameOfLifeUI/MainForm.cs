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
      private readonly IWorldRepository _worldRepository;

      public MainForm()
      {
         InitializeComponent();

         _worldRepository = new WorldRepository();
         IWorldActions worldActions = new WorldActions(_worldRepository);
         _worldController = new WorldController(worldActions);

         WorldGrid.GridCellClicked += WorldGrid_GridCellClicked;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Text = TITLE_TEXT;
         _worldController.CreateDefaultWorld();
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
         if (GoButton.Text != "Stop")
         {
            WorldGrid.LockAllCells();
            _worker = new Thread(_doWork);
            _ctSource = new CancellationTokenSource();
            _worker.Start(_ctSource.Token);
            GoButton.Text = "Stop";
         }
         else
         {
            _ctSource.Cancel();
            _worker.Join();
            WorldGrid.UnlockAllCells();
            GoButton.Text = "Go";
         }
      }

      private void _doWork(object param)
      {
         var ct = (CancellationToken) param;
         while (!ct.IsCancellationRequested)
         {
            _worldController.CalculateNextGeneration();
            UpdateGridFromWorld();

            //stop running if no live cells...
            //if (_worldRepository.CurrentWorld.Cells.All(x => !x.IsAlive))
            //   break;

            Thread.Sleep(300);
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_worker.IsAlive)
         {
            _ctSource.Cancel();
            _worker.Join();
         }
      }

      private void UpdateGridFromWorld()
      {
         foreach (var cell in _worldRepository.CurrentWorld.Cells)
            if (cell.Y < WorldGrid.GridBounds.Y || 
                cell.Y > WorldGrid.GridBounds.Height ||
                cell.X < WorldGrid.GridBounds.X || 
                cell.X > WorldGrid.GridBounds.Width) /*totally on purpose empty statement*/;
            else if (cell.IsAlive != WorldGrid[cell.Y, cell.X].Activated)
               WorldGrid[cell.Y, cell.X].ToggleActivate();
      }
   }
}
