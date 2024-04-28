using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using _21110524_TranNguyenThuLai_QLSV;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Threading;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class Register_Form : Form
    {
        MY_DB myDB = new MY_DB();
        int time = 60;
        string randomCode;
        public static string to;
        public Register_Form()
        {
            InitializeComponent();
        }

        private void Register_Form_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("../../images/spkt.jpg");
            lblNotice.Text = "";
        }
    
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetCode_Click(object sender, EventArgs e)
        {
            timerSendCode.Start();
            if (TextBoxEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your email address", "Add Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra email đã tồn tại hay chưa
            if (existEmail() == true)
            {
                MessageBox.Show("Email already used, please enter another email",
                    "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo mã ngẫu nhiên và gửi email
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();

            string to = TextBoxEmail.Text.Trim();
            from = "nguyentranthulai@gmail.com"; // Email của bạn
            pass = "undr imtc cmvg dgpg";

            messageBody = "Code: " + randomCode;

            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Account creation code";

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
            if (TextBoxCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your code", "Forget Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (randomCode == TextBoxCode.Text.ToString())
            {
                to = TextBoxEmail.Text;
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
            time--;
           
            if (time >= 0)
            {
                btnGetCode.Enabled = false;
                lblNotice.Text = "Resend code in " + time + " second";
            }
            else
            {
                lblNotice.Text = "";
                btnGetCode.Enabled = true;
                timerSendCode.Enabled = false;
            }

        }


        private bool existEmail()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from log_in where email = ' " + TextBoxEmail.Text.Trim() + "'", myDB.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                if (tb.Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Add Account",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }



        private void btn_OK_Click(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();
            SqlCommand cmd = new SqlCommand("Insert into log_in (username, password, email, status) values (@us, @pass, @email, 'Pending')", myDB.getConnection);
            cmd.Parameters.Add("@us", SqlDbType.Char).Value = TextBoxUsername.Text;
            cmd.Parameters.Add("@pass", SqlDbType.Char).Value = TextBoxPassword.Text;
            cmd.Parameters.Add("@email", SqlDbType.NChar).Value = TextBoxEmail.Text;

            if (chekcInfor())
            {
                if (checkCode() == false)
                {
                    return;
                }
                if (TextBoxPassword.Text != TextBoxRePassword.Text)
                {
                    MessageBox.Show("Password authentication is wrong, please check again", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBoxPassword.Text = "";
                    return;
                }
                myDB.openConnection();
                if (checkUserExist(TextBoxUsername.Text.ToString().Trim()) == false)
                {

                    MessageBox.Show("This username has already existed", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account successfully created", "Create Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxUsername.Text = "";
                    TextBoxPassword.Text = "";
                    TextBoxRePassword.Text = "";
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


        private bool checkUserExist(string usn)
        {
            MY_DB db = new MY_DB();
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from log_in where username = @username", db.getConnection);
            cmd.Parameters.Add("@username", SqlDbType.NChar).Value = usn;
            var result = cmd.ExecuteReader();

            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }
        private bool chekcInfor()
        {
            if (TextBoxUsername.Text.Trim() == "" || TextBoxPassword.Text.Trim() == "" || TextBoxRePassword.Text.Trim() == "" || TextBoxCode.Text.Trim() == "")
                return false;
            return true;
        }

        private void lblNotice_Click(object sender, EventArgs e)
        {

        }
    }
}


