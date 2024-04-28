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
using static _21110524_TranNguyenThuLai_QLSV.ForgotPassword;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class ReSetPassword : Form
    {
        string txtEmail = DataStorage.TextBoxValue;
        public ReSetPassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();
            SqlCommand cmd = new SqlCommand("UPDATE log_in SET password=@pass WHERE email = @email", myDB.getConnection);
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = txtRePassword.Text.ToString().Trim();
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.ToString().Trim();

            if (checkInfor())
            {
                if (txtPassword.Text.ToString().Trim() != txtRePassword.Text.ToString().Trim())
                {
                    MessageBox.Show("Password authentication is wrong, please check again", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                    return;
                }
                myDB.openConnection();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully updated", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Updated error", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myDB.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Please do not leave information blank", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private bool checkInfor()
        {
            if (txtPassword.Text.Trim() == "" || txtRePassword.Text.Trim() == "")
                return false;
            return true;
        }
    }
}
