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
        public MainWindow()
        {
            InitializeComponent();
            page_frame.Content = new TagPage();
        }

        private void previous_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}