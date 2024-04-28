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
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Document = iTextSharp.text.Document;
using System.Drawing.Printing;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }
        STUDENT student = new STUDENT();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email FROM std");
            fillGrid(command);
            voHieuHoa();
            filter();
            
        }

        private void voHieuHoa()
        {
            datePickerToBirth.Enabled = false;
            datePickerFromBirth.Enabled = false;
            datePickerFromBirth.Value = DateTime.Now;
            datePickerToBirth.Value = DateTime.Now;
            radFemale.Enabled = false;
            radMale.Enabled = false;
            radFemale.Checked = false;
            radMale.Checked = false;
        }

        private void fillGrid(SqlCommand command)
        {
            
            try
            {
                dataGVPrint.ReadOnly = true;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGVPrint.RowTemplate.Height = 80;
                dataGVPrint.DataSource = student.getStudents(command);
                picCol = (DataGridViewImageColumn)dataGVPrint.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGVPrint.AllowUserToAddRows = false;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void filter()
        {

            if (chkGender.Checked && chkBirth.Checked)
            {
                datePickerFromBirth.Enabled = true;
                datePickerToBirth.Enabled = true;
                radMale.Enabled = true;
                radFemale.Enabled = true;
                String gender = "Male";
                String fromBirth = datePickerFromBirth.Text.ToString().Trim();
                String toBirth = datePickerToBirth.Text.ToString().Trim();
                if (!radMale.Checked && !radFemale.Checked || radMale.Checked)
                {
                    radMale.Checked = true;
                }
                else
                {
                    gender = "Female";
                }
                SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email FROM std WHERE gender = '" + gender.ToString().Trim() + "' AND bdate >= '" +
                        fromBirth.ToString().Trim() + "' AND bdate <= '" + toBirth.ToString().Trim() + "'");
                fillGrid(command);
            }
            else if (chkGender.Checked)
            {
                datePickerFromBirth.Enabled = false;
                datePickerToBirth.Enabled = false;
                filterGender();
            }
            else if (chkBirth.Checked)
            {
                radMale.Enabled = false;
                radFemale.Enabled = false;
                filterBirth();
            }
            else
            {
                SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email FROM std");
                fillGrid(command);
                voHieuHoa();
            }
        }

        private void filterBirth()
        {
            if (chkBirth.Checked)
            {
                datePickerFromBirth.Enabled = true;
                datePickerToBirth.Enabled = true;
                String fromBirth = datePickerFromBirth.Text.ToString().Trim();
                String toBirth = datePickerToBirth.Text.ToString().Trim();
                SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email FROM std WHERE bdate >= '" + fromBirth.ToString().Trim() + "' AND bdate <= '" + toBirth.ToString().Trim() + "'");
                fillGrid(command);
            }
            else
            {
                datePickerFromBirth.Enabled = false;
                datePickerToBirth.Enabled = false;
                datePickerFromBirth.Value = DateTime.Now;
                datePickerToBirth.Value = DateTime.Now;
                SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as EmailFROM std");
                fillGrid(command);
            }
        }

        private void filterGender()
        {
            String gender = "Male";

            if (chkGender.Checked)
            {
                radMale.Enabled = true;
                radFemale.Enabled = true;
                if (!radMale.Checked && !radFemale.Checked || radMale.Checked)
                {
                    radMale.Checked = true;
                }
                else
                {
                    gender = "Female";
                }
                SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email FROM std WHERE gender = '" + gender.ToString().Trim() + "'");
                fillGrid(command);
            }
            else
            {
                radMale.Enabled = false;
                radFemale.Enabled = false;
                radMale.Checked = false;
                radFemale.Checked = false;
                SqlCommand command = new SqlCommand("Select id as ID, fname as FirstName, lname as LastName, bdate as BirthDay, gender as Gender, phone as Phone, address as Address, picture as Picture, email as Email FROM std");
                fillGrid(command);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            filter();
        }

        private void btnTextFile_Click(object sender, EventArgs e)
        {
            if (saveFileText.ShowDialog() == DialogResult.OK)
                xuatFileText(dataGVPrint, saveFileText.FileName);
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

        private void btnWord_Click(object sender, EventArgs e)
        {
            if (saveFileWord.ShowDialog() == DialogResult.OK)
                xuatFileWord(dataGVPrint, saveFileWord.FileName);
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
                xuatFileExcel(dataGVPrint, saveFileExcel.FileName);
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
                    for (int j = 0; j < dataGVPrint.Columns.Count - 1; j++)
                    {
                        if (dataGVPrint.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGVPrint.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                for (int i = 0; i < dataGVPrint.RowCount; i++)
                {
                    if (dataGVPrint.Rows[i].Cells[7].Value != null)
                    {
                        string imagePath = dataGVPrint.Rows[i].Cells[7].Value.ToString();
                        worksheet.Cells[i + 2, 8] = dataGVPrint.Rows[i].Cells[7].Value.ToString();
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
            if (saveFilePDF.ShowDialog() == DialogResult.OK)
                xuatFilePDF(dataGVPrint, saveFilePDF.FileName);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkGender_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /* PrintDialog printDialog = new PrintDialog();

             // Nếu người dùng chọn OK trong hộp thoại, tiến hành in
             if (printDialog.ShowDialog() == DialogResult.OK)
             {
                 // Tạo đối tượng PrintDocument
                 PrintDocument printDocument = new PrintDocument();

                 // Gán máy in đã chọn cho đối tượng PrintDocument
                 printDocument.PrinterSettings = printDialog.PrinterSettings;

                 // Gắn sự kiện PrintPage cho sự kiện PrintPage của đối tượng PrintDocument
                 printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

                 // In tài liệu
                 printDocument.Print();
             }*/
            Report report = new Report();
            report.reportpath = "ReportStudent.rdlc";
            report.dataset = "DataSetStudent";
            report.dataTable = student.getStudents(new SqlCommand("select * from std"));

            report.ShowDialog();


        }

        /*private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Tạo biến để xác định hàng hiện tại
            int row = 0;

            // Tạo biến để xác định vị trí y để bắt đầu in
            float yPos = 0;

            // Tạo biến để xác định vị trí x để bắt đầu in
            float xPos = 0;

            // Lấy số hàng và cột trong DataGridView
            int rowCount = dataGVPrint.Rows.Count;
            int columnCount = dataGVPrint.Columns.Count;

            // Tạo font cho dữ liệu in
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12, FontStyle.Regular);

            // Duyệt qua từng hàng trong DataGridView
            while (row < rowCount)
            {
                // Lấy hàng cụ thể
                DataGridViewRow dataGridViewRow = dataGVPrint.Rows[row];

                // Xác định vị trí y để bắt đầu in cho hàng hiện tại
                yPos = e.MarginBounds.Top + (row * font.GetHeight(e.Graphics));

                // Duyệt qua từng cột trong hàng
                for (int i = 0; i < columnCount; i++)
                {
                    // Xác định vị trí x để bắt đầu in cho cột hiện tại
                    xPos = e.MarginBounds.Left + (i * 100);

                    // In giá trị của ô cụ thể vào vị trí xác định
                    e.Graphics.DrawString(dataGridViewRow.Cells[i].Value.ToString(), font, Brushes.Black, xPos, yPos);
                }

                // Tăng giá trị của biến hàng để chuyển đến hàng tiếp theo
                row++;

                // Kiểm tra xem còn đủ không gian để in thêm hàng nữa không
                if ((yPos + font.GetHeight(e.Graphics)) > e.MarginBounds.Bottom)
                {
                    // Nếu không đủ không gian, chuyển sang trang in tiếp theo
                    e.HasMorePages = true;
                    return;
                }
            }

            // Nếu đã in hết tất cả các hàng, không cần thêm trang in nữa
            e.HasMorePages = false;
        }*/

    }
}
