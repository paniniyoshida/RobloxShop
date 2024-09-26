using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
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
    /// Логика взаимодействия для UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        private int _productId;

        private readonly Dictionary<int, int> _categoryComboBoxMap = new Dictionary<int, int>();


        public UpdateProductWindow(int productId)
        {
            _productId = productId;
            InitializeComponent();

            _categoryService = DependencyResolver.GetService<ICategoryService>();
            _productService = DependencyResolver.GetService<IProductService>();

            Product product = _productService.Get(productId);

            List<Category> categories = _categoryService.GetAll();


            int CategoryIndex = 0;
            foreach (Category category in categories)
            {
                _categoryComboBoxMap.Add(CategoryIndex, category.Id);
                categoryComboBox.Items.Insert(CategoryIndex, category.Name);
                CategoryIndex++;
            }

            categoryComboBox.SelectedIndex = _categoryComboBoxMap.FirstOrDefault(x => x.Value == product.CategoryID).Key;
            productNameTextBox.Text = product.Name;
            productPriceTextBox.Text = product.Price.ToString();
            productDescriprionTextBox.Text = product.Description;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                Id = _productId,
                Name = productNameTextBox.Text,
                Price = decimal.Parse(productPriceTextBox.Text),
                Description = productDescriprionTextBox.Text,
                CategoryID = _categoryComboBoxMap[categoryComboBox.SelectedIndex]

            };

            _productService.Update(product);
            Close();
        }
    }
}
