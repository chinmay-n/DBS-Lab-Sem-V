using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventMgtSys
{

    public partial class EventReg : Form
    {
        private DBConnect d;
        string cat;
        int j;
        List<string>[] p;

        public EventReg()
        {
            InitializeComponent();
            d = new DBConnect();
            Register F = new Register();
            this.SetVisibleCore(false);
            F.Show();
        }

        public EventReg(string c)
        {
            InitializeComponent();
            d = new DBConnect();
            cat = c;

            string query = "select count(evid) from event where typeid='" + cat + "'";
            j = d.Count(query);
            if (j < 0)
            {
                MessageBox.Show("No events in this category!");
                this.Close();
            }
            query = "select evid from event where typeid='" + cat + "'";
            string[] par = new string[1];
            par[0] = "evid";
            p = d.Select(query, par);
            for (int i = 0; i < j; i++)
            {
                listBox1.Items.Add(p[0][i]);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (j > 0)
            {
                string q = "select count(regid) from reg where uname='" + textBox1.Text + "' and eid=" + listBox1.SelectedItem.ToString();

                int ret = -1;
                ret = d.Count(q);
                if (ret > 0)
                {
                    MessageBox.Show("RegID already exists");
                    textBox1.Text = "";
                    return;
                }
                string query = "INSERT INTO  reg(eid,uname,cat) values(" + listBox1.SelectedItem.ToString() + ",'" + textBox1.Text + "'," + cat + ")";
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
                q = "select count(regid) from reg where uname='" + textBox1.Text + "' and eid=" + listBox1.SelectedItem.ToString();

                ret = -1;
                ret = d.Count(q);
                if (ret <= 0)
                {
                    MessageBox.Show("Registration Failed");
                    textBox1.Text = "";
                }
                q = "select regid from reg where uname='" + textBox1.Text + "' and eid=" + listBox1.SelectedItem.ToString();

                if (d.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(q, d.connection);
                    String s = cmd.ExecuteScalar().ToString();
                    MessageBox.Show("Done!\nRegID: " + s);
                    //close connection
                    d.CloseConnection();
                }

            }
        }

        public void SendEmail(string inputEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("hostel.rup.project@gmail.com");
                mail.To.Add("chinmayn96@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 465;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hostel.rup.project@gmail.com", "projectacc");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    
    }
}
