using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class Form_Register_HR : Form
    {
        public Form_Register_HR()
        {
            InitializeComponent();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxImageHR.Image = Image.FromFile(opf.FileName);
            }
        }
        private bool checkUserExist(string usn)
        {
            try
            {
                MY_DB db = new MY_DB();
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from account where username = @username", db.getConnection);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = usn;
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    db.closeConnection();
                    return false;
                }
                db.closeConnection();
                return true;
            }
            catch
            {
                return false;
            }

        }
        private bool checkInfor()
        {
            if (txtUserName.Text.Trim() == "" || txtPass.Text.Trim() == "" || txtCfmPass.Text.Trim() == "" ||txtFname.Text.Trim() == ""|| txtLname.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();
            MemoryStream pic = new MemoryStream();
            pictureBoxImageHR.Image.Save(pic, pictureBoxImageHR.Image.RawFormat);
            SqlCommand cmd = new SqlCommand("Insert into account (fname,lname,username, password,email,picture,role,status) values (@fname,@lname,@us, @pass,@mail,@pic,'HR','Pending')", myDB.getConnection);
            cmd.Parameters.Add("@us", SqlDbType.VarChar).Value = txtUserName.Text.Trim();
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = txtPass.Text.Trim();
            cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
            cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = txtFname.Text;
            cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = txtLname.Text;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            if (checkInfor())
            {
                
                if (txtPass.Text != txtCfmPass.Text)
                {
                    MessageBox.Show("Password authentication is wrong, please check again", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.Text = "";
                    return;
                }
                
                if (checkUserExist(txtUserName.Text.ToString().Trim()) == false)
                {
                    MessageBox.Show("This username has already existed", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                myDB.openConnection();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Text = "";
                    txtPass.Text = "";
                    txtCfmPass.Text = "";
                    txtFname.Text = "";
                    txtLname.Text = "";
                    txtEmail.Text = "";
                   
                    myDB.closeConnection();
                }
                else
                {
                    MessageBox.Show("Registration error", "Create Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    myDB.closeConnection();
                }
            }
            else
            {
                MessageBox.Show("Please do not leave information blank", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
