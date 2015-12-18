using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameOfLifeUI
{
   public partial class AboutForm : Form
   {
      public AboutForm()
      {
         InitializeComponent();
      }

      private void LinkToGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(LinkToGithub.Text);
      }

      private void OkButton_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
