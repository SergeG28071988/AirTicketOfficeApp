using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AirTicketOffice
{
    public partial class Sales : Form
    {
        public Sales()
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
            string query = "select * from Продажи";
            OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            SalesDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
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
                    string query = "delete from Продажи where [Код билета]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные о продажах удалены");
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

        private void SalesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = SalesDGV.SelectedRows[0].Cells[0].Value.ToString();
            PassengerTb.Text = SalesDGV.SelectedRows[0].Cells[1].Value.ToString();
            DirectionTb.Text = SalesDGV.SelectedRows[0].Cells[2].Value.ToString();
            QuantityTb.Text = SalesDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = SalesDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = SalesDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            double quantity;
            double price;

            quantity = Convert.ToDouble(QuantityTb.Text);
            price = Convert.ToDouble(PriceTb.Text);

            switch (guna2ComboBox1.Text)
            {
                case "*":
                    AmountTb.Text = Convert.ToString(quantity * price);
                    break;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || PassengerTb.Text == "" || DirectionTb.Text == "" 
                || QuantityTb.Text == "" || PriceTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into Продажи  values (" + IdTb.Text + ", '" + PassengerTb.Text + "', '" + DirectionTb.Text + "', " +
                        "'" + QuantityTb.Text + "', '" + PriceTb.Text + "', '" + AmountTb.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные о продажах добавлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || PassengerTb.Text == "" || DirectionTb.Text == ""
                || QuantityTb.Text == "" || PriceTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update Продажи set Пассажир='" + PassengerTb.Text + "', Направление='" + DirectionTb.Text + "', " +
                        "Количество='" + QuantityTb.Text + "', Цена='" + PriceTb.Text + "', Сумма='" + AmountTb.Text + "'" +
                        " where [Код билета]=" + IdTb.Text + ";";
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные о продажах обновлены");
                    conn.Close();
                    Populate();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
