using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class ForgotPassword : Form
    {
        int time = 60;
        string randomCode;
        public static string to;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            if (txtEmailForgotPass.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email không tồn tại
            if (existEmail() == false)
            {
                MessageBox.Show("Email doesn't already, please enter another email", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo mã ngẫu nhiên và gửi email
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();

            string to = txtEmailForgotPass.Text.ToString().Trim();
            from = "nguyentranthulai@gmail.com"; // Email của bạn
            pass = "opta rrst uesb fdqc";

            messageBody = "Code: " + randomCode;

            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Creation code successful";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successfully", "Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timerSendCode.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkCode()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "Forget Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (randomCode.Trim() == txtCode.Text.ToString().Trim())
            {
                to = txtEmailForgotPass.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Wrong code");
                return false;
            }
        }

        private void timerSendCode_Tick(object sender, EventArgs e)
        {

            if (time >= 0)
            {
                btnSendCode.Enabled = false;
                lblNotice.Text = "Resend code in " + time + "second.";
                time--;
            }
            else
            {
                lblNotice.Text = "";
                btnSendCode.Enabled = true;
                timerSendCode.Enabled = false;
            }
        }
        private bool existEmail()
        {
            try
            {
                MY_DB myDB = new MY_DB();
                SqlCommand cmd = new SqlCommand("select * from account where email = '" + txtEmailForgotPass.Text.ToString().Trim() + "'", myDB.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                if (tb.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (checkCode() == false)
            {
                return;
            }
            else
            {
                MessageBox.Show("Verify successfully", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataStorage.TextBoxValue = txtEmailForgotPass.Text;
                this.Close();
                ReSetPassword resetPassword = new ReSetPassword();
                resetPassword.Show();
            }
        }
        public static class DataStorage
        {
            public static string TextBoxValue { get; set; }
        }
    }
}
