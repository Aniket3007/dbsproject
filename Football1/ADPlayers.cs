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
    public partial class ADPlayers : Form
    {
        OracleConnection conn;
        string name1;
        string name2;
        public ADPlayers()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("Data Source=ORCL;User ID=SYSTEM;PASSWORD=iamthebest");
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

        private void DPlayers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name1=this.textBox1.Text;
            name2=this.textBox2.Text;
            ConnectDB();
            OracleCommand command1 = conn.CreateCommand();
            command1.CommandText = "delete from players where Fname= '"+name1+"' and lname= '"+name2+"'";
            command1.CommandType = CommandType.Text;
            command1.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            command1.Dispose();
            conn.Close();
            Admin a2= new Admin();
            a2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
