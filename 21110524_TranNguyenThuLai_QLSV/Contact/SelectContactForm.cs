using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class SelectContactForm : Form
    {
        public SelectContactForm()
        {
            InitializeComponent();
        }
        public static string contactId { get; set; }
        public string user;
        CONTACT contact = new CONTACT();
        private void SelectContactForm_Load(object sender, EventArgs e)
        {
            fillDataGridView();
        }
        private void fillDataGridView()
        {
            SqlCommand cmd = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, group_id as GroupID, phone as Phone, address as Address, picture as Picture, email as Email from Contact where userid = @user");
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.DataSource = contact.selectContactList(cmd);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            contactId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;

        }
    }
}
