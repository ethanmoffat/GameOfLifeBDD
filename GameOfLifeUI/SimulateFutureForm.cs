using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife;

namespace GameOfLifeUI
{
   public partial class SimulateFutureForm : Form
   {
      public World CalculatedWorld { get; private set; }
      public List<World> CalculatedGenerations { get; private set; }

      private readonly World _startingWorld;
      private CancellationTokenSource _cts;

      public SimulateFutureForm(World startingWorld)
      {
         InitializeComponent();

         _startingWorld = startingWorld;
      }

      private async void RunButton_Click(object sender, EventArgs e)
      {
         int gens;
         if (!ValidateTextbox(out gens))
         {
            MessageBox.Show("Please enter a valid Integer for number of generations", "Unable to parse");
            return;
         }

         if (_cts != null)
            _cts.Dispose();
         _cts = new CancellationTokenSource();

         InvokeIfNeeded(RunButton, () => RunButton.Visible = false);
         InvokeIfNeeded(StopCalculation, () => StopCalculation.Visible = true);
         InvokeIfNeeded(Cancel, () => Cancel.Enabled = false);
         InvokeIfNeeded(NumberOfGenerations, () => NumberOfGenerations.Enabled = false);

         await Task.Run(() => _doWork(gens, _cts.Token));

         if (CalculatedWorld != null)
         {
            InvokeIfNeeded(this, () => DialogResult = DialogResult.OK);
            InvokeIfNeeded(this, Close);
         }
         else
         {
            InvokeIfNeeded(RunButton, () => RunButton.Visible = true);
            InvokeIfNeeded(StopCalculation, () => StopCalculation.Visible = false);
            InvokeIfNeeded(Cancel, () => Cancel.Enabled = true);
            InvokeIfNeeded(NumberOfGenerations, () => NumberOfGenerations.Enabled = true);
         }
      }

      private void StopCalculation_Click(object sender, EventArgs e)
      {
         _cts.Cancel();

         RunButton.Visible = true;
         StopCalculation.Visible = false;
         Cancel.Enabled = true;
         NumberOfGenerations.Enabled = true;
      }

      private void CancelButton_Click(object sender, EventArgs e)
      {
         Close();
      }

      private bool ValidateTextbox(out int generations)
      {
         return int.TryParse(NumberOfGenerations.Text, out generations);
      }

      private void _doWork(int generations, CancellationToken ct)
      {
         InvokeIfNeeded(ProgressBar, () => ProgressBar.Minimum = 0);
         InvokeIfNeeded(ProgressBar, () => ProgressBar.Maximum = generations);
         InvokeIfNeeded(ProgressBar, () => ProgressBar.Value = 0);

         var nextWorld = _startingWorld;
         var gens = new List<World>(generations) { _startingWorld };
         for (int i = 1; i <= generations; ++i)
         {
            if (ct.IsCancellationRequested) return;

            int current = i;
            InvokeIfNeeded(ProgressBar, () => ProgressBar.Value = current);

            nextWorld = nextWorld.GetNextGeneration();
            if (!nextWorld.Cells.Any(x => x.IsAlive))
            {
               MessageBox.Show("Simulation ended at generation " + i + " with 0 live cells.", "Simulation ended early");
               break;
            }
            //todo: match oscillator patterns and terminate early
            gens.Add(nextWorld);
         }

         Thread.Sleep(1000);
         CalculatedWorld = nextWorld;
         CalculatedGenerations = gens;
      }

      private void InvokeIfNeeded(Control c, Action a)
      {
         if (c.InvokeRequired)
            c.Invoke(a);
         else
            a();
      }
   }
}
