using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventMgtSys
{
    public partial class aUserDetails : Form
    {
        string cat;
        DBConnect d;

        public aUserDetails()
        {
            InitializeComponent();
            d = new DBConnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" & textBox3.Text == "") {
                MessageBox.Show("Enter either value");
                return;
            }
            if (textBox2.Text=="") {
                if (d.OpenConnection() == true)
                {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from reg_user where uname='"+textBox3.Text+"'", d.connection);
                    DataSet DS = new DataSet();
                    mySqlDataAdapter.Fill(DS);
                    dataGridView1.DataSource = DS.Tables[0];

                    //close connection
                    d.CloseConnection();
                }
            }
            if (textBox3.Text == "")
            {
                
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from reg_user where ='" + textBox3.Text + "'", d.connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];

                //close connection
                d.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show(label1.Text + "Cannot be empty");
            }
            string q = "select count(*) from reg where regid=" + textBox1.Text;
            int ret = -1;
            ret = d.Count(q);
            if (ret <= 0)
            {
                MessageBox.Show("RegID incorrect-Does not exist");
                textBox1.Text = "";
            }

            q = "delete from reg where regid="+textBox1.Text;
            if (d.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(q, d.connection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration Removed!");
                //close connection
                d.CloseConnection();
            }

        }
    }
}
