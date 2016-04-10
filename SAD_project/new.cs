using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SAD_project
{
    public partial class regis : Form
    {
        public regis()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int expr = Int32.Parse(comboBox2.Text);
            int b = 0;
            int pa=0;
            if(expr==3)
            {
                pa=(12*3)*2400;
            }
            else if(expr==5)
            {
                pa=(5*12)*1200;
            }
            else if(expr==10)
            {
                pa=(10*12)*800;
            }
            else if(expr==15)
            {
                pa=(15*12)*500;
            }
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            DateTime cr = DateTime.Now;
            DateTime dt = cr.AddYears(expr);
            
            SqlDataAdapter sda = new SqlDataAdapter("insert into reg (accnt_no,name,nid,gender,fathers_name,mothers_name,phn,adr,yr,strr,endd) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+comboBox1.Text+"','"+textBox4.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+textBox9.Text+"','"+ expr +"',getdate(),'"+ dt +"')",con);
            SqlDataAdapter sd = new SqlDataAdapter("insert into account (accnt_no,balance,payable_amount,paid_amount,interest) values('"+ textBox1.Text +"','"+ b +"','"+ pa +"','"+ b +"',5)",con);
            sd.SelectCommand.ExecuteNonQuery();
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registration Successfully!!!");
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
           
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";


        }
    }
}
