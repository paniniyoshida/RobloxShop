using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
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
using System.Windows.Shapes;

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPaymentProviderWindow.xaml
    /// </summary>
    public partial class AddPaymentProviderWindow : Window
    {

        private readonly IPaymentProviderService _paymentProviderService;

        public AddPaymentProviderWindow()
        {
            InitializeComponent();

            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(addProviderName.Text))
            {
                MessageBox.Show("Не написано название провайдера!");
                return;
            }

            PaymentProvider paymentProvider = new PaymentProvider()
            {
                Name = addProviderName.Text,
                CreationDate = DateTime.UtcNow,
            };

            _paymentProviderService.Add(paymentProvider);

            Close();
        }
    }
}
