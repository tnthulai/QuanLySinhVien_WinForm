
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class ChangePasswordHR : Form
    {
        public ChangePasswordHR()
        {
            InitializeComponent();
        }
        public string username;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                MessageBox.Show("Error", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kiemTraPassword())
            {
                MessageBox.Show("Đổi password thành công", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
                MessageBox.Show("Đổi password thất bại", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool kiemTraPassword()
        {
            MY_DB mydb = new MY_DB();
            string oldPass="";
            SqlCommand cmd = new SqlCommand("SELECT password FROM account WHERE username = @username ", mydb.getConnection);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                oldPass = table.Rows[0]["password"].ToString().Trim();
            }
            if (oldPass == txtOldPass.Text.Trim() && txtNewPass.Text.Trim() == txtRePass.Text.Trim())
            {
                SqlCommand command = new SqlCommand("UPDATE account SET password=@password WHERE username=@username", mydb.getConnection);
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = txtNewPass.Text.Trim();
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                mydb.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            else return false;
        }
        public bool verify()
        {
            if (txtOldPass.Text == "" || txtNewPass.Text == "" || txtRePass.Text == "")
                return true;
            else return false;
        }

        private void ChangePasswordHR_Load(object sender, EventArgs e)
        {

        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
