using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class EditContactForm : Form
    {
        public string UserName { get; set; }
        public int groupid;
        GROUP group = new GROUP();
        CONTACT contact = new CONTACT();
        public EditContactForm()
        {
            InitializeComponent();
        }

        private void EditContactForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM groups WHERE userid=@userid");
            command.Parameters.Add("@userid", SqlDbType.Int).Value = UserName;
            comboBoxGroup.DataSource = group.getGroup(command);
            comboBoxGroup.DisplayMember = "name";
            comboBoxGroup.ValueMember = "id";
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM contact join groups on contact.group_id = groups.Id WHERE contact.id LIKE @id");
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = "%" + txtID.Text.Trim() + "%";
            DataTable table = contact.selectContactList(command);
            if (table.Rows.Count > 0)
            {
                txtFName.Text = table.Rows[0]["fname"].ToString();
                txtLName.Text = table.Rows[0]["lname"].ToString();
                comboBoxGroup.Text = table.Rows[0]["name"].ToString();
                txtPhone.Text = table.Rows[0]["phone"].ToString();
                txtAddress.Text = table.Rows[0]["address"].ToString();
                txtEmail.Text = table.Rows[0]["email"].ToString();


                byte[] pic;
                pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                PictureBoxStudentImage.Image = Image.FromStream(picture);
            }else
            {
                txtFName.Text = "";
                txtLName.Text = "";
                comboBoxGroup.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                PictureBoxStudentImage.Image = null;
            }
        }
        private void btnEditContact_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();
                string fname = txtFName.Text.Trim();
                string lname = txtLName.Text.Trim();
                int group_id = int.Parse(comboBoxGroup.SelectedValue.ToString());
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                MemoryStream pic = new MemoryStream();
                PictureBoxStudentImage.Image.Save(pic, PictureBoxStudentImage.Image.RawFormat);
                string userid = UserName;
                if (contact.checkID(id))
                {
                    MessageBox.Show("Đã tồn tại ID", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.IsMatch(fname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("First Name không hợp lệ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.IsMatch(lname, @"^[\p{L}\s]+$"))
                {
                    MessageBox.Show("Last Name không hợp lệ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (group.checkGroupExist(group_id))
                {
                    MessageBox.Show("Không tồn tại nhóm", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Regex.IsMatch(phone, @"^\d{10}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (contact.updateContact(id, fname, lname, group_id, phone, address, pic, email, userid))
                {
                    MessageBox.Show("Chỉnh sửa contact thành công!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa contact không thành công!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                PictureBoxStudentImage.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            AssignWorkForm assignWorkForm = new AssignWorkForm();
            assignWorkForm.contactID = txtID.Text;

            assignWorkForm.Show();
        }

        private void btnSelectContact_Click(object sender, EventArgs e)
        {
            SelectContactForm frm = new SelectContactForm();
            frm.user = UserName;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtID.Text = SelectContactForm.contactId;
            }
        }
    }
}
