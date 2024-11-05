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
    /// Логика взаимодействия для AddProductCartItemWindow.xaml
    /// </summary>
    public partial class AddProductCartItemWindow : Window
    {
        private readonly IProductService _productService;
        private readonly IProductCartService _cartService;
        private readonly IProductCartItemService _cartItemService;

        private readonly Dictionary<int, int> _productComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _cartItemComboBoxMap = new Dictionary<int, int>();

        public AddProductCartItemWindow()
        {
            InitializeComponent();
            _productService = DependencyResolver.GetService<IProductService>();
            _cartItemService = DependencyResolver.GetService<IProductCartItemService>();
            _cartService = DependencyResolver.GetService<IProductCartService>();

            List<Product> products = _productService.GetAll();
            List<ProductCart> productCartss = _cartService.GetAll();

            int ProductIndex = 0;
            foreach (Product product in products)
            {
                _productComboBoxMap.Add(ProductIndex, product.Id);
                addProductComboBox.Items.Insert(ProductIndex, product.Name);
                ProductIndex++;
            }


            int ProductCartItemIndex = 0;
            foreach (ProductCart productCarts in productCartss)
            {
                _cartItemComboBoxMap.Add(ProductCartItemIndex, productCarts.Id);
                addCartComboBox.Items.Insert(ProductCartItemIndex, productCarts.Id);
                ProductCartItemIndex++;
            }
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(addAmmountTextBox.Text))
            {
                MessageBox.Show("Не указано количество!");
                return;
            }

            if (int.TryParse(addAmmountTextBox.Text, out int amount))
            {
                MessageBox.Show("Не указано количество!");
                return;
            }

            if (addCartComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбрана корзина!");
                return;
            }

            if (addProductComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран продукт!");
                return;
            }

            ProductCartItem productCartItem = new ProductCartItem()
            {
                ProductId = _productComboBoxMap[addProductComboBox.SelectedIndex],
                ProductCartId = _cartItemComboBoxMap[addCartComboBox.SelectedIndex],
                Amount = amount
            };

            _cartItemService.Add(productCartItem);

            Close();
        }
    }
}
