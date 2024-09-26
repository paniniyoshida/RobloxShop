

using Newtonsoft.Json;
using RobloxShop.Entities;
using RobloxShop.Forms.Windows;
using RobloxShop.Forms.Windows.Update;
using RobloxShop.Services;
using RobloxShop.Services.Interfaces;
using RobloxShop.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RobloxShop.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductCartPage.xaml
    /// </summary>
    public partial class ProductCartPage : Page
    {
        private readonly IProductCartService _productCartService;

        public ProductCartPage()
        {
            InitializeComponent();

            _productCartService = DependencyResolver.GetService<IProductCartService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddProductCartWindow productCartWindow = new AddProductCartWindow();
            productCartWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as ProductCartViewData;
            if (viewdata != null)
            {
                _productCartService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as ProductCartViewData;
            UpdateProductCartWindow productCartWindow = new UpdateProductCartWindow(viewdata.Id);
            productCartWindow.ShowDialog();
            Reload();
        }

        void Reload()
        {
            table_grid.ItemsSource = _productCartService.GetAll().Select(t => new ProductCartViewData
            {
                Id = t.Id,
                User = t.User.Name+ " "+ t.User.Surname,
            });
        }

        private class ProductCartViewData
        {
            public int Id { get; set; }

            public string User { get; set; }
        }

        private void import_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }


                string fileName = openFileDialog.FileName;

                string json = File.ReadAllText(fileName);

                ProductCart productCart = JsonConvert.DeserializeObject<ProductCart>(json);

                productCart.User = null;

                _productCartService.Add(productCart);

                Reload();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Возникла ошибка");
            }
        }

        private void export_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as ProductCartViewData;
            if (viewdata != null)
            {
               

                ProductCart productCart = _productCartService.Get(viewdata.Id);

                string json = JsonConvert.SerializeObject(productCart);

                SaveFileDialog saveFileDialog = new SaveFileDialog();

               if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

               

                string fileName = saveFileDialog.FileName;

                File.WriteAllText(fileName, json);

            }
            
        }
    }
}
