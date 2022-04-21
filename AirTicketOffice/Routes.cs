using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AirTicketOffice
{
    public partial class Routes : Form
    {
        public Routes()
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
            string query = "select * from Маршруты";
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RoutesDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || Airport1Tb.Text == "" || Airport2Tb.Text == "" || PriceTb.Text == "" || TimeTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Маршруты values (" + IdTb.Text + ", '" + Airport1Tb.Text + "', '" + Airport2Tb.Text + "', '" + PriceTb.Text + "', '" + TimeTb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Маршруты добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Routes_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" )
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from Маршруты where [Код маршрута]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Маршруты удалены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RoutesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RoutesDGV.SelectedRows[0].Cells[0].Value.ToString();
            Airport1Tb.Text = RoutesDGV.SelectedRows[0].Cells[1].Value.ToString();
            Airport2Tb.Text = RoutesDGV.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = RoutesDGV.SelectedRows[0].Cells[3].Value.ToString();
            TimeTb.Text = RoutesDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || Airport1Tb.Text == "" || Airport2Tb.Text == "" || PriceTb.Text == "" || TimeTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Маршруты set [Аэропорт вылета]='" + Airport1Tb.Text + "', [Аэропорт прибытия]='" + Airport2Tb.Text + "',  [Цена билета]='" + PriceTb.Text + "', [Время полета]= '" + TimeTb.Text + "' where [Код маршрута]="+IdTb.Text+";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Маршруты обновлены");
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
