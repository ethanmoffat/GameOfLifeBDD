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
         this.SimulationSpeed = new System.Windows.Forms.TrackBar();
         this.SimulationSpeedLabel = new System.Windows.Forms.Label();
         this.MouseOverCellLabel = new System.Windows.Forms.Label();
         this.MenuStrip = new System.Windows.Forms.MenuStrip();
         this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.FileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.OpenSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SaveSessionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.FileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.WorldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SeedWithPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.GosperGliderPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.RandomPatternMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ClearWorldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SimulationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SimulateFutureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ResetToGenerationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.OpenFile = new System.Windows.Forms.OpenFileDialog();
         this.SaveFile = new System.Windows.Forms.SaveFileDialog();
         this.GenerationList = new GameOfLifeUI.PastGenerationListBox();
         this.WorldGrid = new GameOfLifeUI.WorldGrid();
         ((System.ComponentModel.ISupportInitialize)(this.SimulationSpeed)).BeginInit();
         this.MenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // RunButton
         // 
         this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.RunButton.Location = new System.Drawing.Point(307, 29);
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
         this.PauseButton.Location = new System.Drawing.Point(374, 29);
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
         this.ResetButton.Location = new System.Drawing.Point(441, 29);
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
         this.ResumeButton.Location = new System.Drawing.Point(374, 29);
         this.ResumeButton.Name = "ResumeButton";
         this.ResumeButton.Size = new System.Drawing.Size(61, 23);
         this.ResumeButton.TabIndex = 4;
         this.ResumeButton.Text = "Resume";
         this.ResumeButton.UseVisualStyleBackColor = true;
         this.ResumeButton.Visible = false;
         this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
         // 
         // SimulationSpeed
         // 
         this.SimulationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.SimulationSpeed.LargeChange = 100;
         this.SimulationSpeed.Location = new System.Drawing.Point(355, 312);
         this.SimulationSpeed.Maximum = 1000;
         this.SimulationSpeed.Minimum = 25;
         this.SimulationSpeed.Name = "SimulationSpeed";
         this.SimulationSpeed.Size = new System.Drawing.Size(147, 45);
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
         this.SimulationSpeedLabel.Location = new System.Drawing.Point(308, 316);
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
         this.MouseOverCellLabel.Location = new System.Drawing.Point(12, 322);
         this.MouseOverCellLabel.Name = "MouseOverCellLabel";
         this.MouseOverCellLabel.Size = new System.Drawing.Size(290, 14);
         this.MouseOverCellLabel.TabIndex = 8;
         this.MouseOverCellLabel.Text = "99x99";
         this.MouseOverCellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // MenuStrip
         // 
         this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.WorldMenuItem,
            this.SimulationMenuItem,
            this.HelpMenuItem});
         this.MenuStrip.Location = new System.Drawing.Point(0, 0);
         this.MenuStrip.Name = "MenuStrip";
         this.MenuStrip.Size = new System.Drawing.Size(514, 24);
         this.MenuStrip.TabIndex = 9;
         // 
         // FileMenuItem
         // 
         this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.FileMenuSeparator1,
            this.OpenSessionMenuItem,
            this.SaveSessionMenuItem,
            this.FileMenuSeparator2,
            this.ExitMenuItem});
         this.FileMenuItem.Name = "FileMenuItem";
         this.FileMenuItem.Size = new System.Drawing.Size(37, 20);
         this.FileMenuItem.Text = "File";
         // 
         // OpenMenuItem
         // 
         this.OpenMenuItem.Name = "OpenMenuItem";
         this.OpenMenuItem.Size = new System.Drawing.Size(215, 22);
         this.OpenMenuItem.Text = "Open World From File...";
         this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
         // 
         // SaveMenuItem
         // 
         this.SaveMenuItem.Name = "SaveMenuItem";
         this.SaveMenuItem.Size = new System.Drawing.Size(215, 22);
         this.SaveMenuItem.Text = "Save Selected Generation...";
         this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
         // 
         // FileMenuSeparator1
         // 
         this.FileMenuSeparator1.Name = "FileMenuSeparator1";
         this.FileMenuSeparator1.Size = new System.Drawing.Size(212, 6);
         // 
         // OpenSessionMenuItem
         // 
         this.OpenSessionMenuItem.Name = "OpenSessionMenuItem";
         this.OpenSessionMenuItem.Size = new System.Drawing.Size(215, 22);
         this.OpenSessionMenuItem.Text = "Open Session...";
         this.OpenSessionMenuItem.Click += new System.EventHandler(this.OpenSessionMenuItem_Click);
         // 
         // SaveSessionMenuItem
         // 
         this.SaveSessionMenuItem.Name = "SaveSessionMenuItem";
         this.SaveSessionMenuItem.Size = new System.Drawing.Size(215, 22);
         this.SaveSessionMenuItem.Text = "Save Session...";
         this.SaveSessionMenuItem.Click += new System.EventHandler(this.SaveSessionMenuItem_Click);
         // 
         // FileMenuSeparator2
         // 
         this.FileMenuSeparator2.Name = "FileMenuSeparator2";
         this.FileMenuSeparator2.Size = new System.Drawing.Size(212, 6);
         // 
         // ExitMenuItem
         // 
         this.ExitMenuItem.Name = "ExitMenuItem";
         this.ExitMenuItem.Size = new System.Drawing.Size(215, 22);
         this.ExitMenuItem.Text = "Exit";
         this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
         // 
         // WorldMenuItem
         // 
         this.WorldMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SeedWithPatternMenuItem,
            this.ClearWorldMenuItem});
         this.WorldMenuItem.Name = "WorldMenuItem";
         this.WorldMenuItem.Size = new System.Drawing.Size(51, 20);
         this.WorldMenuItem.Text = "World";
         // 
         // SeedWithPatternMenuItem
         // 
         this.SeedWithPatternMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GosperGliderPatternMenuItem,
            this.RandomPatternMenuItem});
         this.SeedWithPatternMenuItem.Name = "SeedWithPatternMenuItem";
         this.SeedWithPatternMenuItem.Size = new System.Drawing.Size(166, 22);
         this.SeedWithPatternMenuItem.Text = "Seed with pattern";
         // 
         // GosperGliderPatternMenuItem
         // 
         this.GosperGliderPatternMenuItem.Name = "GosperGliderPatternMenuItem";
         this.GosperGliderPatternMenuItem.Size = new System.Drawing.Size(170, 22);
         this.GosperGliderPatternMenuItem.Text = "Gosper Glider Gun";
         this.GosperGliderPatternMenuItem.Click += new System.EventHandler(this.GosperGliderPatternMenuItem_Click);
         // 
         // RandomPatternMenuItem
         // 
         this.RandomPatternMenuItem.Name = "RandomPatternMenuItem";
         this.RandomPatternMenuItem.Size = new System.Drawing.Size(170, 22);
         this.RandomPatternMenuItem.Text = "Random";
         this.RandomPatternMenuItem.Click += new System.EventHandler(this.RandomPatternMenuItem_Click);
         // 
         // ClearWorldMenuItem
         // 
         this.ClearWorldMenuItem.Name = "ClearWorldMenuItem";
         this.ClearWorldMenuItem.Size = new System.Drawing.Size(166, 22);
         this.ClearWorldMenuItem.Text = "Clear All Cells";
         this.ClearWorldMenuItem.Click += new System.EventHandler(this.ClearWorldMenuItem_Click);
         // 
         // SimulationMenuItem
         // 
         this.SimulationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SimulateFutureMenuItem,
            this.ResetToGenerationMenuItem});
         this.SimulationMenuItem.Name = "SimulationMenuItem";
         this.SimulationMenuItem.Size = new System.Drawing.Size(76, 20);
         this.SimulationMenuItem.Text = "Simulation";
         // 
         // SimulateFutureMenuItem
         // 
         this.SimulateFutureMenuItem.Name = "SimulateFutureMenuItem";
         this.SimulateFutureMenuItem.Size = new System.Drawing.Size(224, 22);
         this.SimulateFutureMenuItem.Text = "Simulate Future...";
         this.SimulateFutureMenuItem.Click += new System.EventHandler(this.SimulateFutureMenuItem_Click);
         // 
         // ResetToGenerationMenuItem
         // 
         this.ResetToGenerationMenuItem.Name = "ResetToGenerationMenuItem";
         this.ResetToGenerationMenuItem.Size = new System.Drawing.Size(224, 22);
         this.ResetToGenerationMenuItem.Text = "Reset to Selected Generation";
         this.ResetToGenerationMenuItem.Click += new System.EventHandler(this.ResetToGenerationMenuItem_Click);
         // 
         // HelpMenuItem
         // 
         this.HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutMenuItem});
         this.HelpMenuItem.Name = "HelpMenuItem";
         this.HelpMenuItem.Size = new System.Drawing.Size(44, 20);
         this.HelpMenuItem.Text = "Help";
         // 
         // AboutMenuItem
         // 
         this.AboutMenuItem.Name = "AboutMenuItem";
         this.AboutMenuItem.Size = new System.Drawing.Size(107, 22);
         this.AboutMenuItem.Text = "About";
         this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
         // 
         // OpenFile
         // 
         this.OpenFile.DefaultExt = "gol";
         this.OpenFile.FileName = "seed.gol";
         this.OpenFile.Filter = "Game of Life Seed Files|*.gol|All Files|*.*";
         this.OpenFile.SupportMultiDottedExtensions = true;
         // 
         // SaveFile
         // 
         this.SaveFile.DefaultExt = "gol";
         this.SaveFile.FileName = "seed.gol";
         this.SaveFile.Filter = "Game of Life Seed Files|*.gol|All Files|*.*";
         this.SaveFile.SupportMultiDottedExtensions = true;
         this.SaveFile.Title = "Save Generation to File";
         // 
         // GenerationList
         // 
         this.GenerationList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.GenerationList.FormattingEnabled = true;
         this.GenerationList.Location = new System.Drawing.Point(307, 55);
         this.GenerationList.Name = "GenerationList";
         this.GenerationList.SelectedItem = null;
         this.GenerationList.Size = new System.Drawing.Size(195, 251);
         this.GenerationList.TabIndex = 5;
         this.GenerationList.SelectedIndexChanged += new System.EventHandler(this.GenerationList_SelectedIndexChanged);
         // 
         // WorldGrid
         // 
         this.WorldGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.WorldGrid.BackColor = System.Drawing.Color.CornflowerBlue;
         this.WorldGrid.Location = new System.Drawing.Point(12, 29);
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
         this.ClientSize = new System.Drawing.Size(514, 345);
         this.Controls.Add(this.MouseOverCellLabel);
         this.Controls.Add(this.SimulationSpeedLabel);
         this.Controls.Add(this.SimulationSpeed);
         this.Controls.Add(this.GenerationList);
         this.Controls.Add(this.ResetButton);
         this.Controls.Add(this.RunButton);
         this.Controls.Add(this.WorldGrid);
         this.Controls.Add(this.ResumeButton);
         this.Controls.Add(this.MenuStrip);
         this.Controls.Add(this.PauseButton);
         this.DoubleBuffered = true;
         this.MainMenuStrip = this.MenuStrip;
         this.MinimumSize = new System.Drawing.Size(530, 352);
         this.Name = "MainForm";
         this.Text = "[temporary title]";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this.SimulationSpeed)).EndInit();
         this.MenuStrip.ResumeLayout(false);
         this.MenuStrip.PerformLayout();
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
      private System.Windows.Forms.MenuStrip MenuStrip;
      private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
      private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
      private System.Windows.Forms.ToolStripSeparator FileMenuSeparator2;
      private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
      private System.Windows.Forms.ToolStripMenuItem WorldMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SeedWithPatternMenuItem;
      private System.Windows.Forms.ToolStripMenuItem GosperGliderPatternMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SimulationMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SimulateFutureMenuItem;
      private System.Windows.Forms.ToolStripMenuItem HelpMenuItem;
      private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ClearWorldMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ResetToGenerationMenuItem;
      private System.Windows.Forms.ToolStripMenuItem RandomPatternMenuItem;
      private System.Windows.Forms.OpenFileDialog OpenFile;
      private System.Windows.Forms.SaveFileDialog SaveFile;
      private System.Windows.Forms.ToolStripSeparator FileMenuSeparator1;
      private System.Windows.Forms.ToolStripMenuItem OpenSessionMenuItem;
      private System.Windows.Forms.ToolStripMenuItem SaveSessionMenuItem;

   }
}

