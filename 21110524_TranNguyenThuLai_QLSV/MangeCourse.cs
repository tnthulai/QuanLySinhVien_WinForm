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
using Xceed.Words.NET;
using Microsoft.Office.Interop.Excel;
using Document = iTextSharp.text.Document;
using System.Drawing.Printing;
using Xceed.Document.NET;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class MangeCourse : Form
    {
        public MangeCourse()
        {
            InitializeComponent();
        }

        Course course= new Course();
        MY_DB mydb = new MY_DB();
        private void MangeCourse_Load(object sender, EventArgs e)
        {

            getSemesterSelect();
            pos = 0;
            showData(0);

        }

        private void getSemesterSelect()
        {
            SqlCommand cmd = new SqlCommand("SELECT name FROM semester", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);

            DataRow allRow = table.NewRow();
            allRow["name"] = "All";
            table.Rows.InsertAt(allRow, 0);

            comboBoxSemester.DataSource = table;
            comboBoxSemester.DisplayMember = "name";
            comboBoxSemester.ValueMember = "name";
        }
        private void comboBoxSemester_SelectedValueChanged(object sender, EventArgs e)
        {
            string name = comboBoxSemester.SelectedValue.ToString().Trim();
            String query = null;
            SqlCommand cmd = new SqlCommand();
            if (name != null && name == "All")
            {
                query = "Select * from Course";
                cmd.CommandText = query;

            }
            else
            {
                query = "SELECT * FROM Course WHERE semester = @semester";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@semester", name);
            }
            cmd.Connection = mydb.getConnection;

            fillDataGrid(cmd);
        }

        public void fillDataGrid(SqlCommand cmd)
        {
            dataGridViewCourse.ReadOnly = true;
            dataGridViewCourse.RowTemplate.Height = 50;
            dataGridViewCourse.DataSource = course.getCourse(cmd);
            dataGridViewCourse.AllowUserToAddRows = false;
            lblTotal.Text = ("Total Course: " + dataGridViewCourse.Rows.Count.ToString());
            dataGridViewCourse.Columns["Id"].HeaderText = "Course ID";
            dataGridViewCourse.Columns["lable"].HeaderText = "Name";
            dataGridViewCourse.Columns["period"].HeaderText = "Time";
            dataGridViewCourse.Columns["description"].HeaderText = "Decription";
            dataGridViewCourse.Columns["semester"].HeaderText = "Semester";
        }

        private void dataGridViewCourse_DoubleClick(object sender, EventArgs e)
        {
            Course_Student course_Student = new Course_Student();
            course_Student.textBoxCourseName.Text = dataGridViewCourse.CurrentRow.Cells[1].Value.ToString().Trim();
            course_Student.labelSemester.Text = "Semester: " + dataGridViewCourse.CurrentRow.Cells[4].Value.ToString();

            course_Student.ShowDialog();
        }

        private void dataGridViewCourse_Click(object sender, EventArgs e)
        {
            pos = dataGridViewCourse.CurrentCell.RowIndex;
            showData(pos);
            /*txtID.Text = dataGridViewCourse.CurrentRow.Cells[0].Value.ToString();
            txtLable.Text = dataGridViewCourse.CurrentRow.Cells[1].Value.ToString();
            numPeriod.Value = Convert.ToDecimal(dataGridViewCourse.CurrentRow.Cells[2].Value.ToString());
            txtDesc.Text = dataGridViewCourse.CurrentRow.Cells[3].Value.ToString();
            comboBoxSemester.SelectedValue = dataGridViewCourse.CurrentRow.Cells[4].Value.ToString();*/
        }
        private void showData(int pos)
        {
            try
            {
                txtID.Text = dataGridViewCourse.Rows[pos].Cells[0].Value.ToString();
                txtLable.Text = dataGridViewCourse.Rows[pos].Cells[1].Value.ToString();
                numPeriod.Value = Convert.ToInt32(dataGridViewCourse.Rows[pos].Cells[2].Value);
                txtDesc.Text = dataGridViewCourse.Rows[pos].Cells[3].Value.ToString();
                comboBoxSemester.Text = dataGridViewCourse.Rows[pos].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Course course = new Course();
                string id = txtID.Text;
                string lable = txtLable.Text;
                int period = Convert.ToInt32(numPeriod.Value);
                if (period < 10)
                {
                    MessageBox.Show("Period  > 10", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string desc = txtDesc.Text;
                string semester = comboBoxSemester.SelectedValue.ToString();
                if (verif())
                {
                    if (semester != "All" && semester != null)
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
                        MessageBox.Show("Semester Incorrect", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                string id = txtID.Text;
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
                    if (semester != "All" && semester != null)
                    {
                        if (course.updateCourse(id, lable, period, desc, semester))
                        {
                            MessageBox.Show("Edit successfully", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SqlCommand cmd = new SqlCommand("Select * from Course");
                            fillDataGrid(cmd);
                        }
                        else
                        {
                            MessageBox.Show("Error", "Edit course", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    } else
                    {
                        MessageBox.Show("Semester Incorrect", "Add course", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if ((txtID.Text.Trim() == "")
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
                string id = txtID.Text;

                if ((MessageBox.Show("Are you sure you want to delete this student?", "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    if (course.deleteCourse(id))
                    {
                        txtID.Text = "";
                        txtLable.Text = "";
                        txtDesc.Text = "";
                        numPeriod.Value = 0;

                        MessageBox.Show("Course Deleted", "DeleteCourse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SqlCommand cmd = new SqlCommand("Select * from Course");
                        fillDataGrid(cmd);
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Course where concat(id,lable,period,description) like '%" + txtFind.Text.Trim() + "%'");
            fillDataGrid(cmd);
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (saveFileWord.ShowDialog() == DialogResult.OK)
                xuatFileWord(dataGridViewCourse, saveFileWord.FileName);
        }
        private void xuatFileWord(DataGridView dataGridView, string fileName)
        {
            try
            {
                using (DocX document = DocX.Create(fileName))
                {
                    Table table = document.AddTable(dataGridView.RowCount + 1, dataGridView.ColumnCount);

                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        table.Rows[0].Cells[i].Paragraphs[0].Append(dataGridView.Columns[i].HeaderText);
                    }

                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            if (dataGridView.Rows[i].Cells[j].Value != null)
                            {
                                table.Rows[i + 1].Cells[j].Paragraphs[0].Append(dataGridView.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                    }
                    document.InsertTable(table);
                    document.Save();
                }
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileExcel.ShowDialog() == DialogResult.OK)
                xuatFileExcel(dataGridViewCourse, saveFileExcel.FileName);
        }
        private void xuatFileExcel(DataGridView dataGVPrint, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excel.Application.Workbooks.Add(Type.Missing);
                Worksheet worksheet = (Worksheet)workbook.ActiveSheet;
                excel.Columns.ColumnWidth = 25;

                for (int i = 0; i < dataGVPrint.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGVPrint.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGVPrint.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGVPrint.Columns.Count; j++)
                    {
                        if (dataGVPrint.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGVPrint.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (saveFilePdf.ShowDialog() == DialogResult.OK)
                xuatFilePDF(dataGridViewCourse, saveFilePdf.FileName);
        }
        private void xuatFilePDF(DataGridView dataGridView, string fileName)
        {
            try
            {
                Document document = new Document();

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                document.Open();

                PdfPTable table = new PdfPTable(dataGridView.ColumnCount);

                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    table.AddCell(dataGridView.Columns[i].HeaderText);
                }

                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                        {
                            table.AddCell(dataGridView.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }
                document.Add(table);
                document.Close();

                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            if (saveFileText.ShowDialog() == DialogResult.OK)
                xuatFileText(dataGridViewCourse, saveFileText.FileName);
        }
        private void xuatFileText(DataGridView dataGridView, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        sw.Write(dataGridView.Columns[i].HeaderText);
                        if (i < dataGridView.ColumnCount - 1)
                            sw.Write("\t");
                    }
                    sw.WriteLine();

                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            if (dataGridView.Rows[i].Cells[j].Value != null)
                            {
                                sw.Write(dataGridView.Rows[i].Cells[j].Value.ToString());
                            }
                            if (j < dataGridView.ColumnCount - 1)
                                sw.Write("\t");
                        }
                        sw.WriteLine();
                    }
                }
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int pos;

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (pos == 0)
            {
                MessageBox.Show("Đang hiển thị dữ liệu tại vị trí đầu tiên!", "Show data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pos = 0;
            showData(pos);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if(pos == 0)
            {
                MessageBox.Show("Đang hiển thị dữ liệu tại vị trí đầu tiên!", "Show data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pos = pos - 1;
            showData(pos);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pos == dataGridViewCourse.RowCount - 1)
            {
                MessageBox.Show("Đang hiển thị dữ liệu tại vị trí cuối cùng!", "Show data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pos = pos + 1;
            showData(pos);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (pos == dataGridViewCourse.RowCount - 1)
            {
                MessageBox.Show("Đang hiển thị dữ liệu tại vị trí cuối cùng!", "Show data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            pos = dataGridViewCourse.RowCount - 1;
            showData(pos);
        }
    }
}
