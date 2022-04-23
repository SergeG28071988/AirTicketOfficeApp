using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AirTicketOffice
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\Пк\OneDrive\Документы\CashDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "select count(*) from UsersTbl where Uname='" + Uname.Text + "' and Upass='" + PassTb.Text + "'";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            PassTb.Text = "";
        }
    }
}
