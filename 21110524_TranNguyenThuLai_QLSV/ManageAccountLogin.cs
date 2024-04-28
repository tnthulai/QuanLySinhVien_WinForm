using DocumentFormat.OpenXml.Office2010.CustomUI;
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

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class ManageAccountLogin : Form
    {
        public ManageAccountLogin()
        {
            InitializeComponent();
        }
        User user = new User(); 
        
        private void ManageAccountLogin_Load(object sender, EventArgs e)
        {
            
            
            SqlCommand cmd = new SqlCommand("select ac.fname as \"First Name\", ac.lname as \"Last Name\", ac.username as \"UserName\",ac.password as \"Password\", ac.email as Email,ac.picture as Picture, ac.role as Role,ac.status as Status from account ac");
            fillDataGrid(cmd);

        }
        public void fillDataGrid(SqlCommand cmd)
        {
            dataUser.ReadOnly = true;
            dataUser.RowTemplate.Height = 50;
            DataTable dt = user.getUser(cmd);

            // Thay đổi cột mật khẩu thành chuỗi '*' ẩn
            foreach (DataRow row in dt.Rows)
            {
                row["Password"] = "**********";
            }

            dataUser.DataSource = dt;
            dataUser.AllowUserToAddRows = false;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataUser.Columns[5];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            lblTotal.Text = ("Total Users: " + dataUser.Rows.Count.ToString());
        }

        private void dataUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataUser_DoubleClick(object sender, EventArgs e)
        {
            txtUsername.Text = dataUser.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataUser.CurrentRow.Cells[4].Value.ToString();
            txtAdmin.Text = dataUser.CurrentRow.Cells[6].Value.ToString();
            txtStatus.Text = dataUser.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           


                string username = txtUsername.Text;
                user.Confirm(username);

                
                // Làm mới dữ liệu trong DataGridView
                SqlCommand cmd = new SqlCommand("select ac.fname as \"First Name\", ac.lname as \"Last Name\", ac.username as \"UserName\",ac.password as \"Password\", ac.email,ac.picture, ac.role,ac.status from account ac");
                fillDataGrid(cmd);
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            

                string username = txtUsername.Text;
                user.deleteUser(username);


                // Làm mới dữ liệu trong DataGridView
                SqlCommand cmd = new SqlCommand("select ac.fname as \"First Name\", ac.lname as \"Last Name\", ac.username as \"UserName\",ac.password as \"Password\", ac.email,ac.picture, ac.role,ac.status from account ac");
                fillDataGrid(cmd);
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select ac.fname as \"First Name\", ac.lname as \"Last Name\", ac.username as \"UserName\",ac.password as \"Password\", ac.email,ac.picture, ac.role,ac.status from account ac");
            fillDataGrid(cmd);
        }
    }
}
