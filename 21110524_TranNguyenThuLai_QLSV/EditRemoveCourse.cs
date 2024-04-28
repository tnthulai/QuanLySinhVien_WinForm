using ClosedXML.Excel;
using iTextSharp.text.pdf;
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
    public partial class EditRemoveCourse : Form
    {
        public EditRemoveCourse()
        {
            InitializeComponent();
        }
        Course course = new Course();
        MY_DB mydb = new MY_DB();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                string id = cbbID.Text;
                string lable = txtLable.Text;
                int period = Convert.ToInt32(numPeriod.Value);
                if (period < 10)
                {
                    MessageBox.Show("Period  > 10", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string desc = txtDesc.Text;
                string semester = comboBoxSemester.SelectedValue.ToString().Trim();
                if (verif())
                {
                    if (course.updateCourse(id, lable, period, desc, semester))
                    {
                        MessageBox.Show("Edit successfully", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool verif()
        {
            if ((cbbID.Text.Trim() == "")
                        || (txtLable.Text.Trim() == "")
                        || (txtDesc.Text.Trim() == "")
                        )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string id = cbbID.Text;

                if ((MessageBox.Show("Are you sure you want to delete this course?", "DeleteCourse", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (course.deleteCourse(id))
                    {
                        cbbID.Text = "";
                        txtLable.Text = "";
                        txtDesc.Text = "";
                        numPeriod.Value = 0;

                        MessageBox.Show("Course Deleted", "DeleteCourse", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Course Not Deleted", "DeleteCourse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditRemoveCourse_Load(object sender, EventArgs e)
        {
            try
            {
                getSelectCouse();
                getSemesterSelect();
                LoadCourseInformation();
            }
            catch
            {


            }

        }
        private void getSemesterSelect()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT name FROM semester", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);

            

            comboBoxSemester.DataSource = table;
            comboBoxSemester.DisplayMember = "name";
            comboBoxSemester.ValueMember = "name";
        }

        

        private void getSelectCouse()
        {
            
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Course", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);

            cbbID.DataSource = table;
            cbbID.DisplayMember = "Id";
            cbbID.ValueMember = "Id";
        }
        private void LoadCourseInformation()
        {
            // Kiểm tra xem có giá trị được chọn trong combobox không
            if (cbbID.Text != null)
            {
                string id = cbbID.Text;
                

                try
                {
                    String query = "SELECT lable, period, description, semester FROM Course WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, mydb.getConnection);
                    cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    mydb.openConnection();

                    DataTable table = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(table);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (table.Rows.Count > 0)
                    {
                        txtLable.Text = table.Rows[0]["lable"].ToString();
                        numPeriod.Value = Convert.ToInt32(table.Rows[0]["period"]);
                        txtDesc.Text = table.Rows[0]["description"].ToString();
                        comboBoxSemester.SelectedValue = table.Rows[0]["semester"].ToString().Trim();
                    }
                    /*else
                    {
                        MessageBox.Show("Không tìm thấy thông tin cho ID đã chọn.");
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mydb.closeConnection();
                }
            }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourseInformation();
        }
    }
}
