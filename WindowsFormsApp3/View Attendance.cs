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

   
    

    public partial class Mark_Attendance: Form
    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sd;
        public Mark_Attendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string str = "Select * from attendance where username = '"+ label1.Text+"'";
          //  string q = "select * from SIGNUP where email ='" + textBox1.Text + "' and pass= '" + textBox2.Text + "'   ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();
            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView1.DataSource = data;
            Con.Close();
        }

        private void Mark_Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbProjectDataSet6.leaveModule' table. You can move, or remove it, as needed.
            this.leaveModuleTableAdapter.Fill(this.dbProjectDataSet6.leaveModule);
            label1.Text = Form1.recby;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
