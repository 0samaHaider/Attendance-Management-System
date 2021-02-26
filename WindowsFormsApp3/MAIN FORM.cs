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
using System.IO;
namespace WindowsFormsApp3
    
{
    public partial class MAIN_FORM : Form
    {

        readonly SqlConnection Con = new SqlConnection(@" Data Source = OSAMAHAIDER; Initial Catalog = DbProject; Integrated Security = True");
        SqlCommand cmd;
        string imgloc;
        SqlCommand command;
        SqlDataAdapter da;
        DataSet ds; int rno = 0;
        SqlDataAdapter adapter;
        string email;
        SqlDataReader reader;


        byte[] photo_aray;
        SqlDataReader sd;
        public MAIN_FORM()
        {
            InitializeComponent();
        }
        public void save()
        {
            byte[] images ;
            FileStream streem = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            Con.Open();
            string picinsert = "insert into img (email,pic) values ('" + textBox3.Text + "', @pic) ";
            cmd = new SqlCommand(picinsert, Con);
            cmd.Parameters.Add(new SqlParameter("@pic", images));
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Image Inserted  !!");

        }

        public void saveimg()
        {
            byte[] images = null;
            FileStream streem = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            Con.Open();
            string picinsert = "insert into img (email,pic) values ('"+textBox3.Text+"', @pic) ";
            cmd = new SqlCommand(picinsert, Con);
            cmd.Parameters.Add(new SqlParameter("@pic" ,images));
           cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Image Inserted  !!");

        }
      
        private void MAIN_FORM_Load(object sender, EventArgs e)
        {
            Retrieve();
            Retrieve();
            //Dashboard_panel.Visible = true;
            Dashboard_panel.Visible = true;
            Mark_Attendance_panel.Visible = false;
            MarkLeave_Panel.Visible = false;
            ViewData_Panel.Visible = false;
            label8.Text= Form1.recby;
            textBox3.Text = Form1.recby;
            label4.Text = DateTime.Now.ToLongDateString();
            label5.Text = DateTime.Now.ToLongTimeString();
            label12.Text = DateTime.Now.ToLongDateString();
            label11.Text = DateTime.Now.ToLongTimeString();
            string lasttime = "Select time from attendance where username= '"+ label8.Text+"' ";
           // string lastClickedOn = lasttime ; // The time from the database.
            string now = DateTime.Now.ToLongDateString();


            // Check if the click time is more than, or exactly, 24 hours ago.
           // if (n <lasttime.ToString())
                
            { }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Con.Open();
            string insert = "insert into leaveModule(Name , Subject , Reason,date ) values ('" + textBox3.Text + "' , '" + textBox1.Text + "' ,'" + textBox2.Text + "', '"+label12.Text+"' )";
            cmd = new SqlCommand(insert, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Leave Submit !");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
           // label8.Text= 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string insert = "insert into attendance(username ,time , date, attt) values ('" + label8.Text + "' , '" + label5.Text + "' ,'" + label4.Text + "', '"+ comboBox1.Text+"' )";
            cmd = new SqlCommand(insert, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();
            MessageBox.Show("Data Inserted !");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mark_Attendance Mark = new Mark_Attendance();
            Mark.ShowDialog();
        }

        public void Retrieve()
        {


            Con.Open();

            cmd = new SqlCommand("select pic from img where email = '" +textBox3.Text+"'", Con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)

            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["pic"]);

                pictureBox1.Image = new Bitmap(ms);

            }
            Con.Close();


        }
        public void dell()
        {
            if (email != "")
            {
                //  Retrieve();
                Con.Open();
                string del = "Delete  from  img where email='" + textBox3.Text + "'";
                cmd = new SqlCommand(del, Con);
                cmd.ExecuteNonQuery();
                cmd.Clone();
                Con.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {


           

            

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "png files(*.png)|*.png|  jpg files(*.jpg)|*.jpg| All files(*.*)|*.*  ";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dialog.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                }
                saveimg();
                Retrieve();
            
         

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.ShowDialog();   
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToLongTimeString();
            timer2.Start();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = true;
            Mark_Attendance_panel.Visible = false;
            MarkLeave_Panel.Visible = false;
            ViewData_Panel.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mark_Attendance_panel.Visible = true;
            MarkLeave_Panel.Visible = false;
            ViewData_Panel.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MarkLeave_Panel.Visible = true;
            ViewData_Panel.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewData_Panel.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Dashboard_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Dashboard_panel.Visible = true;
            Mark_Attendance_panel.Visible = false;
            MarkLeave_Panel.Visible = false;
            ViewData_Panel.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Mark_Attendance_panel.Visible = true;
            MarkLeave_Panel.Visible = false;
            ViewData_Panel.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MarkLeave_Panel.Visible = true;
            ViewData_Panel.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ViewData_Panel.Visible = true;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void MarkLeave_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewData_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Mark_Attendance_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Leave_Status l = new Leave_Status();
            l.ShowDialog();
        }
        void showdata()
        {
        
          
        }
        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|  jpg files(*.jpg)|*.jpg| All files(*.*)|*.*  ";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgloc = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgloc;
            }
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();
            Con.Open();
            string updates = "UPDATE img  set email= '" + textBox3.Text + "' ,pic ='" + pictureBox1 + "'";
            cmd = new SqlCommand(updates, Con);
            cmd.ExecuteNonQuery();
            cmd.Clone();
            Con.Close();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Retrieve();
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            dell();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|  jpg files(*.jpg)|*.jpg| All files(*.*)|*.*  ";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgloc = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgloc;
            }
            saveimg();
            Retrieve();
            save();
            Retrieve();
        }
    }
}
