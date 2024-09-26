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
    /// Логика взаимодействия для UpdatePaymentWindow.xaml
    /// </summary>
    public partial class UpdatePaymentWindow : Window
    {
        private readonly IPaymentProviderService _paymentProviderService;

        private readonly ICheckService _checkService;

        private readonly IPaymentService _paymentService;

        private int _paymentId;

        private readonly Dictionary<int, int> _providerComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _checkComboBoxMap = new Dictionary<int, int>();

        public UpdatePaymentWindow(int paymentId)
        {
            _paymentId = paymentId;
            InitializeComponent();
            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
            _checkService = DependencyResolver.GetService<ICheckService>();
            _paymentService = DependencyResolver.GetService<IPaymentService>();

            Payment payment = _paymentService.Get(paymentId);

            List<Check> checks = _checkService.GetAll();

            int CheckComboBoxIndex = 0;
            foreach (Check check in checks)
            {
                _checkComboBoxMap.Add(CheckComboBoxIndex, check.Id);
                addCheckIdComboBox.Items.Insert(CheckComboBoxIndex, check.Id);
                CheckComboBoxIndex++;
            }

            List<PaymentProvider> paymentProviders = _paymentProviderService.GetAll();


            int PaymentProviderIndex = 0;
            foreach(PaymentProvider paymentProvider in paymentProviders)
            {
                _providerComboBoxMap.Add(PaymentProviderIndex, paymentProvider.Id);
                addProviderComboBox.Items.Insert(PaymentProviderIndex, paymentProvider.Name);
                PaymentProviderIndex++;
            }

            addCheckIdComboBox.SelectedIndex = _checkComboBoxMap.FirstOrDefault(x => x.Value == payment.CheckID).Key;
            addProviderComboBox.SelectedIndex = _providerComboBoxMap.FirstOrDefault(x => x.Value == payment.PaymentProviderID).Key;


        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if(addCheckIdComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан чек");
                return;
            }

            if(addProviderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан провайдер");
                return;
            }

            Payment payment = new Payment()
            {
                Id = _paymentId,

                CheckID = _checkComboBoxMap[addCheckIdComboBox.SelectedIndex],

                PaymentProviderID = _providerComboBoxMap[addProviderComboBox.SelectedIndex]
            };

            _paymentService.Update(payment);

            Close();
        }
    }
}
