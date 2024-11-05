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
    /// Логика взаимодействия для CheckPage.xaml
    /// </summary>
    public partial class CheckPage : Page
    {
        private readonly ICheckService _checkService;

        public CheckPage()
        {
            InitializeComponent();

            _checkService = DependencyResolver.GetService<ICheckService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddCheckWindow checkWindow = new AddCheckWindow();
            checkWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as CheckViewData;
            if (viewdata != null)
            {
                _checkService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as CheckViewData;

            if (viewdata is null)
                return;

            UpdateCheckWindow checkWindow = new UpdateCheckWindow(viewdata.Id);

            checkWindow.ShowDialog();

            Reload();
        }

        void Reload()
        {
            table_grid.ItemsSource = _checkService.GetAll().Select(t => new CheckViewData
            {
                Id = t.Id,
                User = t.User.Name + " " + t.User.Surname,
                Date = t.Date.ToShortDateString(),
                Promocode = t.Promocode?.Name ?? string.Empty,
            });
        }

        private class CheckViewData
        {
            public int Id { get; set; }

            public string User { get; set; }

            public string Date { get; set; }

            public string Promocode { get; set; }

        }
    }
}
