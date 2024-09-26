using RobloxShop.Entities;
using RobloxShop.Entities.Enums;
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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {

        private readonly IProductService _productService;

        public ProductPage(Role role)
        {
            InitializeComponent();

            if (role == Role.User)
            {
                add_button.IsEnabled = false;
                del_button.IsEnabled = false;
                alter_button.IsEnabled = false;
            }

            _productService = DependencyResolver.GetService<IProductService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow productWindow = new AddProductWindow();
            productWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as ProductViewData;
            if (viewdata != null)
            {
                _productService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as ProductViewData;
            UpdateProductWindow productWindow = new UpdateProductWindow(viewdata.Id);
            productWindow.ShowDialog();
            Reload();
        }


        void Reload()
        {
            table_grid.ItemsSource = _productService.GetAll().Select(t => new ProductViewData
            {
                Id = t.Id,
                Name = t.Name,
                Price = t.Price,
                Description = t.Description,
                Category = t.Category.Name,
                Tags = string.Join(", ", t.Tags.Select(ta => ta.Name))
            });
        }

        private class ProductViewData
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public decimal Price { get; set; }

            public string Description { get; set; }

            public string Category { get; set; }

            public string Tags { get; set; }
        }
    }
}
