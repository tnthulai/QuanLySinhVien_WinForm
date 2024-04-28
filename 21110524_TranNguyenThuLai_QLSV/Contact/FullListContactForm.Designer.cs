namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    partial class FullListContactForm
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
            this.listBoxGroup = new System.Windows.Forms.ListBox();
            this.lblGroup = new System.Windows.Forms.LinkLabel();
            this.lblShowAll = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxGroup
            // 
            this.listBoxGroup.FormattingEnabled = true;
            this.listBoxGroup.ItemHeight = 16;
            this.listBoxGroup.Location = new System.Drawing.Point(12, 69);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(245, 196);
            this.listBoxGroup.TabIndex = 0;
            this.listBoxGroup.SelectedValueChanged += new System.EventHandler(this.listBoxGroup_SelectedValueChanged);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.LinkColor = System.Drawing.Color.White;
            this.lblGroup.Location = new System.Drawing.Point(12, 30);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(71, 25);
            this.lblGroup.TabIndex = 2;
            this.lblGroup.TabStop = true;
            this.lblGroup.Text = "Group";
            // 
            // lblShowAll
            // 
            this.lblShowAll.AutoSize = true;
            this.lblShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowAll.LinkColor = System.Drawing.Color.White;
            this.lblShowAll.Location = new System.Drawing.Point(287, 30);
            this.lblShowAll.Name = "lblShowAll";
            this.lblShowAll.Size = new System.Drawing.Size(97, 25);
            this.lblShowAll.TabIndex = 2;
            this.lblShowAll.TabStop = true;
            this.lblShowAll.Text = "Show All";
            this.lblShowAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblShowAll_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(298, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(711, 192);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // FullListContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1034, 326);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblShowAll);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.listBoxGroup);
            this.Name = "FullListContactForm";
            this.Text = "FullListContactForm";
            this.Load += new System.EventHandler(this.FullListContactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGroup;
        private System.Windows.Forms.LinkLabel lblGroup;
        private System.Windows.Forms.LinkLabel lblShowAll;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}