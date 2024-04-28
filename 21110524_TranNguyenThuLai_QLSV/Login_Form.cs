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
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using Microsoft.ReportingServices.Diagnostics.Internal;
using _21110524_TranNguyenThuLai_QLSV.Contact;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }
       

        private void Login_Form_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../images/hcmute.jpg");
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if ((TextBoxUsername.Text.Trim() != "") && (TextBoxPassword.Text.Trim() != "") && (radAdmin.Checked) || (radStudent.Checked) || (radHR.Checked))
            {
                MY_DB db = new MY_DB();

                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                string role;
                if(radAdmin.Checked) {
                    role = "ADMIN";
                }
                else if (radHR.Checked)
                {
                    role = "HR";
                }
                else
                {
                    role = "STUDENT";
                }

                SqlCommand command = new SqlCommand("SELECT * FROM account WHERE username = @User AND password = @Pass AND status = 'Accepted' AND role = @role", db.getConnection);

                command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                command.Parameters.Add("@role", SqlDbType.VarChar).Value = role;

                adapter.SelectCommand = command;

                adapter.Fill(table);

                if ((table.Rows.Count > 0))
                {

                    this.DialogResult = DialogResult.OK;
                    ProgressBar fload = new ProgressBar();
                    if (fload.ShowDialog() == DialogResult.OK)
                    {
                        
                        Main_Form mainForm = new Main_Form();

                        mainForm.CheckAdminPermission(role);
                        mainForm.user = TextBoxUsername.Text;

                        mainForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password Or Wrong Permission", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /*if ((TextBoxUsername.Text.Trim() != "") && (TextBoxPassword.Text.Trim() != "") && (radAdmin.Checked) || (radStudent.Checked))
            {
                MY_DB db = new MY_DB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                SqlCommand command = new SqlCommand("SELECT * FROM log_in1 WHERE username = @User AND password = @Pass AND trangthai = 1 AND admin = @admin", db.getConnection);
                if (radAdmin.Checked)
                {
                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                    command.Parameters.Add("@admin", SqlDbType.Bit).Value = 1;
                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        this.AdditionalInfo = "ADMIN";
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Thong tin ADMIN sai", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    command.Parameters.Add("@User", SqlDbType.VarChar).Value = TextBoxUsername.Text;
                    command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBoxPassword.Text;
                    command.Parameters.Add("@admin", SqlDbType.Bit).Value = 0;
                    adapter.SelectCommand = command;

                    adapter.Fill(table);

                    if ((table.Rows.Count > 0))
                    {
                        AdditionalInfo = "USER";
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Thong tin USER sai", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chua nhap du thong tin", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            Form_Register_HR form_Register_HR = new Form_Register_HR();
            form_Register_HR.Show();

            /*Register_Form register_Form = new Register_Form();
            register_Form.Show();*/

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lkLblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
        }

        private void radStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (radStudent.Checked)
            {
                lblSignUp.Visible = false;
                label4.Visible = false;
            }
               


        }

        private void radHR_CheckedChanged(object sender, EventArgs e)
        {
            if (radHR.Checked)
            {
                lblSignUp.Visible = true;
                label4.Visible = true;
            }
                
        }

        private void radAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radAdmin.Checked)
            {
                lblSignUp.Visible = true;
                label4.Visible = true;

            }
                
        }
    }
}
