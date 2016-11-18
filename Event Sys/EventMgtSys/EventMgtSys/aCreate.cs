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
    public partial class aCreate : Form
    {
        public aCreate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) {
                MessageBox.Show("Select an operation");
            }
            if (listBox1.SelectedItem.ToString()=="Category") {
                this.Visible = false;
                AddCat f = new AddCat();
                f.ShowDialog();
                this.Visible = true;
            }
            if (listBox1.SelectedItem.ToString() == "Event")
            {
                this.Visible = false;
                SelCat f = new SelCat(10);
                f.ShowDialog();
                this.Visible = true;
            }
        }
    }
}
