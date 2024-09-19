using Azure;
using RobloxShop.Forms.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RobloxShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentPage = 0;
        Page[] allPages = new Page[] { new CategoryPage(), new CheckPage(), new CheckPositionsPage(), new PaymentPage(), new PaymentProviderPage(), new ProductPage(), new ProductCartPage(), new ProductCartItemPage(), new PromocodePage(), new TagPage(), new UserPage(), new WarehousePage(), new WarehouseStockPage() };
        public MainWindow()
        {
            InitializeComponent();
            page_frame.Content = new TagPage();
        }

        private void previous_button_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage == -1)
                currentPage = allPages.Length - 1;

            page_frame.Content = allPages[currentPage];
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage == allPages.Length)
                currentPage = 0;

            page_frame.Content = allPages[currentPage];
        }
    }
}