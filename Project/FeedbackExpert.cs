using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFS_platform
{
    public partial class FeedbackExpert : Form
    {
        public FeedbackExpert()
        {
            InitializeComponent();
        }       

        private void FeedbackExpert_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fsDataSet.FeedbackExp". При необходимости она может быть перемещена или удалена.
            this.feedbackExpTableAdapter.Fill(this.fsDataSet.FeedbackExp);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartPage sp = new StartPage();
            sp.ShowDialog();
        }     
    }
}
