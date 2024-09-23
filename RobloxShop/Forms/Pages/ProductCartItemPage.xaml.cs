using RobloxShop.Entities;
using RobloxShop.Forms.Windows;
using RobloxShop.Forms.Windows.Update;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RobloxShop.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductCartItemPage.xaml
    /// </summary>
    public partial class ProductCartItemPage : Page
    {
        private readonly IProductCartItemService _productCartItemService;

        public ProductCartItemPage()
        {
            InitializeComponent();

            _productCartItemService = DependencyResolver.GetService<IProductCartItemService>();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddProductCartItemWindow productCartItemWindow = new AddProductCartItemWindow();
            productCartItemWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as ProductCartItemViewData;
            if (viewdata != null)
            {
                _productCartItemService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {

            var viewdata = table_grid.SelectedItem as ProductCartItemViewData;
            UpdateProductCartItemWindow productCartItemWindow = new UpdateProductCartItemWindow(viewdata.Id);
            productCartItemWindow.ShowDialog();
            Reload();
        }

        void Reload()
        {
            table_grid.ItemsSource = _productCartItemService.GetAll().Select(t => new ProductCartItemViewData
            {
                Id = t.Id,
                Product = t.Product.Name,
                Amount = t.Amount,
                ProductCartId = t.ProductCartId,
            });
        }

        private class ProductCartItemViewData
        {
            public int Id { get; set; }

            public string Product { get; set; }

            public int Amount { get; set; }

            public int ProductCartId { get; set; }
        }
    }
}
