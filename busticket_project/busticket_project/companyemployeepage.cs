using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace busticket_project
{
    public partial class companyemployeepage : Form
    {
        public companyemployeepage()
        {
            InitializeComponent();
        }
        void listening(string querry)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(querry, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "routes");
            dataGridView1.DataSource = ds.Tables["routes"];
            ds.Dispose();
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\serka\\OneDrive\\Masaüstü\\byticket2.accdb");

        DateTime islemTarihi = DateTime.Now;
        private void button1_Click(object sender, EventArgs e)
        {
            if (islemTarihi <= dateTimePicker1.Value)
            {
                connection.Open();
                OleDbCommand komut = new OleDbCommand("insert into routes(departurePlace,arrivalPlace,departuredate,departuretime,routesticketprice) values (@dP,@aP,@dD,@dT,@rtp)", connection);

                komut.Parameters.AddWithValue("@dP", comboBox1.Text);
                komut.Parameters.AddWithValue("@aP", comboBox2.Text);
                komut.Parameters.AddWithValue("@dD", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@dT", comboBox3.Text);
                komut.Parameters.AddWithValue("@rtp", textBox1.Text);
                komut.ExecuteNonQuery();
                connection.Close();
                listening("select * from routes");
            }
            else MessageBox.Show("Please enter a valid date ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand komut = new OleDbCommand("update routes set departurePlace='" + comboBox1.Text + "' , arrivalPlace='" + comboBox2.Text + "' , departuredate='" + dateTimePicker1.Text + "' , departuretime='" + comboBox3.Text + "',routesticketprice='" + textBox1.Text + "' where routeid=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", connection);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Route Updated");
            listening("select * from routes");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand komut2 = new OleDbCommand("delete * from tickets where routeid=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", connection);
            komut2.ExecuteNonQuery();
            OleDbCommand komut = new OleDbCommand("delete * from routes where routeid=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", connection);
            komut.ExecuteNonQuery();
            MessageBox.Show("Route deleted");
            connection.Close();
            listening("select * from routes");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void companyemployeepage_Load(object sender, EventArgs e)
        {

            listening("select * from routes");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            employeesignup es = new employeesignup();
            es.Show();
            this.Hide();

        }
    }
}
