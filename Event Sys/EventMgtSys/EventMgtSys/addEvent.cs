using MySql.Data.MySqlClient;
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
    public partial class addEvent : Form
    {
        DBConnect d;
        string cat;
        int j;

        public addEvent()
        {
            InitializeComponent();
        }

        public addEvent(string c)
        {
            InitializeComponent();
            d = new DBConnect();
            cat = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(label1.Text + "Cannot be empty");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show(label2.Text + "Cannot be empty");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show(label3.Text + "Cannot be empty");
                return;
            }

            string q = "select count(*) from event where ename='" + textBox1.Text + "'";
            int ret = -1;
            string uname = textBox1.Text;
            ret = d.Count(q);
            if (ret > 0)
            {
                MessageBox.Show("Event Already Exists!");
                textBox1.Text = "";
                //textBox2.Text = "";                             
            }

             q = "call createEvent('" + textBox1.Text + "'," + cat + ",'" + textBox2.Text + "','" + textBox3.Text + "')";
            if (d.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(q,d.connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Event Created!");
                //close connection
                d.CloseConnection();
            }
        }
    }
}
