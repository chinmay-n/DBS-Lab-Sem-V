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
    public partial class Form1 : Form
    {
        DBConnect d;

        public Form1()
        {
            InitializeComponent();
            d = new DBConnect();
            if (d.OpenConnection() == true)
            {
                string q = "select * from event_v";


                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(q, d.connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
                d.CloseConnection();


            }
        }

        //private void chart1_Click(object sender, EventArgs e)
        //{
        //    string q = "select * from event_v";
        //    MySqlCommand c = new MySqlCommand(q, d.connection);
        //    MySqlDataReader r = c.ExecuteReader();
        //    while (r.Read())
        //    {

        //        chart1.Series["Participation in Events"].XValueMember ="eid";
        //           chart1.Series["Participation in Events"].YValueMembers= "count(distinct uname)";

        //    }

        //    //close connection
        //    d.CloseConnection();
        //}
    }
}
