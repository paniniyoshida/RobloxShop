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


        private readonly Dictionary<int, int> _productComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _warehouseComboBoxMap = new Dictionary<int, int>();

        public AddWarehouseStockWindow()
        {
            InitializeComponent();

            _warehouseStockService = DependencyResolver.GetService<IWarehouseStockService>();
            _warehouseService = DependencyResolver.GetService<IWarehouseService>();
            _productService = DependencyResolver.GetService<IProductService>();

            List<Warehouse> warehouses = _warehouseService.GetAll();
            List<Product> products = _productService.GetAll();

            int ProductIndex = 0;
            foreach (Product product in products)
            {
                _productComboBoxMap.Add(ProductIndex, product.Id);
                ProductCB.Items.Insert(ProductIndex, product.Name);
                ProductIndex++;
            }


            int WarehouseIndex = 0;
            foreach (Warehouse warehouse in warehouses)
            {
                _warehouseComboBoxMap.Add(WarehouseIndex, warehouse.Id);
                WarehouseCB.Items.Insert(WarehouseIndex, warehouse.Name);
                WarehouseIndex++;
            }
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (WarehouseCB.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран склад!");
                return; 
            }

            if (ProductCB.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран продукт!");
                return;
            }

            if (string.IsNullOrEmpty(ProductAmmountTB.Text))
            {
                MessageBox.Show("Не написано количество!");
                return;
            }

            

            WarehouseStock warehouseStock = new WarehouseStock()
            {
                WarehouseID = _warehouseComboBoxMap[WarehouseCB.SelectedIndex],
                ProductId = _productComboBoxMap[ProductCB.SelectedIndex],
                Amount = int.Parse(ProductAmmountTB.Text)
            };

            _warehouseStockService.Add(warehouseStock);
            Close();
        }
    }
}
