﻿namespace WinFormUI
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grdReport = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)grdReport).BeginInit();
            SuspendLayout();
            // 
            // grdReport
            // 
            grdReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdReport.Location = new Point(105, 87);
            grdReport.Name = "grdReport";
            grdReport.RowTemplate.Height = 25;
            grdReport.Size = new Size(602, 293);
            grdReport.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(128, 25);
            button1.Name = "button1";
            button1.Size = new Size(565, 23);
            button1.TabIndex = 1;
            button1.Text = "Hangi Kategorinin Hangi Ürününden Ne Kadarlık Satış Var";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(grdReport);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)grdReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdReport;
		private Button button1;
	}
}