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

        public AddProductCartItemWindow()
        {
            InitializeComponent();
            _productService = DependencyResolver.GetService<IProductService>();
            _cartItemService = DependencyResolver.GetService<IProductCartItemService>();
            _cartService = DependencyResolver.GetService<IProductCartService>();

            List<Product> products = _productService.GetAll();
            List<ProductCartItem> productCartItems = _cartItemService.GetAll();

            foreach (Product product in products)
            {
                addProductComboBox.Items.Insert(product.Id, product.Name);
            }

            foreach (ProductCartItem productCartItem in productCartItems)
            {
                addCartComboBox.Items.Insert(productCartItem.Id, productCartItem.Id);
            }
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductCartItem productCartItem = new ProductCartItem()
            {
                ProductId = addProductComboBox.SelectedIndex,
                ProductCartId = addCartComboBox.SelectedIndex,
                Amount = int.Parse(addAmmountTextBox.Text)
            };

            _cartItemService.Add(productCartItem);

            Close();
        }
    }
}
