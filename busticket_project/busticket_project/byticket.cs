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
    public partial class byticket : Form
    {
        public byticket()
        {
            InitializeComponent();
        }
        void listening(string listquerry)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(listquerry, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ds.Dispose();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\serka\\OneDrive\\Masaüstü\\byticket2.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Please enter all information");
            }
            else
            {
                connection.Open();
                OleDbCommand komut = new OleDbCommand("insert into customers(customertcnum,customername,customersurname,customerphone,customergender,customerage,customerusername) values (@ctcn,@cn,@csn,@cp,@cg,@ca,@cun)", connection);

                komut.Parameters.AddWithValue("@ctcn", textBox1.Text);
                komut.Parameters.AddWithValue("@cn", textBox2.Text);
                komut.Parameters.AddWithValue("@csn", textBox3.Text);
                komut.Parameters.AddWithValue("@cp", textBox5.Text);
                komut.Parameters.AddWithValue("@cg", comboBox4.Text);
                komut.Parameters.AddWithValue("@ca", textBox4.Text);
                komut.Parameters.AddWithValue("@cun", customerlogin.customerusername);
                komut.ExecuteNonQuery();

                int customerid = 0;
                OleDbCommand komut3 = new OleDbCommand("select * from customers where customertcnum='" + textBox1.Text.ToString() + "'", connection);
                OleDbDataReader oku = komut3.ExecuteReader();
                while (oku.Read())
                {
                    customerid = Convert.ToInt32(oku["customerid"]);
                }


                OleDbCommand komut2 = new OleDbCommand("INSERT INTO tickets(customerid, routeid, seatno) values (@customerid,@routeid,@seatno) ", connection);

                komut2.Parameters.AddWithValue("@customerid", customerid.ToString());
                komut2.Parameters.AddWithValue("@routeid", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                komut2.Parameters.AddWithValue("@seatno", textBox6.Text);
                komut2.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Payment completed");
                customerpage cp = new customerpage();
                cp.Show();
                this.Hide();
            }
        }

        public static string routeid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label14.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            routeid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void byticket_Load(object sender, EventArgs e)
        {
            listening("select * from routes");
            panel2.Hide();
            panel1.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            bool seatcontrol = false;

            connection.Open();
            OleDbCommand komut = new OleDbCommand("select * from tickets  where seatno='" + textBox7.Text + "' and routeid=" +routeid+"", connection);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                seatcontrol = true;
                
            }
            connection.Close();
            if (seatcontrol)
            {
                MessageBox.Show("You chose a full seat, please choose another seat.");
            }
            else
            {
                int seatnumber = Convert.ToInt32(textBox7.Text);
                if (seatnumber > 0 && seatnumber <= 50)
                {
                    MessageBox.Show("SEAT CHOOESEN");
                    textBox6.Text = seatnumber.ToString();
                    panel1.Hide();
                }
                else MessageBox.Show("You can't choose this seat.Please choose another seat");


            }
        }







        
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            label23.Text = textBox2.Text;
            label22.Text = textBox3.Text;
            label21.Text = textBox1.Text;
            label20.Text = textBox6.Text;
            label19.Text = dateTimePicker1.Text;
            label18.Text = comboBox3.Text;
            label17.Text = comboBox1.Text;
            label16.Text = comboBox2.Text;
        }

        private void button54_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button55_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button54_Click_1(object sender, EventArgs e)
        {
            panel2.Show();

        }

        private void button56_Click(object sender, EventArgs e)
        {
            
        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
