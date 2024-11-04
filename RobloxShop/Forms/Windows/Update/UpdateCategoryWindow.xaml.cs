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
    /// Логика взаимодействия для UpdateCategoryWindow.xaml
    /// </summary>
    public partial class UpdateCategoryWindow : Window
    {
        private readonly ICategoryService _categoryService;

        private int _categoryId = 0;

        public UpdateCategoryWindow(int categoryId)
        {
            _categoryId = categoryId;

            InitializeComponent();
            _categoryService = DependencyResolver.GetService<ICategoryService>();

            Category category = _categoryService.Get(categoryId);

            tagNameTextBox.Text = category.Name.ToString();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tagNameTextBox.Text))
            {
                MessageBox.Show("Не введено название!");
                return;
            }

            Category category = new Category()
            {
                Id = _categoryId,
                Name = tagNameTextBox.Text
            };
            _categoryService.Update(category);
            Close();
        }
    }
}
