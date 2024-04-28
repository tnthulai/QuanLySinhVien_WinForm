using _21110524_TranNguyenThuLai_QLSV;
using _21110524_TranNguyenThuLai_QLSV.Contact;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Image = System.Drawing.Image;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    public partial class Contact_GroupForm : Form
    {
        public Contact_GroupForm()
        {
            InitializeComponent();
        }
        public string user;
        GROUP group = new GROUP();
        CONTACT contact = new CONTACT();
        MY_DB mydb = new MY_DB();
        private void Contact_GroupForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + user;

            setAvatar();
            fillCombobox();
            
        }

        private void setAvatar()
        {
            SqlCommand cmd = new SqlCommand("SELECT picture FROM account where username = @username ", mydb.getConnection);
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = user;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            byte[] pic;
            if (table.Rows[0]["picture"] != DBNull.Value)
            {
                pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                picBox.Image = Image.FromStream(picture);
            }
            else
            {
                picBox.Image = null;
            }

        }

        private void fillCombobox()
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, name FROM groups where userid = @user ", mydb.getConnection);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = table;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "Id";

        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            AddContactForm addContactForm = new AddContactForm();
            addContactForm.UserName = user;
            addContactForm.ShowDialog();
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            EditContactForm editContactForm = new EditContactForm();
            editContactForm.UserName = user;
            editContactForm.ShowDialog();
        }

        private void btnRemoveContact_Click(object sender, EventArgs e)
        {
            string id = txtEnterContact.Text.Trim();
            if (contact.checkID(id))
            {
                MessageBox.Show("Không tồn tại contact", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (contact.deleteContact(id))
            {
                MessageBox.Show("Xoá contact thành công", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xoá contact không thành công", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowFullListContact_Click(object sender, EventArgs e)
        {
            FullListContactForm fullListContactForm = new FullListContactForm();
            fullListContactForm.user = user;
            fullListContactForm.ShowDialog();

        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEnterGroupName.Text != "")
                {
                    string name = txtEnterGroupName.Text.Trim();
                    if (group.insertGroup(name, user))
                    {
                        txtEnterGroupName.Text = "";
                        fillCombobox();
                        MessageBox.Show("New group added successfully", "Add group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add group", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue.ToString().Trim());
                if (txtNewName.Text != null)
                {
                    string name = txtNewName.Text.Trim();
                    if (group.updateGroup(id, name))
                    {
                        txtNewName.Text = "";
                        fillCombobox();
                        MessageBox.Show("Updated group successfully", "Update group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Update group", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Update group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue.ToString().Trim());
                if ((MessageBox.Show("Are you sure you want to delete this group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (group.deleteGroup(id))
                    {
                        fillCombobox();
                        MessageBox.Show("Deleteed group successfully", "Delete group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Delete group", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSelectContact_Click(object sender, EventArgs e)
        {
            SelectContactForm frm = new SelectContactForm();
            frm.user = user;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtEnterContact.Text = SelectContactForm.contactId;
            }
        }

        private void lblChangePass_Click(object sender, EventArgs e)
        {
            ChangePasswordHR changePasswordHR = new ChangePasswordHR();
            changePasswordHR.username = user;
            changePasswordHR.ShowDialog();
        }

        private void lblEditAcc_Click(object sender, EventArgs e)
        {
            EditAccountContactFrm editAccountContactFrm = new EditAccountContactFrm();
            editAccountContactFrm.picImageAcc.Image = picBox.Image;
            editAccountContactFrm.username = user;
            if(editAccountContactFrm.ShowDialog()==DialogResult.OK)
            {
                setAvatar();
            }
        }
    }
}
