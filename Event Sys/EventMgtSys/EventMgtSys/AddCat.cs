using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventMgtSys
{
    public partial class AddCat : Form
    {
        DBConnect d;

        public AddCat()
        {
            InitializeComponent();
            d = new DBConnect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "") {
                MessageBox.Show("Enter all fields");
                return;
            }
            string q = "select count(*) from ctype where typeid=" + textBox2.Text + " and tname='" + textBox1.Text + "'";
            int ret = -1;
            ret = d.Count(q);
            if (ret == 1)
            {
                MessageBox.Show("Category already exists!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else {
                q="insert into ctype values("+textBox2.Text+",'"+textBox1.Text+"')";
                d.Insert(q);
                MessageBox.Show("Done!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
