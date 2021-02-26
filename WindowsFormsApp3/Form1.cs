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
    public partial class Form1 : Form

    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        string cmd,dr;
        
        public static string setUsernameValue = "";
        public Form1()
        {

            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NEWACCOUNT tc = new NEWACCOUNT();
            tc.ShowDialog();
        }
        public static string username;
        public static string recby
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Student")
            {



                string q = "select * from SIGNUP where email ='" + textBox1.Text + "' and pass= '" + textBox2.Text + "'   ";
                SqlDataAdapter sda = new SqlDataAdapter(q, Con);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                try
                {
                    if (dtbl.Rows.Count == 1)
                    {
                        recby = textBox1.Text;
                        MAIN_FORM M = new MAIN_FORM();
                        this.Hide();
                        Con.Close();
                        setUsernameValue = textBox1.Text;
                        M.Show();

                    }
                    else
                    {
                        MessageBox.Show("Please check your Email or Pass !!");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                    }

                }
                catch { }
            }
           else if (comboBox1.Text == "Admin")
            {
                if (textBox1.Text == "admin" && textBox2.Text == "123")
                {
                    Admin_Pannel Ad = new Admin_Pannel();
                    Ad.Show();
                    textBox1.Clear();
                    textBox2.Clear();

                    Form1 f = new Form1();
                    f.Close();
                }
                else
                {
                    MessageBox.Show("Please check your Email or Pass !!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else 
            {
                MessageBox.Show("Please check your Email or Pass !!");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
