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
    /// Логика взаимодействия для PromocodePage.xaml
    /// </summary>
    public partial class PromocodePage : Page
    {
        private readonly IPromocodeService _promocodeService;

        public PromocodePage()
        {
            InitializeComponent();

            _promocodeService = DependencyResolver.GetService<IPromocodeService>();

            Reload();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddPromocodeWindow promocodeWindow = new AddPromocodeWindow();
            promocodeWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as PromocodeViewData;
            if (viewdata != null)
            {
                _promocodeService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as PromocodeViewData;

            UpdatePromocodeWindow promocodeWindow = new UpdatePromocodeWindow(viewdata.Id);

            promocodeWindow.ShowDialog();

            Reload();
        }

        void Reload()
        {
            table_grid.ItemsSource = _promocodeService.GetAll().Select(t => new PromocodeViewData
            {
                Id = t.Id,
                Name = t.Name,
                Code = t.Code,
                Discount = t.Discount,
            });
        }

        private class PromocodeViewData
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Code {  get; set; }

            public int Discount { get; set; }
        }
    }
}
