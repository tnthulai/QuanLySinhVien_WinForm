
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
    public partial class AddNewCourse : Form
    {
        public AddNewCourse()
        {
            InitializeComponent();
        }

         MY_DB mydb = new MY_DB();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                string id = txtID.Text;
                string lable = txtLable.Text;
                int period = Convert.ToInt32(numPeriod.Value);
                if(period < 10)
                {
                    MessageBox.Show("Period  > 10", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string desc = txtDesc.Text;
                string semester = comboBoxSemester.SelectedValue.ToString().Trim();
                if (verif())
                {
                    if (course.insertCourse(id, lable, period, desc, semester))
                    {
                        MessageBox.Show("New course added successfully", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        bool verif()
        {
            if ((txtID.Text.Trim() == "")
                        || (txtLable.Text.Trim() == "")
                        || (txtDesc.Text.Trim() == "")
                        || (numPeriod.Text.Trim() == "")
                        )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewCourse_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT name FROM semester", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            comboBoxSemester.DataSource = table;

            comboBoxSemester.DisplayMember = "name";
            comboBoxSemester.ValueMember = "name";
        }
    }
}
