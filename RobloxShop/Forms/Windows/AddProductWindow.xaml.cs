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

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private readonly IProductService _productService;

        private readonly ICategoryService _categoryService;

        public AddProductWindow()
        {
            InitializeComponent();
            _productService = DependencyResolver.GetService<IProductService>();
            _categoryService = DependencyResolver.GetService<ICategoryService>();

            List<Category> categories = _categoryService.GetAll();

            foreach (Category category in categories) 
            {
                categoryComboBox.Items.Insert(category.Id, category.Name);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                Name = productNameTextBox.Text,
                Price = decimal.Parse(productPriceTextBox.Text),
                Description = productDescriprionTextBox.Text,
                CategoryID = categoryComboBox.SelectedIndex

            };

            _productService.Add(product);
        }
    }
}
