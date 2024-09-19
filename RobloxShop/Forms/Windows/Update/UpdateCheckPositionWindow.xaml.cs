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
    /// Логика взаимодействия для UpdateCheckPositionWindow.xaml
    /// </summary>
    public partial class UpdateCheckPositionWindow : Window
    {
        private readonly ICheckService _checkService;
        private readonly IProductService _productService;
        private readonly ICheckPositionService _positionService;
        private int _checkPositionId = 0;

        public UpdateCheckPositionWindow(int checkPositionId)
        {
            _checkPositionId = checkPositionId;

            InitializeComponent();
            _checkService = DependencyResolver.GetService<ICheckService>();
            _productService = DependencyResolver.GetService<IProductService>();
            _positionService = DependencyResolver.GetService<ICheckPositionService>();


            List<Product> products = _productService.GetAll();
            List<Check> checks = _checkService.GetAll();


            foreach (Product product in products)
            {
                productComboBox.Items.Insert(product.Id, product.Name);

            }

            foreach (Check check in checks)
            {
                checkComboBox.Items.Insert(check.Id, check.Id);
            }

            CheckPosition checkPosition = _positionService.Get(checkPositionId);

            productPriceTextBox.Text = checkPosition.Price.ToString();
            productAmmountTextBox.Text = checkPosition.Amount.ToString();
            productComboBox.SelectedIndex = checkPosition.ProductID;
            checkComboBox.SelectedIndex = checkPosition.CheckID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CheckPosition checkPosition = new CheckPosition()
            {
                Id = _checkPositionId,
                Price = decimal.Parse(productPriceTextBox.Text),
                Amount = int.Parse(productAmmountTextBox.Text),
                ProductID = productComboBox.SelectedIndex,
                CheckID = checkComboBox.SelectedIndex,
            };
            _positionService.Update(checkPosition);
            Close();
        }
    }
}
