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
    public partial class Team : Form
    {
        OracleConnection conn;
        private DataTable teamsTable;
        public string LoggedInTeamName { get; set; }
        
        public Team()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString = "DATA SOURCE=ORCL;USER ID=SYSTEM;PASSWORD =iamthebest";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = LoggedInTeamName;
            
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            TeamAddP team = new TeamAddP();
            team.teamadd = LoggedInTeamName;
            team.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = "SELECT * FROM Points_Table";
                OracleDataAdapter adapter = new OracleDataAdapter(sql, conn);
                teamsTable = new DataTable();
                adapter.Fill(teamsTable);

                dataGridView1.DataSource = teamsTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve data from 'Points_Table' table: " + ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
