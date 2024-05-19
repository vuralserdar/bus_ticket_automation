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
    public partial class companyemployeelogin : Form
    {
        public companyemployeelogin()
        {
            InitializeComponent();
        }
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\serka\\OneDrive\\Masaüstü\\byticket2.accdb");
        int employeeid;
        private void button1_Click(object sender, EventArgs e)
        {
            bool isthereuser = false;

            connection.Open();
            OleDbCommand komut = new OleDbCommand("select * from companyemployee where employeeusername='" + textBox1.Text + "' and employeeuserpassword='" + textBox2.Text + "'", connection);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                isthereuser = true;
                employeeid = Convert.ToInt32(oku["employeeid"]);
            }
            connection.Close();
            if (isthereuser)
            {
                companyemployeepage cep = new companyemployeepage();
                cep.Show();
                this.Hide();
            }
            else MessageBox.Show("Please enter your information correctly. If you are not registered, register first.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();

        }
    }
}
