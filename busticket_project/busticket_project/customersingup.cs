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
    public partial class customersingup : Form
    {
        public customersingup()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\serka\\OneDrive\\Masaüstü\\byticket2.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            //KULLANICI KAYIT ETME 
            if (textBox4.Text == textBox5.Text)
            {
                connection.Open();
                OleDbCommand komut = new OleDbCommand("insert into customerslogin(customername,customersurname,customerusername,customeruserpassword) values (@customername,@customersurname,@customerusername,@customeruserpassword)", connection);

                komut.Parameters.AddWithValue("@customername", textBox1.Text);
                komut.Parameters.AddWithValue("@customersurname", textBox2.Text);
                komut.Parameters.AddWithValue("@customerusername", textBox3.Text);
                komut.Parameters.AddWithValue("@customeruserpassword", textBox4.Text);
                komut.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("RECORDED");


                customerlogin cl = new customerlogin();
                cl.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Your password and password confirmation do not match. Please enter the same password.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }
    }
}
