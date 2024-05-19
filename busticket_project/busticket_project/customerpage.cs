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
    public partial class customerpage : Form
    {
        public customerpage()
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
            byticket bt = new byticket();
            bt.Show();
            this.Hide();
        }

        private void customerpage_Load(object sender, EventArgs e)
        {
            listening("SELECT t.ticketid as TicketNO ,c.customername AS NAME, c.customersurname AS SURNAME, c.customerphone AS PHONE, c.customergender AS GENDER, c.customerage AS AGE, r.departurePlace AS DEPARTUREPLACE, r.arrivalPlace AS ARRIVALPLACE, r.departuredate AS DEPARTUREDATE, r.departuretime AS DEPARTURETIME, r.routesticketprice AS TICKETPRICE FROM customers AS c, routes AS r, tickets AS t WHERE t.customerid = c.customerid AND t.routeid = r.routeid AND c.customerusername = '" + customerlogin.customerusername + "'");
    
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult choose;
            choose = MessageBox.Show(" Are you sure you want to delete ticket number"+dataGridView1.CurrentRow.Cells[0].Value.ToString() , "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choose == DialogResult.Yes)
            {
                connection.Open();
                OleDbCommand komut = new OleDbCommand("delete * from tickets where ticketid=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "", connection);
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Ticket Canceled.");
                listening("SELECT t.ticketid as TicketNO ,c.customername AS NAME, c.customersurname AS SURNAME, c.customerphone AS PHONE, c.customergender AS GENDER, c.customerage AS AGE, r.departurePlace AS DEPARTUREPLACE, r.arrivalPlace AS ARRIVALPLACE, r.departuredate AS DEPARTUREDATE, r.departuretime AS DEPARTURETIME, r.routesticketprice AS TICKETPRICE FROM customers AS c, routes AS r, tickets AS t WHERE t.customerid = c.customerid AND t.routeid = r.routeid AND c.customerusername = '" + customerlogin.customerusername + "'");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            homepage hp = new homepage();
            hp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listening("SELECT t.ticketid as TicketNO ,c.customername AS NAME, c.customersurname AS SURNAME, c.customerphone AS PHONE, c.customergender AS GENDER, c.customerage AS AGE, r.departurePlace AS DEPARTUREPLACE, r.arrivalPlace AS ARRIVALPLACE, r.departuredate AS DEPARTUREDATE, r.departuretime AS DEPARTURETIME, r.routesticketprice AS TICKETPRICE FROM customers AS c, routes AS r, tickets AS t WHERE t.customerid = c.customerid AND t.routeid = r.routeid AND c.customerusername = '" + customerlogin.customerusername + "'ORDER BY r.departuredate DESC; ");

        }
    }
}
