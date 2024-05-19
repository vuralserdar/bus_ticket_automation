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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace busticket_project
{
    public partial class customerlogin : Form
    {
        public customerlogin()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\serka\\OneDrive\\Masaüstü\\byticket2.accdb");
        int customeruserid;
        public static string customerusername="";
        private void button1_Click(object sender, EventArgs e)
        {
            bool isthereuser = false;

            connection.Open();
            OleDbCommand komut = new OleDbCommand("select * from customerslogin where customerusername='" + textBox1.Text + "' and customeruserpassword='" + textBox2.Text + "'", connection);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                isthereuser = true;
                customeruserid = Convert.ToInt32(oku["customerloginid"]);
            }
            connection.Close();
            if (isthereuser)
            {
                customerusername = textBox1.Text;
                customerpage up = new customerpage();
                up.Show();
                this.Hide();
            }
            else MessageBox.Show("Please enter your information correctly. If you are not registered, register first.");
        }

        private void customerlogin_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }
    }
}
