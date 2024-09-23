using Azure;
using RobloxShop.Entities.Enums;
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

        List<Page> userPages = new List<Page> { new CheckPage(), new CheckPositionsPage(), new PaymentPage(), new ProductCartPage(), new ProductCartItemPage() };


        List<Page> allPages = new List<Page> { new CategoryPage(), new CheckPage(), new CheckPositionsPage(), new PaymentPage(), new PaymentProviderPage(), new ProductCartPage(), new ProductCartItemPage(), new PromocodePage(), new TagPage(), new UserPage(), new WarehousePage(), new WarehouseStockPage() };

        List<Page> pagesToView;

        public MainWindow(Role role)
        {
            InitializeComponent();

            userPages.Add(new ProductPage(role));
            allPages.Add(new ProductPage(role));



            if (role == Role.Admin)
            {
                pagesToView = allPages;
                page_frame.Content = new TagPage();
            }
            else
            {
                pagesToView = userPages;
                page_frame.Content = new CheckPage();
            }

        }

        private void previous_button_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage == -1)
                currentPage = pagesToView.Count - 1;

            page_frame.Content = pagesToView[currentPage];
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if (currentPage == pagesToView.Count)
                currentPage = 0;

            page_frame.Content = pagesToView[currentPage];
        }
    }
}