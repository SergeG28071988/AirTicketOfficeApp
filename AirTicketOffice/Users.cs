using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AirTicketOffice
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

       SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\Пк\OneDrive\Документы\CashDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Populate()
        {
            conn.Open();
            string query = "select * from UsersTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            UsersDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || UnameTb.Text == "" || UpassTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into UsersTbl values (" + IdTb.Text + ", '" + UnameTb.Text + "', '" + UpassTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь добавлен");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from UsersTbl where Id=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь удален");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UsersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = UsersDGV.SelectedRows[0].Cells[0].Value.ToString();
            UnameTb.Text = UsersDGV.SelectedRows[0].Cells[1].Value.ToString();
            UpassTb.Text = UsersDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || UnameTb.Text == "" || UpassTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update UsersTbl set Uname='" + UnameTb.Text + "', Upass='" + UpassTb.Text + "' where Id=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь изменен");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.Show();
            this.Hide();
        }
    }        
}
