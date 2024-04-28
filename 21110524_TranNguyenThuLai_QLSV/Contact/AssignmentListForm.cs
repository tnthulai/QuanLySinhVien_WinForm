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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class AssignmentListForm : Form
    {
        public string contactID;
        public AssignmentListForm()
        {
            InitializeComponent();
        }

        private void AssignmentListForm_Load(object sender, EventArgs e)
        {
            cbSemester.Items.Add("Semester 1");
            cbSemester.Items.Add("Semester 2");
            cbSemester.Items.Add("Semester 3");
            cbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSemester.SelectedIndex = 0;

            hienThiThongTin();
            hienThiDuLieu();
        }

        public void hienThiThongTin()
        {
            MY_DB mydb = new MY_DB();
            lblContactID.Text = "Contact ID: " + contactID;

            SqlCommand command = new SqlCommand("SELECT fname, lname FROM contact WHERE id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = contactID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                string fname = table.Rows[0]["fname"].ToString();
                string lname = table.Rows[0]["lname"].ToString();
                lblName.Text = "Name " + lname + " " + fname;
            }
        }
        public void hienThiDuLieu()
        {
            MY_DB mydb = new MY_DB();
            SqlCommand command = new SqlCommand("SELECT distinct c.Id, c.label\r\n" +
                "FROM course_contact cc, course c\r\n" +
                "WHERE c.Id = cc.id_course AND c.semester = @semester AND cc.id_contact = @id_contact", mydb.getConnection);
            command.Parameters.Add("@id_contact", SqlDbType.VarChar).Value = contactID;
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = cbSemester.Text.Trim();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGV.DataSource = table;
        }

        private void cbSemester_SelectedValueChanged(object sender, EventArgs e)
        {
            hienThiDuLieu();
        }
    }
}
