using _21110571_PhamTrongNhan_QLSV.Contact;
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
    public partial class FullListContactForm : Form
    {
        public FullListContactForm()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        GROUP group = new GROUP();
        CONTACT contact = new CONTACT();

        public string user;
        private void FullListContactForm_Load(object sender, EventArgs e)
        {
            fillListBoxGroup();
            fillFullData();
        }
        private void fillListBoxGroup()
        {
            listBoxGroup.Items.Clear();

            string query = @"SELECT Id, name
                    FROM groups
                    WHERE userid = @user";

            SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;

            mydb.openConnection();
            /*DataTable table = group.getGroup(cmd);
            
            listBoxGroup.DataSource = table;
            listBoxGroup.DisplayMember = "name";
            listBoxGroup.ValueMember = "Id";*/

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"].ToString());
                    string name = reader["name"].ToString();

                    GROUP group = new GROUP(id, name);
                    listBoxGroup.Items.Add(group);
                }
            }
        }
        private void fillData(int groupid)
        {
            SqlCommand cmd = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName,group_id as GroupID, phone as Phone, address as Address, picture as Picture, email as Email from Contact where userid = @user AND group_id = @group_id");
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            cmd.Parameters.Add("@group_id", SqlDbType.VarChar).Value = groupid;

            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.DataSource = contact.selectContactList(cmd);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void fillFullData()
        {
            SqlCommand cmd = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName,group_id as GroupID, phone as Phone, address as Address, picture as Picture, email as Email from Contact where userid = @user");
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            
            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.DataSource = contact.selectContactList(cmd);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void listBoxGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            GROUP group = (GROUP)listBoxGroup.SelectedItem;
            int id = group.ID;
            fillData(id);
        }

        private void lblShowAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fillFullData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            AssignmentListForm assignment = new AssignmentListForm();
            assignment.contactID = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            assignment.Show();
        }
    }
}
