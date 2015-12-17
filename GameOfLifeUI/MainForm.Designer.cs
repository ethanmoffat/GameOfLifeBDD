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
         this.GenerationList = new PastGenerationListBox();
         this.SimulationSpeed = new System.Windows.Forms.TrackBar();
         this.SimulationSpeedLabel = new System.Windows.Forms.Label();
         this.MouseOverCellLabel = new System.Windows.Forms.Label();
         this.WorldGrid = new GameOfLifeUI.WorldGrid();
         ((System.ComponentModel.ISupportInitialize)(this.SimulationSpeed)).BeginInit();
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
         this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
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
         // GenerationList
         // 
         this.GenerationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.GenerationList.FormattingEnabled = true;
         this.GenerationList.Location = new System.Drawing.Point(307, 41);
         this.GenerationList.Name = "GenerationList";
         this.GenerationList.Size = new System.Drawing.Size(195, 238);
         this.GenerationList.TabIndex = 5;
         this.GenerationList.SelectedIndexChanged += new System.EventHandler(this.GenerationList_SelectedIndexChanged);
         // 
         // SimulationSpeed
         // 
         this.SimulationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.SimulationSpeed.LargeChange = 100;
         this.SimulationSpeed.Location = new System.Drawing.Point(356, 285);
         this.SimulationSpeed.Maximum = 2000;
         this.SimulationSpeed.Minimum = 100;
         this.SimulationSpeed.Name = "SimulationSpeed";
         this.SimulationSpeed.Size = new System.Drawing.Size(155, 45);
         this.SimulationSpeed.SmallChange = 25;
         this.SimulationSpeed.TabIndex = 6;
         this.SimulationSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
         this.SimulationSpeed.Value = 300;
         this.SimulationSpeed.Scroll += new System.EventHandler(this.SimulationSpeed_Scroll);
         // 
         // SimulationSpeedLabel
         // 
         this.SimulationSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.SimulationSpeedLabel.AutoSize = true;
         this.SimulationSpeedLabel.Location = new System.Drawing.Point(310, 288);
         this.SimulationSpeedLabel.Name = "SimulationSpeedLabel";
         this.SimulationSpeedLabel.Size = new System.Drawing.Size(41, 13);
         this.SimulationSpeedLabel.TabIndex = 7;
         this.SimulationSpeedLabel.Text = "300 ms";
         // 
         // MouseOverCellLabel
         // 
         this.MouseOverCellLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.MouseOverCellLabel.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.MouseOverCellLabel.Location = new System.Drawing.Point(12, 305);
         this.MouseOverCellLabel.Name = "MouseOverCellLabel";
         this.MouseOverCellLabel.Size = new System.Drawing.Size(290, 14);
         this.MouseOverCellLabel.TabIndex = 8;
         this.MouseOverCellLabel.Text = "99x99";
         this.MouseOverCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // WorldGrid
         // 
         this.WorldGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.WorldGrid.BackColor = System.Drawing.Color.CornflowerBlue;
         this.WorldGrid.Location = new System.Drawing.Point(12, 12);
         this.WorldGrid.MinimumSize = new System.Drawing.Size(290, 290);
         this.WorldGrid.Name = "WorldGrid";
         this.WorldGrid.Size = new System.Drawing.Size(290, 290);
         this.WorldGrid.TabIndex = 0;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ClientSize = new System.Drawing.Size(514, 328);
         this.Controls.Add(this.MouseOverCellLabel);
         this.Controls.Add(this.SimulationSpeedLabel);
         this.Controls.Add(this.SimulationSpeed);
         this.Controls.Add(this.GenerationList);
         this.Controls.Add(this.ResetButton);
         this.Controls.Add(this.RunButton);
         this.Controls.Add(this.WorldGrid);
         this.Controls.Add(this.PauseButton);
         this.Controls.Add(this.ResumeButton);
         this.DoubleBuffered = true;
         this.MinimumSize = new System.Drawing.Size(530, 352);
         this.Name = "MainForm";
         this.Text = "[temporary title]";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.SimulationSpeed)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private WorldGrid WorldGrid;
      private System.Windows.Forms.Button RunButton;
      private System.Windows.Forms.Button PauseButton;
      private System.Windows.Forms.Button ResetButton;
      private System.Windows.Forms.Button ResumeButton;
      private PastGenerationListBox GenerationList;
      private System.Windows.Forms.TrackBar SimulationSpeed;
      private System.Windows.Forms.Label SimulationSpeedLabel;
      private System.Windows.Forms.Label MouseOverCellLabel;

   }
}

