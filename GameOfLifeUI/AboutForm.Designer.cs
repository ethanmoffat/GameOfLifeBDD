namespace GameOfLifeUI
{
   partial class AboutForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.OkButton = new System.Windows.Forms.Button();
         this.AboutLabel = new System.Windows.Forms.Label();
         this.LinkToGithub = new System.Windows.Forms.LinkLabel();
         this.SuspendLayout();
         // 
         // OkButton
         // 
         this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.OkButton.Location = new System.Drawing.Point(103, 105);
         this.OkButton.Name = "OkButton";
         this.OkButton.Size = new System.Drawing.Size(75, 23);
         this.OkButton.TabIndex = 0;
         this.OkButton.Text = "OK";
         this.OkButton.UseVisualStyleBackColor = true;
         this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
         // 
         // AboutLabel
         // 
         this.AboutLabel.Location = new System.Drawing.Point(12, 9);
         this.AboutLabel.Name = "AboutLabel";
         this.AboutLabel.Size = new System.Drawing.Size(255, 70);
         this.AboutLabel.TabIndex = 1;
         this.AboutLabel.Text = "Game Of Life Simulator\r\n(c) Ethan Moffat 2015\r\n\r\nAn exploration of Behavior Drive" +
    "n Development using SpecFlow, White, and C# WinForms\r\n";
         this.AboutLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         // 
         // LinkToGithub
         // 
         this.LinkToGithub.AutoSize = true;
         this.LinkToGithub.Location = new System.Drawing.Point(6, 84);
         this.LinkToGithub.Name = "LinkToGithub";
         this.LinkToGithub.Size = new System.Drawing.Size(269, 13);
         this.LinkToGithub.TabIndex = 2;
         this.LinkToGithub.TabStop = true;
         this.LinkToGithub.Text = "https://www.github.com/EthanMoffat/GameOfLifeBDD";
         this.LinkToGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkToGithub_LinkClicked);
         // 
         // AboutForm
         // 
         this.AcceptButton = this.OkButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.OkButton;
         this.ClientSize = new System.Drawing.Size(280, 135);
         this.Controls.Add(this.LinkToGithub);
         this.Controls.Add(this.AboutLabel);
         this.Controls.Add(this.OkButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AboutForm";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "About";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button OkButton;
      private System.Windows.Forms.Label AboutLabel;
      private System.Windows.Forms.LinkLabel LinkToGithub;
   }
}