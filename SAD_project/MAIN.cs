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
    public partial class root : Form
    {
        public root()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select accnt_no,name,nid,gender,yr,phn from reg",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        string ac;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select accnt_no,name,nid,gender,yr,phn from reg where accnt_no like '"+ textBox1.Text +"%'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tran tr = new tran();
            tr.Show();          
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    this.dataGridView1.Rows[rowSelected].Selected = true;
                }
                
                ac = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                
            }
        }

        private void openANewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regis rg = new regis();
            rg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SALMAN-PC\SQLEXPRESS;Initial Catalog=SAD;Integrated Security=True;");
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("delete from reg where accnt_no='"+ ac +"'",con);
            SqlDataAdapter sd = new SqlDataAdapter("delete from trans where acc_no='" + ac + "'", con);
            SqlDataAdapter s = new SqlDataAdapter("delete from account where accnt_no='" + ac + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            con.Open();
            sd.SelectCommand.ExecuteNonQuery();
            con.Close();
            con.Open();
            s.SelectCommand.ExecuteNonQuery();
            con.Close();

        }
    }
}
