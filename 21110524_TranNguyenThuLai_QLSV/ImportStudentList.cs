using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class ImportStudentList : Form
    {
        public ImportStudentList()
        {
            InitializeComponent();
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

                    DataTable dt = new DataTable();

                    dt.Columns.Add("ID");
                    dt.Columns.Add("First Name");
                    dt.Columns.Add("Last Name");
                    dt.Columns.Add("Birth Date", typeof(DateTime));
                    dt.Columns.Add("Email");
                    dt.Columns.Add("Gender");
                    dt.Columns.Add("Phone");
                    dt.Columns.Add("Address");
                    dt.Columns.Add("Picture");
                    

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        DataRow newRow = dt.Rows.Add();
                        newRow["ID"] = worksheet.Cells[row, 1].Value.ToString();
                        int.TryParse(worksheet.Cells[row, 1].Value.ToString(), out int studentId);
                        STUDENT.Id = studentId;
                        newRow["First Name"] = worksheet.Cells[row, 2].Value?.ToString();
                        STUDENT.FName = worksheet.Cells[row, 2].Value?.ToString();
                        newRow["Last Name"] = worksheet.Cells[row, 3].Value?.ToString();
                        STUDENT.LName = worksheet.Cells[row, 3].Value?.ToString();
                        DateTime.TryParseExact(worksheet.Cells[row, 4].Value?.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
                        newRow["Birth Date"] = parsedDate.ToShortDateString();
                       
                        STUDENT.Bdate = parsedDate;
                        STUDENT.Email = STUDENT.Id.ToString() + "@student.hcmute.edu.vn";
                        newRow["Email"] = STUDENT.Email;


                        newRow["Gender"] = worksheet.Cells[row, 6].Value?.ToString();
                        STUDENT.Gender = worksheet.Cells[row, 6].Value?.ToString().Trim();
                        newRow["Phone"] = worksheet.Cells[row, 7].Value?.ToString();
                        STUDENT.Phone = worksheet.Cells[row, 7].Value?.ToString();
                        newRow["Address"] = worksheet.Cells[row, 8].Value?.ToString();
                        STUDENT.Address = worksheet.Cells[row, 8].Value?.ToString();
                        newRow["Picture"] = worksheet.Cells[row, 9].Value?.ToString();

                        // byte[] imageBytes = Convert.FromBase64String(worksheet.Cells[row, 8].Value?.ToString());
                        STUDENT.Pic = null;
                        //new MemoryStream(imageBytes);


                        if (STUDENT.checkUserExist() == true)
                            STUDENT.AddStudent();

                    }

                    DataGVStudentList.DataSource = dt;
                }
            }
            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.Title = "Chọn một file Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MY_DB mydb = new MY_DB();
                string fileName = openFileDialog.FileName;
                ImportExcelToDatabase(fileName);

                this.studentTableAdapter .Fill(this.qLSVDBDataSetImportFile.Student);
                SqlCommand cmd = new SqlCommand("Select * from Student");
                DataGVStudentList.ReadOnly = true;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                DataGVStudentList.RowTemplate.Height = 50;
                cmd.Connection = mydb.getConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataGVStudentList.DataSource = table;
                picCol = (DataGridViewImageColumn)DataGVStudentList.Columns[8];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                DataGVStudentList.AllowUserToAddRows = false;

                //importFromExcel(fileName, DataGVStudentList);
            }*/
        }
       /* private void ImportExcelToDatabase(string fileName)
        {
            
           
                MY_DB mydb = new MY_DB();

                mydb.openConnection();

                SqlCommand command = new SqlCommand("INSERT INTO Student (id, fname, lname, bdate, email, gender, phone, address, picture)" +
                " VALUES (@id,@fname, @lname, @bdate, @email, @gender, @phone, @address, @pic)", mydb.getConnection);

                Microsoft.Office.Interop.Excel.Application excel;
                // Tạo đối tượng Excel và mở workbook từ file Excel
                excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excel.Workbooks.Open(fileName);
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            try
            {
                // Vòng lặp để đọc dữ liệu từ file Excel và lưu vào cơ sở dữ liệu
                int rowCount = worksheet.UsedRange.Rows.Count;

                for (int i = 2; i <= rowCount; i++)
                {
                    string maSV = (worksheet.Cells[i, 1] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string hoTenLot = (worksheet.Cells[i, 2] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string ten = (worksheet.Cells[i, 3] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string ngaySinh = (worksheet.Cells[i, 4] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string email = (worksheet.Cells[i, 5] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string gioiTinh = (worksheet.Cells[i, 6] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string phone = (worksheet.Cells[i, 7] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string diaChi = (worksheet.Cells[i, 8] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();
                    string hinhAnh = (worksheet.Cells[i, 9] as Microsoft.Office.Interop.Excel.Range)?.Value2?.ToString();

                    // Vì không có hình ảnh trong dữ liệu, bạn có thể bỏ qua hoặc xử lý tương ứng với hình ảnh ở đây

                    // Tiến hành thêm dữ liệu vào cơ sở dữ liệu
                    command.Parameters.AddWithValue("@id", maSV);
                    command.Parameters.AddWithValue("@fname", hoTenLot);
                    command.Parameters.AddWithValue("@lname", ten);
                    command.Parameters.AddWithValue("@bdate", ngaySinh);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@gender", gioiTinh);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", diaChi);
                    command.Parameters.AddWithValue("@pic", hinhAnh);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Dữ liệu đã được nhập vào cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng workbook và ứng dụng Excel
                workbook.Close(false);
                excel.Quit();
            }
        }*/


        /*private void importFromExcel(string fileName, DataGridView dataGridView)
        {
            Microsoft.Office.Interop.Excel.Application excel;

            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excel.Workbooks.Open(fileName);
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];

                int rowCount = worksheet.UsedRange.Rows.Count;
                int colCount = worksheet.UsedRange.Columns.Count;

                // Clear existing rows and columns
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                // Add columns based on the number of columns in Excel
                for (int j = 1; j <= colCount; j++)
                {
                    dataGridView.Columns.Add("Column" + j, "Column" + j);
                }

                // Thêm hàng vào DataGridView và điền dữ liệu từ file Excel
                for (int i = 1; i <= rowCount; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    for (int j = 1; j <= colCount; j++)
                    {
                        if (worksheet.Cells[i, j] != null && worksheet.Cells[i, j].Value2 != null)
                        {
                            row.Cells.Add(new DataGridViewTextBoxCell()
                            {
                                Value = worksheet.Cells[i, j].Value2.ToString()
                            });
                        }
                        else
                        {
                            row.Cells.Add(new DataGridViewTextBoxCell()
                            {
                                Value = ""
                            });
                        }
                    }

                    // Thêm hàng vào cuối DataGridView
                    dataGridView.Rows.Add(row);
                }

                workbook.Close();
                excel.Quit();
                MessageBox.Show("Import dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        /*private void importFromExcel(string fileName, DataGridView dataGridView)
        {
            DataTable dt = null;
            
            foreach (DataRow row in dt.Rows)
            {
                MY_DB mydb = new MY_DB();
                 
                
                SqlCommand command = new SqlCommand("INSERT INTO std (id, fname, lname, bdate, gender, phone, address, picture)" +
                " VALUES (@id,@fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", mydb.getConnection);
                command.Parameters.AddWithValue("@id", row["Mã SV"].ToString()).Value = Id;
                command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
                command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
                command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

                mydb.openConnection();

                if ((command.ExecuteNonQuery() == 1))
                {
                    mydb.closeConnection();
                }
                else
                {
                    mydb.closeConnection();
                }
            }
        }
*/
        private void ImportStudentList_Load(object sender, EventArgs e)
        {
            

        }
    }
}
