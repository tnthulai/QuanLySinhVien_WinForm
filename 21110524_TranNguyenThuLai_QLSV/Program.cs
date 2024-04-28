using _21110524_TranNguyenThuLai_QLSV.Contact;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace _21110524_TranNguyenThuLai_QLSV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            /*
            Main_Form main = new Main_Form();
            main.ShowDialog();*/

            ClassListForm classListForm = new ClassListForm();
            classListForm.ShowDialog();

            Login_Form flogin = new Login_Form();
            if (flogin.ShowDialog() == DialogResult.OK)
            { //Application.Run(new Main_Form());
            }
           
            else
            { Application.Exit(); }
        }
    }
}
