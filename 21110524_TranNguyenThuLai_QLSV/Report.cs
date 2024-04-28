using Microsoft.Reporting.WinForms;
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

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        
        public string reportpath { get; set; }
        public string dataset { get; set; }
        public DataTable dataTable { get; set; }


        private void ReportCourse_Load(object sender, EventArgs e)
        {
            

            this.reportViewer1.LocalReport.ReportPath = reportpath;

            this.reportViewer1.LocalReport.DataSources.Clear();
            var dataSource = new ReportDataSource(dataset, dataTable);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.LocalReport.EnableExternalImages = true;

            
            this.reportViewer1.RefreshReport();
           
        }

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            Image image = Image.FromStream(ms);
            return image;
        }

    }
}
