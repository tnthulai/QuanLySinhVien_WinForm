namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class AverageScoreByCourse
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
            this.dataAvgScore = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataAvgScore)).BeginInit();
            this.SuspendLayout();
            // 
            // dataAvgScore
            // 
            this.dataAvgScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAvgScore.Location = new System.Drawing.Point(13, 13);
            this.dataAvgScore.Name = "dataAvgScore";
            this.dataAvgScore.RowHeadersWidth = 51;
            this.dataAvgScore.RowTemplate.Height = 24;
            this.dataAvgScore.Size = new System.Drawing.Size(484, 425);
            this.dataAvgScore.TabIndex = 0;
            // 
            // AverageScoreByCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.dataAvgScore);
            this.Name = "AverageScoreByCourse";
            this.Text = "AverageScoreByCourse";
            this.Load += new System.EventHandler(this.AverageScoreByCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAvgScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataAvgScore;
    }
}