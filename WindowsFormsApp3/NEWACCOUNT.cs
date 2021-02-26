using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    public partial class NEWACCOUNT : Form
    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;

        public NEWACCOUNT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            Con.Open();
            string insert = "insert into SIGNUP(name,email,pass) values ('" + textBox1.Text + "' , '" + textBox4.Text + "' ,'" + textBox2.Text + "' )";
            cmd = new SqlCommand(insert, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Data Inserted !");
            textBox1.Text="";
            textBox4.Text = "";
            textBox2.Text = "";


        }

        private void NEWACCOUNT_Load(object sender, EventArgs e)
        {

        }
    }
}
