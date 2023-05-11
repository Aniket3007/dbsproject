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
    public partial class Plogin : Form
    {
        OracleConnection conn;
        public Plogin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            string teamName = textBox2.Text;

            ConnectDB();

            // Check if the player's fname and team name match in the database
            OracleCommand command = conn.CreateCommand();
            command.CommandText = "SELECT fname FROM Players WHERE fname = :fname AND team_name = :teamName";
            command.Parameters.Add("fname", OracleDbType.Varchar2).Value = fname;
            command.Parameters.Add("teamName", OracleDbType.Varchar2).Value = teamName;

            OracleDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Login successful");
                Player player = new Player();
                player.Show();
                this.Hide();
                // Proceed with further actions after successful login
                // For example, open a new form or perform additional tasks
            }
            else
            {
                MessageBox.Show("Invalid fname or team name");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
