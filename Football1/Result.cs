using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Football1
{
    public partial class Result : Form
    {
        OracleConnection conn;
        public Result()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int matchNo = Convert.ToInt32(textBox1.Text);
            string homeTeamName = textBox4.Text;
            string awayTeamName = textBox6.Text;
            string matchWinner = textBox3.Text;
            string matchLoser = textBox5.Text;
            string tossWinner = textBox2.Text; // New tossWinner input

            string connString = "Data Source=ORCL;User ID=SYSTEM;Password=iamthebest";
            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand("InsertPlayAndUpdatePoints", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("match_no", OracleDbType.Int32).Value = matchNo;
                    cmd.Parameters.Add("h_team_name", OracleDbType.Varchar2).Value = homeTeamName;
                    cmd.Parameters.Add("a_team_name", OracleDbType.Varchar2).Value = awayTeamName;
                    cmd.Parameters.Add("match_winner", OracleDbType.Varchar2).Value = matchWinner;
                    cmd.Parameters.Add("match_loser", OracleDbType.Varchar2).Value = matchLoser;
                    cmd.Parameters.Add("toss_winner", OracleDbType.Varchar2).Value = tossWinner; // Add toss_winner parameter
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Result saved successfully!");
                }
            }
        }
        






        }
}

