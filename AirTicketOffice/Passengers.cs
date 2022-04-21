using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AirTicketOffice
{
    public partial class Passengers : Form
    {
        public Passengers()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;
Data Source=C:\Users\Пк\OneDrive\Desktop\Авиакасса.mdb");

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Populate()
        {
            conn.Open();
            string query = "select * from Пассажиры";
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            PassengersDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || SurnameTb.Text == "" || NameTb.Text == "" || PassportTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Пассажиры values (" + IdTb.Text + ", '" + SurnameTb.Text + "', '" + NameTb.Text + "', '" + PassportTb.Text + "', '" + PhoneTb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пассажиры добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Passengers_Load(object sender, EventArgs e)
        {
            Populate();
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
                    string query = "delete from Пассажиры where [Код пассажира]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пассажиры удалены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void PassengersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = PassengersDGV.SelectedRows[0].Cells[0].Value.ToString();
            SurnameTb.Text = PassengersDGV.SelectedRows[0].Cells[1].Value.ToString();
            NameTb.Text = PassengersDGV.SelectedRows[0].Cells[2].Value.ToString();
            PassportTb.Text = PassengersDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = PassengersDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || SurnameTb.Text == "" || NameTb.Text == "" || PassportTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Пассажиры set Фамилия='" + SurnameTb.Text + "', Имя='" + NameTb.Text + "', Паспорт='" + PassportTb.Text + "', Телефон='" + PhoneTb.Text + "' where [Код пассажира]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пассажиры обновлены");
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
