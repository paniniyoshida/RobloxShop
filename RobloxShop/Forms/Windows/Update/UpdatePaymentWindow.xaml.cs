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

        public UpdatePaymentWindow(int paymentId)
        {
            _paymentId = paymentId;
            InitializeComponent();
            _paymentProviderService = DependencyResolver.GetService<IPaymentProviderService>();
            _checkService = DependencyResolver.GetService<ICheckService>();
            _paymentService = DependencyResolver.GetService<IPaymentService>();

            Payment payment = _paymentService.Get(paymentId);

            List<Check> checks = _checkService.GetAll();

            foreach (Check check in checks)
            {
                addCheckIdComboBox.Items.Insert(check.Id, check.Id);
            }

            List<PaymentProvider> paymentProviders = _paymentProviderService.GetAll();

            foreach(PaymentProvider paymentProvider in paymentProviders)
            {
                addProviderComboBox.Items.Insert(paymentProvider.Id, paymentProvider.Name);
            }

            addCheckIdComboBox.SelectedIndex = payment.CheckID;
            addProviderComboBox.SelectedIndex = payment.PaymentProviderID;


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
                CheckID = addCheckIdComboBox.SelectedIndex,

                PaymentProviderID = addProviderComboBox.SelectedIndex,
            };

            _paymentService.Update(payment);

            Close();
        }
    }
}
