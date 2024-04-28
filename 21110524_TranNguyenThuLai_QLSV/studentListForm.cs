using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class studentListForm : Form
    {
        public studentListForm()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void _21110524_studentListForm_Load(object sender, EventArgs e)
        {
            fillDataGridView();
        }

       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.stdTableAdapter.Fill(this.qLSVDBDataSetStudentListForm.std);
            fillDataGridView();
        }
        private void fillDataGridView()
        {
            SqlCommand cmd = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email from std");
            DataGVStudentList.ReadOnly = true;
            
            DataGVStudentList.RowTemplate.Height = 50;
            DataGVStudentList.DataSource = student.getStudents(cmd);
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)DataGVStudentList.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            DataGVStudentList.AllowUserToAddRows = false;
            lblTotal.Text = ("Total Student: " + DataGVStudentList.Rows.Count.ToString());
        }

        private void DataGVStudentList_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Select an Excel File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                     
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        

                        string id = worksheet.Cells[row, 1].Value.ToString();

                        if (!Regex.IsMatch(id, @"^\d+$"))
                        {
                            MessageBox.Show("Error ID Student!!!, Line " + row, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        else
                        {
                            int.TryParse(worksheet.Cells[row, 1].Value.ToString(), out int studentId);
                            STUDENT.Id = studentId;
                            
                        }

                        string fname = worksheet.Cells[row, 2].Value?.ToString();
                        if (!Regex.IsMatch(fname, @"^[\p{L}\s]+$"))
                        {
                            MessageBox.Show("Error First Name, Line " + row, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        else
                        {
                            STUDENT.FName = fname;
                            
                        }

                        string lname = worksheet.Cells[row, 3].Value?.ToString();
                        if (!Regex.IsMatch(lname, @"^[\p{L}\s]+$"))
                        {
                            MessageBox.Show("Error Last Name, Line " + row, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            STUDENT.LName = lname;
                            
                        }
                        DateTime.TryParseExact(worksheet.Cells[row, 4].Value?.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                        DateTime bdate = parsedDate;

                        int born_year = bdate.Year;
                        int this_year = DateTime.Now.Year;
                        //  sv tu 10-100,  co the thay doi
                        if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                        {
                            MessageBox.Show("The Student Age Must Be Between 10 and 100 year, Line " + row, "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }
                        else
                        {
                            STUDENT.Bdate = parsedDate;
                        }

                        STUDENT.Gender = worksheet.Cells[row, 5].Value?.ToString().Trim();
                        STUDENT.Phone = worksheet.Cells[row, 6].Value?.ToString();
                        STUDENT.Address = worksheet.Cells[row, 7].Value?.ToString();
                        
                        // byte[] imageBytes = Convert.FromBase64String(worksheet.Cells[row, 8].Value?.ToString());
                        STUDENT.Pic = null;
                        //new MemoryStream(imageBytes);
                        STUDENT.Email = STUDENT.Id.ToString() + "@student.hcmute.edu.vn";
                        

                        if (STUDENT.checkUserExist() == true)
                            STUDENT.AddStudent();
                    }

                    fillDataGridView();
                }
            }
        }

        

        private void DataGVStudentList_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDeleteStudentForm updateDeleteStudentForm = new UpdateDeleteStudentForm();
                updateDeleteStudentForm.txtID.Text = DataGVStudentList.CurrentRow.Cells[0].Value.ToString();
                updateDeleteStudentForm.txtFirstName.Text = DataGVStudentList.CurrentRow.Cells[1].Value.ToString();
                updateDeleteStudentForm.txtLastName.Text = DataGVStudentList.CurrentRow.Cells[2].Value.ToString();

                updateDeleteStudentForm.dateTimePicker1.Value = (DateTime)DataGVStudentList.CurrentRow.Cells[3].Value;



                if ((DataGVStudentList.CurrentRow.Cells[4].Value.ToString().Trim() == "Female"))
                {
                    updateDeleteStudentForm.radioButtonFemale.Checked = true;
                }
                else
                {
                    updateDeleteStudentForm.radioButtonMale.Checked = true;
                }
                updateDeleteStudentForm.txtPhone.Text = DataGVStudentList.CurrentRow.Cells[5].Value.ToString();
                updateDeleteStudentForm.txtEmail.Text = DataGVStudentList.CurrentRow.Cells[8].Value.ToString();
                updateDeleteStudentForm.txtAddress.Text = DataGVStudentList.CurrentRow.Cells[6].Value.ToString();

                byte[] pic;
                object value = DataGVStudentList.CurrentRow.Cells[7].Value;
                if (value != DBNull.Value)
                {
                    pic = (byte[])value;
                    MemoryStream picture = new MemoryStream(pic);
                    updateDeleteStudentForm.picBox.Image = Image.FromStream(picture);
                }
                else
                {
                    updateDeleteStudentForm.picBox.Image = null;
                }
                updateDeleteStudentForm.ShowDialog();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
