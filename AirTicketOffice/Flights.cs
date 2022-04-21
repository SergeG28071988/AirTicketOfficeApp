using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AirTicketOffice
{
    public partial class Flights : Form
    {
        public Flights()
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
            string query = "select * from Рейсы";
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            FlightsDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || DepartureDateTb.Text == "" || DirectionTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Рейсы values ('" + RegNumTb.Text + "', '" + DepartureDateTb.Text + "', '" + DirectionTb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Рейсы добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Flights_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from Рейсы where [Номер рейса]='" + RegNumTb.Text + "';";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Рейсы удалены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FlightsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNumTb.Text = FlightsDGV.SelectedRows[0].Cells[0].Value.ToString();
            DepartureDateTb.Text = FlightsDGV.SelectedRows[0].Cells[1].Value.ToString();
            DirectionTb.Text = FlightsDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || DepartureDateTb.Text == "" || DirectionTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Рейсы set Дата='" + DepartureDateTb.Text + "', Направление='" + DirectionTb.Text + "' where [Номер рейса]='" + RegNumTb.Text + "';";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Рейсы обновлены");
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
