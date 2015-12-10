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
         this.WorldGrid = new GameOfLifeUI.WorldGrid();
         this.GoButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // WorldGrid
         // 
         this.WorldGrid.Location = new System.Drawing.Point(12, 12);
         this.WorldGrid.MaximumSize = new System.Drawing.Size(190, 212);
         this.WorldGrid.MinimumSize = new System.Drawing.Size(289, 289);
         this.WorldGrid.Name = "WorldGrid";
         this.WorldGrid.Size = new System.Drawing.Size(289, 289);
         this.WorldGrid.TabIndex = 0;
         // 
         // GoButton
         // 
         this.GoButton.Location = new System.Drawing.Point(12, 307);
         this.GoButton.Name = "GoButton";
         this.GoButton.Size = new System.Drawing.Size(75, 23);
         this.GoButton.TabIndex = 1;
         this.GoButton.Text = "Go";
         this.GoButton.UseVisualStyleBackColor = true;
         this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ClientSize = new System.Drawing.Size(378, 372);
         this.Controls.Add(this.GoButton);
         this.Controls.Add(this.WorldGrid);
         this.Name = "MainForm";
         this.Text = "[temporary title]";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private WorldGrid WorldGrid;
      private System.Windows.Forms.Button GoButton;

   }
}

