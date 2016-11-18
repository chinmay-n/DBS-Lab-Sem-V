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
    public partial class evDetails : Form
    {

        DBConnect d;
        string cat;
        List<string>[] p;
        int j;

        public evDetails()
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
                p = d.Select(query, par);
                for (int i = 0; i < j; i++)
                {
                    listBox1.Items.Add(p[0][i].ToString());
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q = "select * from event where typeid='" + listBox1.SelectedItem.ToString() + "'";
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
