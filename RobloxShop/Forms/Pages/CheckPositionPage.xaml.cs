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
    /// Логика взаимодействия для CheckPositionsPage.xaml
    /// </summary>
    public partial class CheckPositionsPage : Page
    {
        private readonly ICheckPositionService _checkPositionService;

        public CheckPositionsPage()
        {
            InitializeComponent();

            _checkPositionService = DependencyResolver.GetService<ICheckPositionService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddCheckPositionsWindow checkPositionWindow = new AddCheckPositionsWindow();
            checkPositionWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as CheckPositionViewData;
            if (viewdata != null)
            {
                _checkPositionService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as CheckPositionViewData;

            if (viewdata is null)
                return;

            UpdateCheckPositionWindow positionWindow = new UpdateCheckPositionWindow(viewdata.Id);

            positionWindow.ShowDialog();

            Reload();

        }

        void Reload()
        {
            table_grid.ItemsSource = _checkPositionService.GetAll().Select(t => new CheckPositionViewData
            {
                Id = t.Id,
                Product = t.Product.Name,
                Price = t.Price,
                Amount = t.Amount,
                CheckID = t.CheckID
            });
        }

        private class CheckPositionViewData
        {
            public int Id { get; set; }

            public string Product { get; set; }

            public decimal Price { get; set; }

            public int Amount { get; set; }

            public int CheckID { get; set; }

        }



    }
}
