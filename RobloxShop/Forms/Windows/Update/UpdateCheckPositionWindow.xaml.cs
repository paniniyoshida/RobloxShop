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

        private readonly Dictionary<int, int> _productComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _checkComboBoxMap = new Dictionary<int, int>();

        public UpdateCheckPositionWindow(int checkPositionId)
        {
            _checkPositionId = checkPositionId;

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

            CheckPosition checkPosition = _positionService.Get(checkPositionId);

            productPriceTextBox.Text = checkPosition.Price.ToString();
            productAmmountTextBox.Text = checkPosition.Amount.ToString();
            productComboBox.SelectedIndex =_productComboBoxMap.FirstOrDefault(x => x.Value == checkPosition.ProductID).Key;
            checkComboBox.SelectedIndex =_checkComboBoxMap.FirstOrDefault(x => x.Value == checkPosition.CheckID).Key;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(!decimal.TryParse (productPriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Неверно введено значение цены");
                return;
            }

            if (!int.TryParse(productAmmountTextBox.Text, out int amount))
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
                Id = _checkPositionId,
                Price = decimal.Parse(productPriceTextBox.Text),
                Amount = amount,
                ProductID =_productComboBoxMap[productComboBox.SelectedIndex],
                CheckID =_checkComboBoxMap[checkComboBox.SelectedIndex],
            };
            _positionService.Update(checkPosition);
            Close();
        }
    }
}
