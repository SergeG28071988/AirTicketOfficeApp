using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UserWindow window = new UserWindow();
            window.Show();
            Hide();
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
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            sales.Show();            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Hide();
        }
    }
}
