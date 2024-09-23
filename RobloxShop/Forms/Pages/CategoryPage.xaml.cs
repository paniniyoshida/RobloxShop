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
    /// Логика взаимодействия для CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private readonly ICategoryService _categoryService;
        public CategoryPage()
        {
            InitializeComponent();
            _categoryService = DependencyResolver.GetService<ICategoryService>();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow categoryWindow = new AddCategoryWindow();
            categoryWindow.ShowDialog();
            Reload();
        }

        private class CategoryViewData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        void Reload()
        {
            table_grid.ItemsSource = _categoryService.GetAll().Select(t => new CategoryViewData
            {
                Id = t.Id,
                Name = t.Name,
            });
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as CategoryViewData;
            if (viewdata != null)
            {
                _categoryService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as CategoryViewData;
            UpdateCategoryWindow categoryWindow = new UpdateCategoryWindow(viewdata.Id);
            categoryWindow.ShowDialog();
            Reload();
        }
    }
}
