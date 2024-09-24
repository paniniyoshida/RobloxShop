using RobloxShop.Entities;
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

namespace RobloxShop.Forms.Windows.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdatePaymentProviderWindow.xaml
    /// </summary>
    public partial class UpdatePaymentProviderWindow : Window
    {
        private readonly IPaymentProviderService _paymentProviderService;
        private int _paymentProviderId;

        public UpdatePaymentProviderWindow(int paymentProviderId)
        {
            InitializeComponent();
            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
            _paymentProviderId = paymentProviderId;

            PaymentProvider paymentProvider = _paymentProviderService.Get(paymentProviderId);

            addProviderName.Text = paymentProvider.Name;
        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(addProviderName.Text))
            {
                MessageBox.Show("Название должно быть заполнено");
                return;
            }

            PaymentProvider paymentProvider = new PaymentProvider()
            {
                Id = _paymentProviderId,
                Name = addProviderName.Text,
                CreationDate = DateTime.UtcNow,
            };

            _paymentProviderService.Update(paymentProvider);

            Close();
        }
    }
}
