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

namespace Football1
{
    public partial class Admin : Form
    {
        OracleConnection conn;
        private DataTable teamsTable;
        public Admin()
        {
            InitializeComponent();
            conn = new OracleConnection();
            conn.ConnectionString = "DATA SOURCE=ORCL;USER ID=SYSTEM;PASSWORD =iamthebest";
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AAdd a1= new AAdd();
            a1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ADPlayers d1=new ADPlayers();
            d1.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AAddP ap=new AAddP();
            ap.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql = "SELECT * FROM teams";
                OracleDataAdapter adapter = new OracleDataAdapter(sql, conn);
                teamsTable = new DataTable();
                adapter.Fill(teamsTable);

                dataGridView1.DataSource = teamsTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve data from 'teams' table: " + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string sql1 = "SELECT * FROM players";
                OracleDataAdapter adapter = new OracleDataAdapter(sql1, conn);
                teamsTable = new DataTable();
                adapter.Fill(teamsTable);

                dataGridView1.DataSource = teamsTable;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve data from 'players' table: " + ex.ToString());
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddHost host = new AddHost(); 
            host.Show();
            this.Hide();
        }
    }
}
