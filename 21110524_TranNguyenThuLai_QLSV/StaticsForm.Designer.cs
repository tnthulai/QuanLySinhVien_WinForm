namespace _21110524_TranNguyenThuLai_QLSV
{
    partial class StaticsForm
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
            this.pnTotal = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnMale = new System.Windows.Forms.Panel();
            this.pnFemale = new System.Windows.Forms.Panel();
            this.lblMale = new System.Windows.Forms.Label();
            this.lblFemale = new System.Windows.Forms.Label();
            this.pnTotal.SuspendLayout();
            this.pnMale.SuspendLayout();
            this.pnFemale.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTotal
            // 
            this.pnTotal.BackColor = System.Drawing.Color.Coral;
            this.pnTotal.Controls.Add(this.lblTotal);
            this.pnTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTotal.Location = new System.Drawing.Point(0, 0);
            this.pnTotal.Name = "pnTotal";
            this.pnTotal.Size = new System.Drawing.Size(484, 104);
            this.pnTotal.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(484, 104);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total Student:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotal.MouseEnter += new System.EventHandler(this.labelTotal_MouseEnter);
            this.lblTotal.MouseLeave += new System.EventHandler(this.labelTotal_MouseLeave);
            // 
            // pnMale
            // 
            this.pnMale.BackColor = System.Drawing.Color.Red;
            this.pnMale.Controls.Add(this.lblMale);
            this.pnMale.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMale.Location = new System.Drawing.Point(0, 104);
            this.pnMale.Name = "pnMale";
            this.pnMale.Size = new System.Drawing.Size(243, 107);
            this.pnMale.TabIndex = 1;
            // 
            // pnFemale
            // 
            this.pnFemale.BackColor = System.Drawing.Color.Yellow;
            this.pnFemale.Controls.Add(this.lblFemale);
            this.pnFemale.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnFemale.Location = new System.Drawing.Point(243, 104);
            this.pnFemale.Name = "pnFemale";
            this.pnFemale.Size = new System.Drawing.Size(241, 107);
            this.pnFemale.TabIndex = 2;
            // 
            // lblMale
            // 
            this.lblMale.BackColor = System.Drawing.Color.SpringGreen;
            this.lblMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMale.ForeColor = System.Drawing.Color.White;
            this.lblMale.Location = new System.Drawing.Point(0, 0);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new System.Drawing.Size(243, 107);
            this.lblMale.TabIndex = 0;
            this.lblMale.Text = "Male: ";
            this.lblMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMale.MouseEnter += new System.EventHandler(this.LabelMale_MouseEnter);
            this.lblMale.MouseLeave += new System.EventHandler(this.LabelMale_MouseLeave);
            // 
            // lblFemale
            // 
            this.lblFemale.BackColor = System.Drawing.Color.HotPink;
            this.lblFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFemale.ForeColor = System.Drawing.Color.White;
            this.lblFemale.Location = new System.Drawing.Point(0, 0);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new System.Drawing.Size(241, 107);
            this.lblFemale.TabIndex = 0;
            this.lblFemale.Text = "Female: ";
            this.lblFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFemale.MouseEnter += new System.EventHandler(this.LabelFemale_MouseEnter);
            this.lblFemale.MouseLeave += new System.EventHandler(this.LabelFemale_MouseLeave);
            // 
            // StaticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.pnFemale);
            this.Controls.Add(this.pnMale);
            this.Controls.Add(this.pnTotal);
            this.Name = "StaticsForm";
            this.Text = "StaticsForm";
            this.Load += new System.EventHandler(this.StaticsForm_Load);
            this.pnTotal.ResumeLayout(false);
            this.pnMale.ResumeLayout(false);
            this.pnFemale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnMale;
        private System.Windows.Forms.Panel pnFemale;
        private System.Windows.Forms.Label lblMale;
        private System.Windows.Forms.Label lblFemale;
    }
}