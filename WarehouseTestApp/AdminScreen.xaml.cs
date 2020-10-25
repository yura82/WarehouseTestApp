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
    /// Interaction logic for AdminScreen.xaml
    /// </summary>
    public partial class AdminScreen : Window
    {
        WarehouseLINQDataContext cxt = new WarehouseLINQDataContext(Properties.Settings.Default.WareHouseBConnectionString);
        public AdminScreen()
        {
            InitializeComponent();
            if (cxt.DatabaseExists()) dataKlanten.ItemsSource = cxt.Klants;
            {

            }
           
        }

       

        private void btnSaveChanges_Click_1(object sender, RoutedEventArgs e)
        {
            cxt.SubmitChanges();
        }
    }
}
