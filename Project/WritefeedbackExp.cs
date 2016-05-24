using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace FFS_platform
{
    public partial class WriteFeedbackExp : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ADMIN-ПК;Initial Catalog=fs;Integrated Security=True");
        SqlCommand com = new SqlCommand();
        public WriteFeedbackExp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartPage sp = new StartPage();
            sp.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fsDataSet.Evaluation". При необходимости она может быть перемещена или удалена.
            this.evaluationTableAdapter.Fill(this.fsDataSet.Evaluation);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fsDataSet.Experts". При необходимости она может быть перемещена или удалена.
            this.expertsTableAdapter.Fill(this.fsDataSet.Experts);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "INSERT INTO FeedbackExp(Date, Text, Evaluate, ExpID, Author) VALUES ('" + string.Format("{0:yyyy/MM/dd 00:00}", DateTime.Now) + "', '" + richTextBox1.Text + "', '" + comboBox1.SelectedValue + "', '"+ iDLabel1.Text +"', '" + textBox1.Text + "')";
            com.ExecuteNonQuery();
            this.Validate();
            this.expertsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fsDataSet);
            con.Close();
            MessageBox.Show("Update successfull");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("З метою забезпечення конфіденційності автор не відображатиметься в таблиці");
        }

    }
}
