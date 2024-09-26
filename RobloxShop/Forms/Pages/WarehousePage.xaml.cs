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
    /// Логика взаимодействия для WarehousePage.xaml
    /// </summary>
    public partial class WarehousePage : Page
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousePage()
        {
            InitializeComponent();

            _warehouseService = DependencyResolver.GetService<IWarehouseService>();
            Reload();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddWarehouseWindow warehouseWindow = new AddWarehouseWindow();
            warehouseWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as WarehousePageViewData;
            if (viewdata != null)
            {
                _warehouseService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as WarehousePageViewData;
            if (viewdata == null)
            {
                return;
            }

            UpdateWarehouseWindow warehouseWindow = new UpdateWarehouseWindow(viewdata.Id);

            warehouseWindow.ShowDialog();

            Reload();
        }
        
        void Reload()
        {
            table_grid.ItemsSource = _warehouseService.GetAll().Select(t => new WarehousePageViewData
            {
                Id = t.Id,
                Name = t.Name,
                Stocks = t.Stocks.Sum(s => s.Amount)
            });
        }
        private class WarehousePageViewData
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Stocks { get; set; }
        }
    }
}
