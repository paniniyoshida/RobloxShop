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

        private readonly Dictionary<int, int> _productComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _warehouseComboBoxMap = new Dictionary<int, int>();






        public UpdateWarehouseStockWindow(int warehouseStockId)
        {
            _warehouseStockId = warehouseStockId;
            InitializeComponent();

            _productService = DependencyResolver.GetService<IProductService>();
            _warehouseService = DependencyResolver.GetService<IWarehouseService>();
            _warehouseStockService = DependencyResolver.GetService<IWarehouseStockService>();

            WarehouseStock warehouseStock = _warehouseStockService.Get(warehouseStockId);

            List<Product> products = _productService.GetAll();

            int ProductIndex = 0;
            foreach (Product product in products)
            {
                _productComboBoxMap.Add(ProductIndex, product.Id);
                ProductCB.Items.Insert(ProductIndex, product.Name);
                ProductIndex++;
            }

            List<Warehouse> warehouses = _warehouseService.GetAll();


            int WarehouseIndex = 0;
            foreach (Warehouse warehouse in warehouses)
            {
                _warehouseComboBoxMap.Add(WarehouseIndex, warehouse.Id);
                WarehouseCB.Items.Insert(WarehouseIndex, warehouse.Name);
                WarehouseIndex++;
            }

            ProductCB.SelectedIndex = _productComboBoxMap.FirstOrDefault(x => x.Value == warehouseStock.ProductId).Key;
            WarehouseCB.SelectedIndex = _warehouseComboBoxMap.FirstOrDefault(x => x.Value == warehouseStock.WarehouseID).Key;
            ProductAmmountTB.Text = warehouseStock.Amount.ToString();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            WarehouseStock warehouseStock = new WarehouseStock()
            {
                Id = _warehouseStockId,
                WarehouseID = _warehouseComboBoxMap[WarehouseCB.SelectedIndex],
                ProductId = _productComboBoxMap[ProductCB.SelectedIndex],
                Amount = int.Parse(ProductAmmountTB.Text)
            };

            _warehouseStockService.Update(warehouseStock);
            Close();
        }
    }
}
