using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace busticket_project
{
    public partial class homepage : Form
    {
        public homepage()
        {
            InitializeComponent();
        }

        

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            customerlogin cl = new customerlogin();
            cl.Show();
            this.Hide();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            companyemployeelogin cel = new companyemployeelogin();
            cel.Show();
            this.Hide();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            customersingup csu = new customersingup();
            csu.Show();
            this.Hide();
        }

        private void homepage_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            byticket bt = new byticket();
            bt.Show();
            this.Hide();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            querryticket qt = new querryticket();
            qt.Show();
            this.Hide();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            employeesignup es = new employeesignup();
            es.Show();
            this.Hide();
        }
    }
}
