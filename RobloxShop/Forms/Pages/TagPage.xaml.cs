using RobloxShop.Forms.Windows;
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
    /// Логика взаимодействия для TagPage.xaml
    /// </summary>
    public partial class TagPage : Page
    {
        private readonly ITagService _tagService;
        public TagPage()
        {
            InitializeComponent();
            _tagService = DependencyResolver.GetService<ITagService>();

            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddTagWindow tagWindow = new AddTagWindow();
            tagWindow.ShowDialog();
            Reload();

        }
        void Reload()
        {
            table_grid.ItemsSource = _tagService.GetAll().Select(t => new TagViewData
            {
                Id = t.Id,
                Name = t.Name,
            });
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as TagViewData;
            _tagService.Delete(viewdata.Id);
            Reload();
        }

        private class TagViewData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as TagViewData;
            Entities.Tag tag = new Entities.Tag()
            {
                Id = viewdata.Id,
                Name = viewdata.Name,
            };
            _tagService.Update(tag);
            Reload();
        }
    }
}
