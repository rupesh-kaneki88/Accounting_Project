using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccProject
{
    public partial class LoginForm : Form
    {
       
        private static string myconn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:/project/C#/Accounting SW/Database/AccountingSW.accdb";
        public OleDbConnection conn = new OleDbConnection(myconn);
        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //MessageBox.Show("Connection open");
            }

        }

        public LoginForm()
        {
            InitializeComponent();
        }
        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "Username")
            {
                textBoxUsername.Text = "";
            }


        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Text = "";
            }

        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                textBoxUsername.Text = "Username";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Password";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SetConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd = new OleDbCommand("INSERT INTO logininfo (Usernm,Pass) values ('" + textBoxUsername.Text + "','" + textBoxPassword.Text + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registration completed");
            conn.Close();
        }

        private void textBoxUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SetConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd = new OleDbCommand("select * from [logininfo] where Usernm='" + textBoxUsername.Text + "' and Pass= '" + textBoxPassword.Text + "'", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                MessageBox.Show("Login correct");
                this.Hide();
                OpenMenu();
            }
            else
            {
                MessageBox.Show("Login Incorrect");
            }
            conn.Close();
        }
        private void OpenMenu()
        {
            Menu a = new Menu();
            a.Visible = true;
            a.Dock = DockStyle.Fill;
            a.Show();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.Focus();
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
