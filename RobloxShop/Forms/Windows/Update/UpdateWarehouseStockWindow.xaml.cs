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
    /// Логика взаимодействия для UpdateWarehouseStockWindow.xaml
    /// </summary>
    public partial class UpdateWarehouseStockWindow : Window
    {
        private readonly IProductService _productService;

        private readonly IWarehouseService _warehouseService;

        private readonly IWarehouseStockService _warehouseStockService;

        private int _warehouseStockId;



        public UpdateWarehouseStockWindow(int warehouseStockId)
        {
            _warehouseStockId = warehouseStockId;
            InitializeComponent();

            _productService = DependencyResolver.GetService<IProductService>();
            _warehouseService = DependencyResolver.GetService<IWarehouseService>();
            _warehouseStockService = DependencyResolver.GetService<IWarehouseStockService>();

            WarehouseStock warehouseStock = _warehouseStockService.Get(warehouseStockId);

            List<Product> products = _productService.GetAll();
            foreach (Product product in products)
            {
                ProductCB.Items.Insert(product.Id, product.Name);
            }

            List<Warehouse> warehouses = _warehouseService.GetAll();
            foreach (Warehouse warehouse in warehouses)
            {
                WarehouseCB.Items.Insert(warehouse.Id, warehouse.Name);
            }

            ProductCB.SelectedIndex = warehouseStock.ProductId;
            WarehouseCB.SelectedIndex = warehouseStock.WarehouseID;
            ProductAmmountTB.Text = warehouseStock.Amount.ToString();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            WarehouseStock warehouseStock = new WarehouseStock()
            {
                Id = _warehouseStockId,
                WarehouseID = WarehouseCB.SelectedIndex,
                ProductId = ProductCB.SelectedIndex,
                Amount = int.Parse(ProductAmmountTB.Text)
            };

            _warehouseStockService.Update(warehouseStock);
            Close();
        }
    }
}
