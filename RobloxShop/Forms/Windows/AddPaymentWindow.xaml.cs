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

        private readonly Dictionary<int, int> _providerComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _checkComboBoxMap = new Dictionary<int, int>();

        public AddPaymentWindow()
        {
            InitializeComponent();
            _checkService = DependencyResolver.GetService<ICheckService>();
            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
            _paymentService = DependencyResolver.GetService<IPaymentService>();

            List<PaymentProvider> paymentProviders = _paymentProviderService.GetAll();
            List<Check> checks = _checkService.GetAll();

            int CheckComboBoxIndex = 0;
            foreach (Check check in checks)
            {
                _checkComboBoxMap.Add(CheckComboBoxIndex, check.Id);
                addCheckIdComboBox.Items.Insert(CheckComboBoxIndex, check.Id);
                CheckComboBoxIndex++;
            }



            int PaymentProviderIndex = 0;
            foreach (PaymentProvider paymentProvider in paymentProviders)
            {
                _providerComboBoxMap.Add(PaymentProviderIndex, paymentProvider.Id);
                addProviderComboBox.Items.Insert(PaymentProviderIndex, paymentProvider.Name);
                PaymentProviderIndex++;
            }
        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment()
            {
                CheckID = _checkComboBoxMap[addCheckIdComboBox.SelectedIndex],

                PaymentProviderID = _providerComboBoxMap[addProviderComboBox.SelectedIndex]
            };

            _paymentService.Add(payment);

            Close();


        }
    }
}
