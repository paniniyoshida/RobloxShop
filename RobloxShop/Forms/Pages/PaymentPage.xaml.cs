using RobloxShop.Entities;
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
    /// Логика взаимодействия для PaymentPage.xaml
    /// </summary>
    public partial class PaymentPage : Page
    {
        private readonly IPaymentService _paymentService;

        public PaymentPage()
        {
            InitializeComponent();

            _paymentService = DependencyResolver.GetService<IPaymentService>();
            Reload();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentWindow paymentWindow = new AddPaymentWindow();
            paymentWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as PaymentViewData;
            if (viewdata != null)
            {
                _paymentService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as PaymentViewData;
            UpdatePaymentWindow paymentWindow = new UpdatePaymentWindow(viewdata.Id);
            paymentWindow.ShowDialog();
            Reload();
        }


        void Reload()
        {
            table_grid.ItemsSource = _paymentService.GetAll().Select(t => new PaymentViewData
            {
                Id = t.Id,
                PaymentProvider = t.PaymentProvider.Name,
                CheckID = t.CheckID
            });
        }

        private class PaymentViewData
        {
            public int Id { get; set; }

            public string PaymentProvider { get; set; }

            public int CheckID { get; set; }
        }
    }
}
