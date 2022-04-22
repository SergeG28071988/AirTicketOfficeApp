using System;
using System.Windows.Forms;

namespace AirTicketOffice
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }     

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }      
        private void RouteBtn_Click(object sender, EventArgs e)
        {
            Routes routes = new Routes();   
            routes.Show();
            this.Hide();
        }

        private void FlightBtn_Click(object sender, EventArgs e)
        {
            Flights flights = new Flights();
            flights.Show();
            this.Hide();
        }

        private void PassengersBtn_Click(object sender, EventArgs e)
        {
            Passengers passengers = new Passengers();
            passengers.Show();
            this.Hide();
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }
    }
}
