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

namespace StudentInfo
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Intials Catalog=Library;Integrated Security=True;Pooling=False");
        public Register()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Clear();
            this.comboBox1.SelectedItem = -1;
            this.comboBox2.SelectedItem = -1;
            this.textBox3.Text = "";
            this.textBox4.Clear();
            this.textBox5.Text = "";
            this.textBox6.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 r = new Form1();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                String uid = textBox1.Text;
                String name = textBox2.Text;
                String desg = comboBox1.SelectedItem.ToString();
                String dept = comboBox2.SelectedItem.ToString();
                long mobile = Int64.Parse(textBox3.Text);
                String email = textBox4.Text;
                String username = textBox5.Text;
                String password = textBox6.Text;
                con.Open();
                String qry = "insert into into RegUser(uid,name,desg,dept,mobile,email,username,password) values ('"+uid+"','"+name+"','"+desg+"','"+dept+"',"+mobile+",'"+email+"','"+username+"','"+password+"')";
                SqlCommand cmd = new SqlCommand(qry, con);
                int i=cmd.ExecuteNonQuery();
                if(i>=1)
                MessageBox.Show(i+ " Number of User Registered with username:"+username);
                else
                    MessageBox.Show(i + " User Registered failed with username:" + username);
                con.Close();
                button2_Click(sender, e);
            } catch(System.Exception exp){
                MessageBox.Show("Some Error Occured at User Registration :" + e.ToString());

            }
        }
    }
}
 