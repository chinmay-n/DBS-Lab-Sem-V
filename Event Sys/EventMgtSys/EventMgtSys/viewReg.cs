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
    public partial class viewReg : Form
    {
        DBConnect d;
        List<string>[] p;
        int j;
        string cat;

        public viewReg()
        {
            InitializeComponent();
            d = new DBConnect();
            string query = "select count(distinct typeid) from ctype";
            int j = d.Count(query);
            if (j > 0)
            {
                query = "select typeid from ctype";
                string[] par = new string[1];
                par[0] = "typeid";
                p = d.Select(query,par);
                for (int i = 0; i < j; i++)
                {
                    listBox1.Items.Add(p[0][i].ToString());
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                return;
            }

            else {
                cat = listBox1.SelectedItem.ToString();
                string query = "select count(evid) from event where typeid='" + cat+"'";
                j = d.Count(query);
                if (j <= 0)
                {
                    MessageBox.Show("No events in this category!");
                    listBox2.Items.Clear();
                }
                query = "select evid from event where typeid='" + cat+"'";
                string[] par = new string[1];
                par[0] = "evid";
                p = d.Select(query, par);
                for (int i = 0; i < j; i++)
                {
                    listBox2.Items.Add(p[0][i]);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "select * from reg where eid='" + listBox2.SelectedItem.ToString()+"'";
            if (d.OpenConnection() == true)
            {

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(q, d.connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];

                //close connection
                d.CloseConnection();
            }
        }
    }
    } 

