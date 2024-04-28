using Microsoft.Office.Interop.Excel;
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

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class EditAccountContactFrm : Form
    {
        MY_DB db = new MY_DB();
        public string username {  get; set; }
        public EditAccountContactFrm()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();
            MemoryStream pic = new MemoryStream();
            picImageAcc.Image.Save(pic, picImageAcc.Image.RawFormat);
            SqlCommand cmd = new SqlCommand("update account set fname=@fn, lname=@ln, picture=@pic where username =@usn", myDB.getConnection);
            cmd.Parameters.Add("@fn", SqlDbType.NVarChar).Value = txtFirstName.Text.Trim();
            cmd.Parameters.Add("@ln", SqlDbType.NVarChar).Value = txtLastName.Text.Trim();
            cmd.Parameters.Add("@usn", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            if (checkInfor())
            {
                myDB.openConnection();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  this.DialogResult = DialogResult.OK;
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
                MessageBox.Show("Please enter information or image!!!", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        private bool checkInfor()
        {
            if (txtFirstName.Text.Trim() == "" || txtLastName.Text.Trim() == "" || picImageAcc.Image==null)
            {
                return false;
            }
            return true;
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                picImageAcc.Image = Image.FromFile(opf.FileName);
            }
        }
    }
}
