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
    /// Логика взаимодействия для WarehouseStockPage.xaml
    /// </summary>
    public partial class WarehouseStockPage : Page      
    {

        private readonly IWarehouseStockService _warehouseStockService;

        public WarehouseStockPage()
        {
            InitializeComponent();

            _warehouseStockService = DependencyResolver.GetService<IWarehouseStockService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddWarehouseStockWindow warehouseStockWindow = new AddWarehouseStockWindow();
            warehouseStockWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as WarehouseStockViewData;
            if (viewdata != null)
            {
                _warehouseStockService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as WarehouseStockViewData;

            if (viewdata is null)
                return;

            UpdateWarehouseStockWindow warehouseStockWindow = new UpdateWarehouseStockWindow(viewdata.Id);
            warehouseStockWindow.ShowDialog();
            Reload();
        }

        void Reload()
        {
            table_grid.ItemsSource = _warehouseStockService.GetAll().Select(t => new WarehouseStockViewData
            {
                Id = t.Id,
                Product = t.Product.Name,
                Amount = t.Amount,
                Warehouse = t.Warehouse.Name
            });
        }

        private class WarehouseStockViewData
        {
            public int Id { get; set; }

            public string Product { get; set; }

            public int Amount { get; set; }

            public string Warehouse { get; set; }
        }
    }
}
