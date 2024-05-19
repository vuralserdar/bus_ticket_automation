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
    public partial class querryticket : Form
    {
        public querryticket()
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
            listening("SELECT t.ticketid as TicketNO ,c.customername AS NAME, c.customersurname AS SURNAME, c.customerphone AS PHONE, c.customergender AS GENDER, c.customerage AS AGE, r.departurePlace AS DEPARTUREPLACE, r.arrivalPlace AS ARRIVALPLACE, r.departuredate AS DEPARTUREDATE, r.departuretime AS DEPARTURETIME, r.routesticketprice AS TICKETPRICE FROM customers AS c, routes AS r, tickets AS t WHERE t.customerid = c.customerid AND t.routeid = r.routeid AND c.customertcnum = '" + textBox1.Text + "'");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }
    }
}
