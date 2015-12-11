namespace GameOfLifeUI
{
   partial class MainForm
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
         this.RunButton = new System.Windows.Forms.Button();
         this.PauseButton = new System.Windows.Forms.Button();
         this.ResetButton = new System.Windows.Forms.Button();
         this.ResumeButton = new System.Windows.Forms.Button();
         this.WorldGrid = new GameOfLifeUI.WorldGrid();
         this.SuspendLayout();
         // 
         // RunButton
         // 
         this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.RunButton.Location = new System.Drawing.Point(307, 12);
         this.RunButton.Name = "RunButton";
         this.RunButton.Size = new System.Drawing.Size(61, 23);
         this.RunButton.TabIndex = 1;
         this.RunButton.Text = "Run";
         this.RunButton.UseVisualStyleBackColor = true;
         this.RunButton.Click += new System.EventHandler(this.GoButton_Click);
         // 
         // PauseButton
         // 
         this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.PauseButton.Enabled = false;
         this.PauseButton.Location = new System.Drawing.Point(374, 12);
         this.PauseButton.Name = "PauseButton";
         this.PauseButton.Size = new System.Drawing.Size(61, 23);
         this.PauseButton.TabIndex = 2;
         this.PauseButton.Text = "Pause";
         this.PauseButton.UseVisualStyleBackColor = true;
         this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
         // 
         // ResetButton
         // 
         this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.ResetButton.Enabled = false;
         this.ResetButton.Location = new System.Drawing.Point(441, 12);
         this.ResetButton.Name = "ResetButton";
         this.ResetButton.Size = new System.Drawing.Size(61, 23);
         this.ResetButton.TabIndex = 3;
         this.ResetButton.Text = "Reset";
         this.ResetButton.UseVisualStyleBackColor = true;
         this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
         // 
         // ResumeButton
         // 
         this.ResumeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.ResumeButton.Enabled = false;
         this.ResumeButton.Location = new System.Drawing.Point(374, 12);
         this.ResumeButton.Name = "ResumeButton";
         this.ResumeButton.Size = new System.Drawing.Size(61, 23);
         this.ResumeButton.TabIndex = 4;
         this.ResumeButton.Text = "Resume";
         this.ResumeButton.UseVisualStyleBackColor = true;
         this.ResumeButton.Visible = false;
         this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
         // 
         // WorldGrid
         // 
         this.WorldGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.WorldGrid.Location = new System.Drawing.Point(12, 12);
         this.WorldGrid.MaximumSize = new System.Drawing.Size(190, 212);
         this.WorldGrid.MinimumSize = new System.Drawing.Size(289, 289);
         this.WorldGrid.Name = "WorldGrid";
         this.WorldGrid.Size = new System.Drawing.Size(289, 289);
         this.WorldGrid.TabIndex = 0;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ClientSize = new System.Drawing.Size(514, 314);
         this.Controls.Add(this.ResetButton);
         this.Controls.Add(this.RunButton);
         this.Controls.Add(this.WorldGrid);
         this.Controls.Add(this.ResumeButton);
         this.Controls.Add(this.PauseButton);
         this.Name = "MainForm";
         this.Text = "[temporary title]";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private WorldGrid WorldGrid;
      private System.Windows.Forms.Button RunButton;
      private System.Windows.Forms.Button PauseButton;
      private System.Windows.Forms.Button ResetButton;
      private System.Windows.Forms.Button ResumeButton;

   }
}

