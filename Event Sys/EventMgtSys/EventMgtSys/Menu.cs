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
    public partial class Menu : Form
    {
        string cat;
        int flag=0;
        DBConnect d;


        public Menu()
        {
            InitializeComponent();
            d = new DBConnect();
            cat = "user";
            
        }
        public Menu(string c)
        {
            InitializeComponent();
            d = new DBConnect();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            cat = c;

        }

        public Menu(string c,int i)
        {
            InitializeComponent();
            d = new DBConnect();
            cat = c;
            flag = i;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           SelCat f = new SelCat();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (flag != 0) {
               
                viewReg f = new viewReg();
                this.Visible = false;
                f.ShowDialog();
                this.Visible = true;
            }
            if (flag == 0) {
                
                uUserData f = new uUserData(cat);
                this.Visible = false;
                f.ShowDialog();
                this.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            aUserDetails f = new aUserDetails();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            aCreate f = new aCreate();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            evDetails f = new evDetails();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Visible = false;
            f.ShowDialog();
            this.Visible = true;
        }
    }
}
