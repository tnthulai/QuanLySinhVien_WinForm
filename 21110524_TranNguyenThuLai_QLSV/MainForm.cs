using _21110524_TranNguyenThuLai_QLSV.Contact;
using _21110524_TranNguyenThuLai_QLSV.Result;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class Main_Form : Form
    {
        public string user;
        public Main_Form()
        {
            InitializeComponent();
        }

        
        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudent = new AddStudentForm();
            
            addStudent.Show(this);
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ImportStudentList studentList = new ImportStudentList();
            studentList.Show(this);*/
            studentListForm studentList = new studentListForm();
            studentList.Show(this);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
        public void CheckAdminPermission(string role)
        {
            adminToolStripMenuItem.Visible = false;
            contactToolStripMenuItem.Visible = false;

            if (role == "ADMIN")
            {
                adminToolStripMenuItem.Visible = true; // Hiển thị mục Admin trên MenuStrip
                contactToolStripMenuItem.Visible = true;
            }
            else if (role == "HR")
            {
                contactToolStripMenuItem.Visible = true;
            }
            else if (role == "STUDENT")
            {
                rESULTToolStripMenuItem.Visible = false;
            }
        }
        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDelete = new UpdateDeleteStudentForm();
            updateDelete.Show(this);
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm staticsForm = new StaticsForm();
            staticsForm.Show(this);
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudent_Form manageStudent_Form = new ManageStudent_Form();
            manageStudent_Form.Show(this);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintForm printForm = new PrintForm();
            printForm.Show(this);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageAccountLogin manageAccountLogin = new ManageAccountLogin();
            manageAccountLogin.Show(this);
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewCourse addNewCourse = new AddNewCourse();
            addNewCourse.Show(this);
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRemoveCourse editRemoveCourse = new EditRemoveCourse();
            editRemoveCourse.Show(this);
        }

        private void manageCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangeCourse mangeCourse = new MangeCourse();
            mangeCourse.Show(this);
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScores addScores = new AddScores();
            addScores.Show(this);
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AverageScoreByCourse averageScoreByCourse = new AverageScoreByCourse();
            averageScoreByCourse.Show(this);
        }

        private void removeScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveScore score = new RemoveScore();
            score.Show(this);
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageScore score = new ManageScore();
            score.Show(this);
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            Report report = new Report();
            report.reportpath = "Course.rdlc";
            report.dataset = "DataSetCourse";
            report.dataTable = course.getCourse(new SqlCommand("select * from Course"));

            report.ShowDialog();


            
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PrintScore printScore = new PrintScore();
            printScore.ShowDialog(this);
        }

        private void aVGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            resultForm.ShowDialog(this);
        }

        private void staticsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticResult staticResult = new StaticResult();
            staticResult.ShowDialog(this);
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contact_GroupForm contact_GroupForm = new Contact_GroupForm();
            contact_GroupForm.user = user;
            contact_GroupForm.ShowDialog(this);
        }
    }
}
