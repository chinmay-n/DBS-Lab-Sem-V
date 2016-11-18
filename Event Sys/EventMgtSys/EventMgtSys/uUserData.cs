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
    public partial class uUserData : Form
    {
        DBConnect d;
        string user;

        public uUserData()
        {
            InitializeComponent();
            d = new DBConnect();
        }

        public uUserData(string u)
        {
            InitializeComponent();
            d = new DBConnect();
            user = u;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (d.OpenConnection() == true)
            {

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(("select * from reg where uname='" + user + "'"), d.connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];

                //close connection
                d.CloseConnection();
            }
        }
    }
}
