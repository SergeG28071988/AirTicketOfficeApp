using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirTicketOffice
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            AppContext db = new AppContext();
            List<User> users = db.Users.ToList();

            listofUsers.ItemsSource = users;
        }

        private void Button_Menu_Click(object sender, RoutedEventArgs e)
        { 
            Splash splash = new Splash();
            splash.Show();
            Hide();
        }
    }
}
            