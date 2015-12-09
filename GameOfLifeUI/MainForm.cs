using System.Windows.Forms;

namespace GameOfLifeUI
{
   public partial class MainForm : Form
   {
      public const string TITLE_TEXT = "Game of Life Simulation";

      public MainForm()
      {
         InitializeComponent();
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Text = TITLE_TEXT;
      }
   }
}
