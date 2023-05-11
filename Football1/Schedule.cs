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
    public partial class Schedule : Form
    {
        OracleConnection conn;
        string Match_number;
        string Match_date;
        string stadium;
        string city;
        public Schedule()
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

        private void button6_Click(object sender, EventArgs e)
        {
            Match_number = textBox1.Text;
            Match_date = textBox2.Text;
            stadium = textBox3.Text;
            city = textBox5.Text;
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "insert into schedule values('" + Match_number + "','" + Match_date + "','" + stadium + "','" + city + "')";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Inserted");
            command1.Dispose();
            conn.Close();
            Player p1 = new Player();
            p1.Show();
            this.Hide();
        }
    }
}
