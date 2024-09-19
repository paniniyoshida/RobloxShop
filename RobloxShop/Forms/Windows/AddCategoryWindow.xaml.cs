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
    /// Логика взаимодействия для AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        private readonly ICategoryService _categoryService;

        public AddCategoryWindow()
        {
            InitializeComponent();
            _categoryService = DependencyResolver.GetService<ICategoryService>();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category()
            {
                Name = tagNameTextBox.Text

            };
            _categoryService.Add(category);
            Close();
        }
    }
}
