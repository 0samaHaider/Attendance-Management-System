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
    public partial class Leave_Status : Form
    {
        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader sd;
        public Leave_Status()
        {
            InitializeComponent();
        }

        private void Leave_Status_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.recby;
            Con.Open();
            string str = "Select * from leaveModule where Name='"+ label1.Text+"'  ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();

            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView3.DataSource = data;
            Con.Close();
        }
    }
}
