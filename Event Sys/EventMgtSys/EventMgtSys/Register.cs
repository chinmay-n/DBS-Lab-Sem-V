using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EventMgtSys
{
    public partial class Register : Form
    {
        DBConnect d;

        public Register()
        {
            InitializeComponent();
            d = new DBConnect();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") {
                MessageBox.Show(label2.Text+" Cannot be empty");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show(label3.Text + " Cannot be empty");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show(label4.Text + " Cannot be empty");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show(label5.Text + " Cannot be empty");
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show(label7.Text + " Cannot be empty");
                return;
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show(label8.Text + " Cannot be empty");
                return;
            }

            if (textBox7.Text.Length < 10) {
                MessageBox.Show(label8.Text + " has to be atleast 10 digits");
            }
            //string q = "select uname from reg_user where uname='" + textBox3.Text + "')";

            string query = "INSERT INTO  reg_user(uname,name,dob,email,password,phone) VALUES('"+textBox3.Text+"','"+ textBox1.Text + "','"+ textBox2.Text + "','"+ textBox6.Text + "','"+ textBox4.Text + "','"+textBox7.Text+"')";

            //open connection
            if (d.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor

                MySqlCommand cmd = new MySqlCommand(query, d.connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                d.CloseConnection();
            }

            MessageBox.Show("Done");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

       }
}
