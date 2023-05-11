using System;
using System.Data;
using System.Drawing.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Football1
{
    public partial class Teamlogin : Form
    {
        OracleConnection conn;

        public Teamlogin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string teamName = textBox1.Text;
            string coach = textBox2.Text;

            ConnectDB();

            // Check if the team name and coach match in the database
            OracleCommand command = conn.CreateCommand();
            command.CommandText = "SELECT team_name FROM teams WHERE team_name = :teamName AND coach = :coach";
            command.Parameters.Add("teamName", OracleDbType.Varchar2).Value = teamName;
            command.Parameters.Add("coach", OracleDbType.Varchar2).Value = coach;

            OracleDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Login successful");
                Team team = new Team();
                team.LoggedInTeamName = teamName; // Assign logged-in team name
                team.Show();
                this.Hide();

                // Proceed with further actions after successful login
                // For example, open a new form or perform additional tasks
            }
            else
            {
                MessageBox.Show("Invalid team name or coach");
            }

            reader.Close();
            command.Dispose();
            conn.Close();
        }

        private void Teamlogin_Load(object sender, EventArgs e)
        {
            // Code to be executed when the form is loaded
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Code to be executed when label1 is clicked
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Code to be executed when the text in textBox1 is changed
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

