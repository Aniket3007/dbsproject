using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Football1
{
    public partial class PAddI : Form
    {
        OracleConnection conn;
        string Injury_id;
        string fname;
        string lname;
        string type;
        
        public PAddI()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=ORCL;USER ID=SYSTEM;PASSWORD =iamthebest");
            MessageBox.Show(conn.ConnectionString);


            try
            {
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception e1)
            {
                MessageBox.Show("Not Connected");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Injury_id = textBox1.Text;
            fname = textBox2.Text;
            lname = textBox3.Text;
            type = textBox4.Text;
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "insert into injuries values('" + Injury_id+ "','" + fname + "','" + lname + "','" + type + "')";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            command1.Dispose();
            conn.Close();
            Player  p1 = new Player();
            p1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
