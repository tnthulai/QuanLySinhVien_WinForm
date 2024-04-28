using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    public partial class StaticsForm : Form
    {
        public StaticsForm()
        {
            InitializeComponent();
        }

        private void StaticsForm_Load(object sender, EventArgs e)
        {

            STUDENT student = new STUDENT();

            double total = Convert.ToDouble(student.totalStudent());
            double totalMale = Convert.ToDouble(student.totalMaleStudent());
            double totalFemale = Convert.ToDouble(student.totalFemaleStudent());

            double maleStudentsPercentage = (totalMale * (100 / total));
            double femaleStudentsPercentage = (totalFemale * (100 / total));

            lblTotal.Text = ("Total Students: " + total.ToString());
            lblMale.Text = ("Male: " + maleStudentsPercentage.ToString("0.00") + "%");
            lblFemale.Text = ("Female: " + femaleStudentsPercentage.ToString("0.00") + "%");

        }

        private void labelTotal_MouseEnter(object sender, EventArgs e)
        {
            lblTotal.ForeColor = pnTotal.BackColor;
            pnTotal.BackColor = lblTotal.BackColor;
        }

        private void labelTotal_MouseLeave(object sender, EventArgs e)
        {
            lblTotal.ForeColor = Color.Blue;
            pnTotal.BackColor = pnMale.BackColor;
        }

        private void LabelMale_MouseEnter(object sender, EventArgs e)
        {
            lblMale.ForeColor = pnMale.BackColor;
            pnMale.BackColor = Color.Blue;
        }

        private void LabelMale_MouseLeave(object sender, EventArgs e)
        {
            lblMale.ForeColor = Color.Blue;
            pnMale.BackColor = pnMale.BackColor;
        }

        private void LabelFemale_MouseEnter(object sender, EventArgs e)
        {
            lblFemale.ForeColor = pnFemale.BackColor;
            lblFemale.BackColor = Color.Blue;
        }

        private void LabelFemale_MouseLeave(object sender, EventArgs e)
        {
            lblFemale.ForeColor = Color.Blue;
            pnFemale.BackColor = pnFemale.BackColor;
        }
    }
}
