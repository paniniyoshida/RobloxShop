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
    /// Логика взаимодействия для UpdateProductCartItemWindow.xaml
    /// </summary>
    public partial class UpdateProductCartItemWindow : Window
    {
        private readonly IProductService _productService;

        private readonly IProductCartItemService _cartItemService;

        private readonly IProductCartService _productCartService;

        private int _productCartItemId;

        public UpdateProductCartItemWindow(int producCartItemtId)
        {
            _productCartItemId = producCartItemtId;
            InitializeComponent();

            _cartItemService = DependencyResolver.GetService<IProductCartItemService>();
            _productCartService = DependencyResolver.GetService<IProductCartService>();
            _productService = DependencyResolver.GetService<IProductService>();


            ProductCartItem cartItem = _cartItemService.Get(producCartItemtId);

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

            addProductComboBox.SelectedIndex = cartItem.ProductId;
            addCartComboBox.SelectedIndex = cartItem.ProductCartId;

            addAmmountTextBox.Text = cartItem.Amount.ToString();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductCartItem productCartItem = new ProductCartItem()
            {
                Id = _productCartItemId,
                ProductId = addProductComboBox.SelectedIndex,
                ProductCartId = addCartComboBox.SelectedIndex,
                Amount = int.Parse(addAmmountTextBox.Text)
            };

            _cartItemService.Update(productCartItem);

            Close();
        }
    }
}
