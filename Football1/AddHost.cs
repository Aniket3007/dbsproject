using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Football1
{
    public partial class AddHost : Form
    {
        OracleConnection conn;
        public AddHost()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=ORCL;USER ID=SYSTEM;PASSWORD=iamthebest");
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
            string Tname = textBox1.Text;
            string Fname = textBox2.Text;

            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "INSERT INTO host (username, password) VALUES ('" + Tname + "', '" + Fname + "')";
            command1.CommandType = CommandType.Text;

            try
            {
                command1.ExecuteNonQuery();
                MessageBox.Show("Inserted");
            }
            catch (OracleException ex)
            {
                if (ex.Number == 20001)
                {
                    MessageBox.Show("Error: Username and password combination already exists!");
                }
                else
                {
                    MessageBox.Show("Error Username and password combination already exists!");
                }
            }
            finally
            {
                command1.Dispose();
                conn.Close();
            }

            Admin a1 = new Admin();
            a1.Show();
            this.Hide();
        }
    }
}
