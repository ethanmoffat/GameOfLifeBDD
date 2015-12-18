namespace GameOfLifeUI
{
   partial class SimulateFutureForm
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
         this.NumberOfGenerations = new System.Windows.Forms.TextBox();
         this.RunButton = new System.Windows.Forms.Button();
         this.Cancel = new System.Windows.Forms.Button();
         this.Group = new System.Windows.Forms.GroupBox();
         this.ProgressBar = new System.Windows.Forms.ProgressBar();
         this.StopCalculation = new System.Windows.Forms.Button();
         this.Group.SuspendLayout();
         this.SuspendLayout();
         // 
         // NumberOfGenerations
         // 
         this.NumberOfGenerations.Location = new System.Drawing.Point(6, 19);
         this.NumberOfGenerations.Name = "NumberOfGenerations";
         this.NumberOfGenerations.Size = new System.Drawing.Size(104, 20);
         this.NumberOfGenerations.TabIndex = 0;
         // 
         // RunButton
         // 
         this.RunButton.Location = new System.Drawing.Point(135, 12);
         this.RunButton.Name = "RunButton";
         this.RunButton.Size = new System.Drawing.Size(75, 23);
         this.RunButton.TabIndex = 1;
         this.RunButton.Text = "Run";
         this.RunButton.UseVisualStyleBackColor = true;
         this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
         // 
         // Cancel
         // 
         this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Cancel.Location = new System.Drawing.Point(135, 41);
         this.Cancel.Name = "Cancel";
         this.Cancel.Size = new System.Drawing.Size(75, 23);
         this.Cancel.TabIndex = 3;
         this.Cancel.Text = "Cancel";
         this.Cancel.UseVisualStyleBackColor = true;
         this.Cancel.Click += new System.EventHandler(this.CancelButton_Click);
         // 
         // Group
         // 
         this.Group.Controls.Add(this.NumberOfGenerations);
         this.Group.Location = new System.Drawing.Point(12, 12);
         this.Group.Name = "Group";
         this.Group.Size = new System.Drawing.Size(116, 52);
         this.Group.TabIndex = 0;
         this.Group.TabStop = false;
         this.Group.Text = "# Of Generations";
         // 
         // ProgressBar
         // 
         this.ProgressBar.Location = new System.Drawing.Point(12, 70);
         this.ProgressBar.Name = "ProgressBar";
         this.ProgressBar.Size = new System.Drawing.Size(198, 23);
         this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
         this.ProgressBar.TabIndex = 4;
         // 
         // StopCalculation
         // 
         this.StopCalculation.Location = new System.Drawing.Point(135, 12);
         this.StopCalculation.Name = "StopCalculation";
         this.StopCalculation.Size = new System.Drawing.Size(75, 23);
         this.StopCalculation.TabIndex = 2;
         this.StopCalculation.Text = "Stop";
         this.StopCalculation.UseVisualStyleBackColor = true;
         this.StopCalculation.Visible = false;
         this.StopCalculation.Click += new System.EventHandler(this.StopCalculation_Click);
         // 
         // SimulateFutureForm
         // 
         this.AcceptButton = this.RunButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.Cancel;
         this.ClientSize = new System.Drawing.Size(222, 104);
         this.Controls.Add(this.ProgressBar);
         this.Controls.Add(this.Group);
         this.Controls.Add(this.Cancel);
         this.Controls.Add(this.RunButton);
         this.Controls.Add(this.StopCalculation);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SimulateFutureForm";
         this.ShowIcon = false;
         this.Text = "Simulate Future Generation";
         this.Group.ResumeLayout(false);
         this.Group.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox NumberOfGenerations;
      private System.Windows.Forms.Button RunButton;
      private System.Windows.Forms.Button Cancel;
      private System.Windows.Forms.GroupBox Group;
      private System.Windows.Forms.ProgressBar ProgressBar;
      private System.Windows.Forms.Button StopCalculation;
   }
}