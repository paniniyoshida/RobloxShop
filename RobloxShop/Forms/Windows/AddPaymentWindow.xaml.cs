using RobloxShop.Entities;
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
using System.Windows.Shapes;

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPaymentWindow.xaml
    /// </summary>
    public partial class AddPaymentWindow : Window
    {

        private readonly ICheckService _checkService;
        private readonly IPaymentProviderService _paymentProviderService;
        private readonly IPaymentService _paymentService;

        public AddPaymentWindow()
        {
            InitializeComponent();
            _checkService = DependencyResolver.GetService<ICheckService>();
            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
            _paymentService = DependencyResolver.GetService<IPaymentService>();

            List<PaymentProvider> paymentProviders = _paymentProviderService.GetAll();
            List<Check> checks = _checkService.GetAll();

            foreach (Check check in checks)
            {
                addCheckIdComboBox.Items.Insert(check.Id, check.Id);

            }

            foreach (PaymentProvider paymentProvider in paymentProviders)
            {
                addProviderComboBox.Items.Insert(paymentProvider.Id, paymentProvider.Name);
            }
        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment()
            {
                CheckID = addCheckIdComboBox.SelectedIndex,

                PaymentProviderID = addProviderComboBox.SelectedIndex,
            };

            _paymentService.Add(payment);

            Close();


        }
    }
}
