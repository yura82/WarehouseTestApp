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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WarehouseTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WarehouseLINQDataContext cxt = new WarehouseLINQDataContext(Properties.Settings.Default.WareHouseBConnectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string paswoord = txtPaswoord.Password;
            if (txtUsername.Text == "" || txtPaswoord.Password == "")
            {
                MessageBox.Show("Please fill in User name and Pasword ");
            }

            var checkPaswoord = cxt.Paswoords.Where(p => p.UserName == username && p.UserPaswoord == paswoord).Count();
            if (checkPaswoord == 1)
            {
                Paswoord login = cxt.Paswoords.Where(p => p.UserName == username).FirstOrDefault();
                ShoppingMenu shoppingMenu = new ShoppingMenu();
                shoppingMenu.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Not corect paswoord or username", "Error Box");
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string paswoord = txtPaswoord.Password;
            var checkAdmin = cxt.Paswoords.Where(ap => ap.UserName == username && ap.UserPaswoord == paswoord && ap.UserId == 1).Count();
            if (checkAdmin == 1)
            {
                Paswoord login = cxt.Paswoords.Where(p => p.UserName == username).FirstOrDefault();
                AdminScreen adminScreen = new AdminScreen();
                adminScreen.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("You are not administrator");
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            RegistrationMenu registration = new RegistrationMenu();
            registration.Show();
            this.Close();
        }
    }
}
