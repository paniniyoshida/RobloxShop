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
    /// Логика взаимодействия для AddCheckPositionsWindow.xaml
    /// </summary>
    public partial class AddCheckPositionsWindow : Window
    {
        private readonly ICheckService _checkService;
        private readonly IProductService _productService;
        private readonly ICheckPositionService _positionService;

        public AddCheckPositionsWindow()
        {
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(productComboBox.Text, out decimal price))
            {
                MessageBox.Show("Неверно введено значение цены");
                return;
            }

            if (productComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран продукт");
                return;
            }

            if (checkComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран чек");
                return;
            }

            CheckPosition checkPosition = new CheckPosition()
            {
                Price = decimal.Parse(productPriceTextBox.Text),
                Amount = int.Parse(productAmmountTextBox.Text),
                ProductID = productComboBox.SelectedIndex,
                CheckID = checkComboBox.SelectedIndex,
            };
            _positionService.Add(checkPosition);
            Close();

        }
    }
}
