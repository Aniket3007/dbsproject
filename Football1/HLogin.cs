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

namespace Football1
{
    public partial class HLogin : Form
    {
        OracleConnection conn;

        public HLogin()
        {
            InitializeComponent();
        }

        private void HLogin_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            ConnectDB();

            // Check if the username and password match in the database
            OracleCommand command = conn.CreateCommand();
            command.CommandText = "SELECT username FROM host WHERE username = :username AND password = :password";
            command.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
            command.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

            OracleDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Login successful");
                Host host = new Host();
                host.Show();
                this.Hide();
                // Proceed with further actions after successful login
                // For example, open a new form or perform additional tasks
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

            reader.Close();
            command.Dispose();
            conn.Close();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=ORCL;USER ID=system;PASSWORD=iamthebest");
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
    }
}
