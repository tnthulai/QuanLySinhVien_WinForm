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
    public partial class AverageScoreByCourse : Form
    {
        public AverageScoreByCourse()
        {
            InitializeComponent();
        }
        Score score = new Score();
        private void AverageScoreByCourse_Load(object sender, EventArgs e)
        {
            dataAvgScore.DataSource = score.getAvgScoreByCourse();
        }
    }
}
