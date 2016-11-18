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
    public partial class SelCat : Form
    {
        DBConnect d;
        List<string>[] p;
        string cat;
        int flag = 0;

        public SelCat()
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
            else {
                MessageBox.Show("No events in this category!");
                return;
            }
        }

        public SelCat(int s)
        {
            InitializeComponent();
            d = new DBConnect();
            flag = s;

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
            else
            {
                MessageBox.Show("No events in this category!");
                return;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cat = listBox1.SelectedItem.ToString();
           // Console.WriteLine(cat);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag != 0) {
                this.Visible = false;
                cat = listBox1.SelectedItem.ToString();
               addEvent f = new addEvent(cat);
                f.ShowDialog();
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
                cat = listBox1.SelectedItem.ToString();
                EventReg f = new EventReg(cat);
                f.ShowDialog();
                this.Visible = true;
            }
        }
    }
}
