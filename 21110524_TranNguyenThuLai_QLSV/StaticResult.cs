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

namespace _21110524_TranNguyenThuLai_QLSV.Result
{
    public partial class StaticResult : Form
    {
        public StaticResult()
        {
            InitializeComponent();
        }
        MY_DB mydb = new MY_DB();
        private void StaticResult_Load(object sender, EventArgs e)
        {
            cbSemester.Items.Add("HK1");
            cbSemester.Items.Add("HK2");
            cbSemester.Items.Add("HK3");
            cbSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSemester.Text = "HK1";

            loadDuLieu();
        }

        public void loadDuLieu()
        {
            DataTable table = getAvgScoreByCourse();
            int yPos = 10;
            int labelHeight = 20;
            int panelWidth = 200;
            int panelMargin = 10;

            panel.Controls.Clear();

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    string courseLabel = row["lable"].ToString();
                    float avg = float.Parse(row["AverageGrade"].ToString());

                    Label myLabel = new Label();

                    myLabel.Text = $"{courseLabel}: {avg.ToString("N2")}";
                    myLabel.Location = new Point(panelMargin, yPos);
                    myLabel.Width = panelWidth - 2 * panelMargin;
                    myLabel.Height = labelHeight;
                    myLabel.Font = new Font("Century Gothic", 13, FontStyle.Regular);
                    myLabel.AutoSize = true;

                    panel.Controls.Add(myLabel);

                    yPos += labelHeight + 10;
                }
            }
            tinhTiLe();
        }

        public void tinhTiLe()
        {
            DataTable table = getAvgScoreByStudent();
            int countTotal = table.Rows.Count;
            int countVeryGood = 0;
            int countGood = 0;
            int countOrdinary = 0;


            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (Convert.ToSingle(row["AverageGrade"]) >= 9)
                        countVeryGood++;
                    else if (Convert.ToSingle(row["AverageGrade"]) >= 8)
                        countGood++;
                    else if (Convert.ToSingle(row["AverageGrade"]) >= 5)
                        countOrdinary++;
                }
            }

            float verygood = ((float)countVeryGood / countTotal) * 100;
            float good = ((float)countGood / countTotal) * 100;
            float ordinary = ((float)countOrdinary / countTotal) * 100;

            float fail = 100 - verygood - good - ordinary;

            lblFail.Text = "Fail: " + fail.ToString("N2") + " %";
            lblVeryGood.Text = "Very Good: " + verygood.ToString("N2") + " %";
            lblGood.Text = "Good: " + good.ToString("N2") + " %";
            lblOrdinary.Text = "Ordinary: " + ordinary.ToString("N2") + " %";

        }

        public DataTable getAvgScoreByStudent()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT st.id , AVG(s.student_score) as AverageGrade \r\n" +
                "FROM std st, score s, course c\r\n" +
                "WHERE st.id = s.student_id AND s.course_id=c.Id AND semester=@semester\r\n" +
                "GROUP BY st.id";
            command.Parameters.Add("@semester", SqlDbType.NVarChar).Value = cbSemester.Text.ToString().Trim();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;
            command.CommandText = "SELECT course.lable , AVG(score.student_score) as AverageGrade FROM course, score " +
                "WHERE course.Id = score.course_id AND semester=@semester " +
                "GROUP BY course.lable";
            command.Parameters.Add("@semester", SqlDbType.NVarChar).Value = cbSemester.Text.ToString().Trim();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        private void cbSemester_SelectedValueChanged(object sender, EventArgs e)
        {
            loadDuLieu();
        }
    }
}
