﻿using RobloxShop.Entities;
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

        private readonly Dictionary<int, int> _categoryComboBoxMap = new Dictionary<int, int>();


        public AddProductWindow()
        {
            InitializeComponent();
            _productService = DependencyResolver.GetService<IProductService>();
            _categoryService = DependencyResolver.GetService<ICategoryService>();

            List<Category> categories = _categoryService.GetAll();

            int CategoryIndex = 0;
            foreach (Category category in categories)
            {
                _categoryComboBoxMap.Add(CategoryIndex, category.Id);
                categoryComboBox.Items.Insert(CategoryIndex, category.Name);
                CategoryIndex++;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product()
            {
                Name = productNameTextBox.Text,
                Price = decimal.Parse(productPriceTextBox.Text),
                Description = productDescriprionTextBox.Text,
                CategoryID = _categoryComboBoxMap[categoryComboBox.SelectedIndex]

            };

            _productService.Add(product);
            Close();

        }
    }
}
