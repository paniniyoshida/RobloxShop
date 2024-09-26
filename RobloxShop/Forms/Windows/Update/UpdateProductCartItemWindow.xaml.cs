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

        private readonly Dictionary<int, int> _productComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _cartItemComboBoxMap = new Dictionary<int, int>();

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


            int ProductIndex = 0;
            foreach (Product product in products)
            {
                _productComboBoxMap.Add(ProductIndex, product.Id);
                addProductComboBox.Items.Insert(ProductIndex, product.Name);
                ProductIndex++;
            }


            int ProductCartItemIndex = 0;
            foreach (ProductCartItem productCartItem in productCartItems)
            {
                _cartItemComboBoxMap.Add(ProductCartItemIndex, productCartItem.Id);
                addCartComboBox.Items.Insert(ProductCartItemIndex, productCartItem.Id);
                ProductCartItemIndex++;
            }

            addProductComboBox.SelectedIndex = _productComboBoxMap.FirstOrDefault(x => x.Value == cartItem.ProductId).Key;
            addCartComboBox.SelectedIndex = _cartItemComboBoxMap.FirstOrDefault(x => x.Value == cartItem.ProductCartId).Key;

            addAmmountTextBox.Text = cartItem.Amount.ToString();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductCartItem productCartItem = new ProductCartItem()
            {
                Id = _productCartItemId,
                ProductId = _productComboBoxMap[addProductComboBox.SelectedIndex],
                ProductCartId = _cartItemComboBoxMap[addCartComboBox.SelectedIndex],
                Amount = int.Parse(addAmmountTextBox.Text)
            };

            _cartItemService.Update(productCartItem);

            Close();
        }
    }
}
