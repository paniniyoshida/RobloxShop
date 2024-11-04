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
    /// Логика взаимодействия для UpdateWarehouseWindow.xaml
    /// </summary>
    public partial class UpdateWarehouseWindow : Window
    {
        private readonly IWarehouseService _warehouseService;

        private int _currentWarehouseId;

        public UpdateWarehouseWindow(int currentWarehouseId)
        {
            InitializeComponent();
            _currentWarehouseId = currentWarehouseId;

            _warehouseService = DependencyResolver.GetService<IWarehouseService>();


            Warehouse warehouse = _warehouseService.Get(currentWarehouseId);


            addWarehouseTB.Text = warehouse.Name;
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(addWarehouseTB.Text))
            {
                MessageBox.Show("Не написано название!");
                return;
            }
            Warehouse warehouse = new Warehouse()
            {
                Id = _currentWarehouseId,
                Name = addWarehouseTB.Text,
            };

            _warehouseService.Add(warehouse);
            Close();
        }
    }
}
