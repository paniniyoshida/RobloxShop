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
    /// Логика взаимодействия для AddWarehouseStockWindow.xaml
    /// </summary>
    public partial class AddWarehouseStockWindow : Window
    {
        private readonly IWarehouseStockService _warehouseStockService;
        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;

        public AddWarehouseStockWindow()
        {
            InitializeComponent();

            _warehouseStockService = DependencyResolver.GetService<IWarehouseStockService>();
            _warehouseService = DependencyResolver.GetService<IWarehouseService>();
            _productService = DependencyResolver.GetService<IProductService>();

            List<Warehouse> warehouses = _warehouseService.GetAll();
            List<Product> products = _productService.GetAll();

            foreach (Warehouse warehouse in warehouses)
            {
                WarehouseCB.Items.Insert(warehouse.Id, warehouse.Name);
            }

            foreach (Product product in products)
            {
                ProductCB.Items.Insert(product.Id, product.Name);
            }
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            WarehouseStock warehouseStock = new WarehouseStock()
            {
                WarehouseID = WarehouseCB.SelectedIndex,
                ProductId = ProductCB.SelectedIndex,
                Amount = int.Parse(ProductAmmountTB.Text)
            };

            _warehouseStockService.Add(warehouseStock);
            Close();
        }
    }
}
