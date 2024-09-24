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
    /// Логика взаимодействия для AddWarehouseWindow.xaml
    /// </summary>
    public partial class AddWarehouseWindow : Window
    {
        private readonly IWarehouseService _warehouseService;

        public AddWarehouseWindow()
        {
            InitializeComponent();
            _warehouseService = DependencyResolver.GetService<IWarehouseService>();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            Warehouse warehouse = new Warehouse()
            {
                Name = addWarehouseTB.Text,
            };

            _warehouseService.Add(warehouse);
            Close();
        }
    }
}
