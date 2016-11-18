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
    
    public partial class Login : Form
    {
        DBConnect d;
        public Login()
        {
            InitializeComponent();
            d = new DBConnect();
            textBox2.UseSystemPasswordChar=true;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(label1.Text + "Cannot be empty");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show(label2.Text + "Cannot be empty");
            }

            string q = "select count(*) from reg_user where uname='" + textBox1.Text + "' and password='"+textBox2.Text + "'";
            int ret = -1;
            string uname=textBox1.Text;
            ret = d.Count(q);
            if (ret <= 0)
            {
                MessageBox.Show("Incorrect username/password");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else {

                MessageBox.Show("Login Successful!");
                this.Visible = false;
                uname = textBox1.Text;
                Menu f = new Menu(uname);
                f.ShowDialog();
                this.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Register f = new Register();
            f.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show(label1.Text + "Cannot be empty");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show(label2.Text + "Cannot be empty");
            }

            string q = "select count(*) from admin where uid='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            int ret = -1;
            string uname;
            ret = d.Count(q);
            if (ret <= 0)
            {
                MessageBox.Show("Incorrect username/password or Not Admin");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {

                MessageBox.Show("Login Successful!");

                uname = textBox1.Text;
                this.Visible = false;
                Menu f = new Menu(uname,10);
                f.ShowDialog();
            }
        }
    }
}
