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
    public partial class tran : Form
    {
        public tran()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from trans", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;         
            con.Close();
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from trans where acc_no='"+ textBox1.Text +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlCommand cmdd = new SqlCommand("select balance from account where accnt_no='" + textBox1.Text + "'",con);
            
            SqlDataReader dr=cmdd.ExecuteReader();
            if (dr.Read())
            {

                label7.Text = dr.GetValue(0).ToString();
            }
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("select payable_amount from account where accnt_no='" + textBox1.Text + "'",con);
            SqlDataReader drr = cmd.ExecuteReader();
            if (drr.Read())
            {

                label8.Text = drr.GetValue(0).ToString();
            }
            con.Close();
            con.Open();

            SqlCommand cm = new SqlCommand("select paid_amount from account where accnt_no='" + textBox1.Text + "'",con);
            SqlDataReader drrr = cm.ExecuteReader();
            if (drrr.Read())
            {

                label9.Text = drrr.GetValue(0).ToString();
            }
            con.Close();
            con.Open();
            SqlCommand c = new SqlCommand("select interest from account where accnt_no='" + textBox1.Text + "'",con);

            SqlDataReader drrrr = c.ExecuteReader();
            if (drrrr.Read())
            {

                label10.Text = drrrr.GetValue(0).ToString();
            }
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            int a = Int32.Parse(textBox2.Text);
            string st;
            int pd;
            SqlDataAdapter sda = new SqlDataAdapter("insert into trans (acc_no,paid_amount,date) values ('"+textBox1.Text+"','"+a+"',getdate())", con);
            sda.SelectCommand.ExecuteNonQuery();
            SqlDataAdapter sdt = new SqlDataAdapter("select * from trans", con);
            DataTable dt = new DataTable();
            sdt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            con.Open();

            SqlCommand sd = new SqlCommand("select sum(paid_amount) from trans where acc_no='" + textBox1.Text + "'", con);
            SqlDataReader dr = sd.ExecuteReader();
            if (dr.Read())
            {
                st = dr.GetValue(0).ToString();
                 
            }
            pd = Int32.Parse(dr.GetValue(0).ToString());
            con.Close();
            con.Open();
            SqlDataAdapter s = new SqlDataAdapter("update account set balance='"+ pd +"',paid_amount='"+ pd +"' where accnt_no='"+ textBox1.Text +"'",con);
            s.SelectCommand.ExecuteNonQuery();
            con.Close();

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from trans where acc_no like '"+ textBox1.Text +"%'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
