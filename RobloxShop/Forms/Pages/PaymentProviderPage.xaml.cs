using RobloxShop.Forms.Windows;
using RobloxShop.Forms.Windows.Update;
using RobloxShop.Services;
using RobloxShop.Services.Interfaces;
using RobloxShop.Utils;
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

namespace RobloxShop.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для PaymentProviderPage.xaml
    /// </summary>
    public partial class PaymentProviderPage : Page
    {
        private readonly IPaymentProviderService _paymentProviderService;

        public PaymentProviderPage()
        {
            InitializeComponent();

            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentProviderWindow paymentProviderWindow = new AddPaymentProviderWindow();
            paymentProviderWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as PaymentProviderViewData;
            if (viewdata != null)
            {
                _paymentProviderService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as PaymentProviderViewData;
            UpdatePaymentProviderWindow paymentProviderWindow = new UpdatePaymentProviderWindow(viewdata.Id);
            paymentProviderWindow.ShowDialog();
            Reload();
        }


        void Reload()
        {
            table_grid.ItemsSource = _paymentProviderService.GetAll().Select(t => new PaymentProviderViewData
            {
                Id = t.Id,
                Name = t.Name,
                CreationDate = t.CreationDate.ToShortDateString()
            });
        }

        private class PaymentProviderViewData
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string CreationDate { get; set; }
        }

    }
}
