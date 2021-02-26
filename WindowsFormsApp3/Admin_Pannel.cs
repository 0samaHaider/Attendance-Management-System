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
    public partial class Admin_Pannel : Form
    {

        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
       // string da;
        SqlDataReader sd;
        SqlDataAdapter da;
        public Admin_Pannel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                string updat = "Update leaveModule set Remarks ='" + comboBox1.Text + "'where Name ='" + textBox1.Text + "' ";
                cmd = new SqlCommand(updat, Con);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                Con.Close();
                MessageBox.Show("Data Updated !");
                retrieve();
            }
            catch
            {
                MessageBox.Show("Please check your entry !!");
            }
        }
        public void retrieve()
        {
            Con.Open();
            string str = "Select * from leaveModule ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();

            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView3.DataSource = data;
            Con.Close();
        }
        public void retrievesAtt()
        {
            Con.Open();
            string str = "Select * from attendance where username= '" + comboBox2.Text + " '";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();

            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView1.DataSource = data;
            Con.Close();
        }
        public void retrievesgrade()
        {
            Con.Open();
            string str = "Select * from attendance where username= '" + comboBox4.Text + " '";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();

            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView2.DataSource = data;
            Con.Close();
        }
        private void Admin_Pannel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbProjectDataSet10.SIGNUP' table. You can move, or remove it, as needed.
            this.sIGNUPTableAdapter1.Fill(this.dbProjectDataSet10.SIGNUP);
            Dashboard_panel.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            label14.Text = DateTime.Now.ToLongTimeString();
            label15.Text = DateTime.Now.ToLongDateString();
            // TODO: This line of code loads data into the 'dbProjectDataSet9.SIGNUP' table. You can move, or remove it, as needed.
            this.sIGNUPTableAdapter.Fill(this.dbProjectDataSet9.SIGNUP);
            // TODO: This line of code loads data into the 'dbProjectDataSet8.attendance' table. You can move, or remove it, as needed.
            this.attendanceTableAdapter.Fill(this.dbProjectDataSet8.attendance);
            // TODO: This line of code loads data into the 'dbProjectDataSet7.leaveModule' table. You can move, or remove it, as needed.
            this.leaveModuleTableAdapter.Fill(this.dbProjectDataSet7.leaveModule);

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          textBox1.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            retrievesAtt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string insertuser = "UPDATE attendance SET attt ='" +comboBox3.Text + "'WHERE username='" + comboBox2.Text + "'and date='" + dateTimePicker1.Text + "'";
            cmd = new SqlCommand(insertuser, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();

            MessageBox.Show("Successfully Updated!");
            retrievesAtt();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Con.Open();
            string dell = "Delete from attendance WHERE username='" + comboBox2.Text + "'and date='" + dateTimePicker1.Text + "'";
            cmd = new SqlCommand(dell, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();

            MessageBox.Show("Successfully Deleted!");
            retrievesAtt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "C:";
            saveFileDialog1.Title = "Save as Excel File ";
          //  saveFileDialog1.Filter= 
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string dt = "SELECT * FROM attendance WHERE date BETWEEN'" + dateTimePicker2.Text + "' AND '" + dateTimePicker3.Text + "'";
                cmd = new SqlCommand(dt, Con);
                DataTable data = new DataTable();

                sd = cmd.ExecuteReader();
                data.Load(sd);
                dataGridView4.DataSource = data;
                Con.Close();
            }


            catch
            {
                MessageBox.Show("No data Found ");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Con.Open();
            string str = "SELECT * FROM attendance WHERE username = '" + comboBox5.Text + "'  and  date BETWEEN '" + dateTimePicker4.Text + "' AND '" + dateTimePicker5.Text + "' ";
            cmd = new SqlCommand(str, Con);
            DataTable data = new DataTable();

            sd = cmd.ExecuteReader();
            data.Load(sd);
            dataGridView5.DataSource = data;
            Con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            retrievesgrade();
            int countrow = dataGridView2.Rows.Count;
            if (dataGridView2.Rows.Count >= 25)
            {
                label3.Text = "Grade is A";
            }
           else  if (dataGridView2.Rows.Count >=18)
            {
                label3.Text = "Grade is B";
            }
            else if (dataGridView2.Rows.Count >= 12)
            {
                label3.Text = "Grade is C";
            }
            else if (dataGridView2.Rows.Count <=10)
            {
                label3.Text = "Grade is D ";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            
            panel5.Visible = true;
            panel6.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {

            panel5.Visible = true;
            panel6.Visible = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
