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

        private readonly Dictionary<int, int> _productComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _checkComboBoxMap = new Dictionary<int, int>();


        public AddCheckPositionsWindow()
        {
            InitializeComponent();
            _checkService = DependencyResolver.GetService<ICheckService>();
            _productService = DependencyResolver.GetService<IProductService>();
            _positionService = DependencyResolver.GetService<ICheckPositionService>();


            List<Product> products = _productService.GetAll();
            List<Check> checks = _checkService.GetAll();


            int productComboBoxIndex = 0;
            foreach (Product product in products)
            {
                _productComboBoxMap.Add(productComboBoxIndex, product.Id);
                productComboBox.Items.Insert(productComboBoxIndex, product.Name);
                productComboBoxIndex++;
            }


            int checkComboBoxIndex = 0;
            foreach (Check check in checks)
            {
                _checkComboBoxMap.Add(checkComboBoxIndex, check.Id);
                checkComboBox.Items.Insert(checkComboBoxIndex, check.Id);
                checkComboBoxIndex++;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(productPriceTextBox.Text, out decimal price))
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
                ProductID =_productComboBoxMap[productComboBox.SelectedIndex],
                CheckID =_checkComboBoxMap[checkComboBox.SelectedIndex],
            };
            _positionService.Add(checkPosition);
            Close();

        }
    }
}
