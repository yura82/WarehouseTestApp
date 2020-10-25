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

namespace WarehouseTestApp
{
    /// <summary>
    /// Interaction logic for RegistrationMenu.xaml
    /// </summary>
    public partial class RegistrationMenu : Window
    {
        WarehouseLINQDataContext cxt = new WarehouseLINQDataContext(Properties.Settings.Default.WareHouseBConnectionString);
        public RegistrationMenu()
        {
            InitializeComponent();
        }

        private void txtVoornaam_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtVoornaam.Text.Length == 0)
            {
                Voornaam.Visibility = Visibility.Hidden;
            }

        }

        private void txtVoornaam_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtVoornaam.Text.Length == 0)
            {
                Voornaam.Visibility = Visibility.Visible;
            }
        }

        private void txtNaam_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAchternaam.Text.Length == 0)
            {
                Achternaam.Visibility = Visibility.Hidden;
            }

        }

        private void txtNaam_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtAchternaam.Text.Length == 0)
            {
                Achternaam.Visibility = Visibility.Visible;
            }

        }

        private void txtStraatNaam_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtStraatNaam.Text.Length == 0)
            {
                Straatnaam.Visibility = Visibility.Hidden;
            }

        }

        private void txtStraatNaam_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtStraatNaam.Text.Length ==0)
            {
                Straatnaam.Visibility = Visibility.Visible;
            }

        }

        private void txtHuisnumer_GotFocus(object sender, RoutedEventArgs e)
        {

            if (txtHuisnumer.Text.Length == 0)
            {
                Huisnnummer.Visibility = Visibility.Hidden;
            }

        }

        private void txtHuisnumer_LostFocus(object sender, RoutedEventArgs e)
        {

            if (txtHuisnumer.Text.Length == 0)
            {
                Huisnnummer.Visibility = Visibility.Visible;
            }

        }

        private void txtPostcode_GotFocus(object sender, RoutedEventArgs e)
        {

            if (txtPostcode.Text.Length == 0)
            {
                Postcode.Visibility = Visibility.Hidden;
            }

        }

        private void txtPostcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPostcode.Text.Length == 0)
            {
                Postcode.Visibility = Visibility.Visible;
            }

        }

        private void txtGemeente_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtGemeente.Text.Length == 0)
            {
                Gemeente.Visibility = Visibility.Hidden;
            }

        }

        private void txtGemeente_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtGemeente.Text.Length ==0)
            {
                Gemeente.Visibility = Visibility.Visible;
            }
        }

        private void txtGSM_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtGSM.Text.Length == 0)
            {
                GSM.Visibility = Visibility.Hidden;
            }

        }

        private void txtGSM_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtGSM.Text.Length == 0)
            {
                GSM.Visibility = Visibility.Visible;
            }
        }

        private void txtEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                Email.Visibility = Visibility.Hidden;
            }

        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                Email.Visibility = Visibility.Visible;
            }

        }

        private void txtOpmerking_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtOpmerking.Text.Length== 0)
            {
                Opmerking.Visibility = Visibility.Hidden;
            }

        }

        private void txtOpmerking_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOpmerking.Text.Length == 0)
            {
                Opmerking.Visibility = Visibility.Visible;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var allTogether = txtVoornaam.Text + txtAchternaam.Text + txtStraatNaam.Text + txtPostcode.Text + txtHuisnumer.Text + txtGSM.Text + txtEmail.Text + txtOpmerking.Text;
            cxt.Klants.InsertOnSubmit(new Klant { 
                Voornaam = txtVoornaam.Text,Achternaam = txtAchternaam.Text,Straatnaam = txtStraatNaam.Text,Huisnummer = Convert.ToInt32( txtHuisnumer.Text),
            Gemeente = txtGemeente.Text, Postcode = Convert.ToInt32(txtPostcode.Text), AangemaaktOp = dataAngemakt.SelectedDate,Telefoonnummer = Convert.ToInt32( txtGSM.Text), Emaiadress =txtEmail.Text,Opmerking = txtOpmerking.Text});

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                random.Next();
            }
            int randompaswoord = random.Next();
            cxt.Paswoords.InsertOnSubmit(new Paswoord
            {
                UserName = txtVoornaam.Text + txtPostcode.Text,
                UserPaswoord = randompaswoord.ToString(),
                UserType = "Klant"
            });
            MessageBox.Show($"Your user name is{txtVoornaam.Text + txtPostcode.Text} and paswoord is {randompaswoord} ");
            cxt.SubmitChanges();

        }
        public void Reset()
        {
            txtVoornaam.Text = "";
            txtAchternaam.Text = "";
            txtStraatNaam.Text = "";
            txtHuisnumer.Text = "";
            txtPostcode.Text = "";
            txtGemeente.Text = "";
            txtGSM.Text = "";
            txtEmail.Text = "";
            txtOpmerking.Text = "";
;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btnCansel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
