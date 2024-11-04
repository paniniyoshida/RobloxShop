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
    /// Логика взаимодействия для UpdatePromocodeWindow.xaml
    /// </summary>
    public partial class UpdatePromocodeWindow : Window
    {
        private readonly IPromocodeService _promocodeService;
        private int _promocodeId;
        public UpdatePromocodeWindow(int promocodeId)
        {
            _promocodeId = promocodeId;

            InitializeComponent();


            _promocodeService = DependencyResolver.GetService<IPromocodeService>();

            Promocode promocode = _promocodeService.Get(promocodeId);

            Name.Text = promocode.Name;
            Code.Text = promocode.Code;
            Discount.Text = promocode.Discount.ToString();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Не написано имя!");
                return;
            }

            if (string.IsNullOrEmpty(Code.Text))
            {
                MessageBox.Show("Не написан код!");
                return;
            }

            if (string.IsNullOrEmpty(Discount.Text))
            {
                MessageBox.Show("Не написана скидка!");
                return;
            }
            Promocode promocode = new Promocode()
            {
                Id = _promocodeId,
                Name = Name.Text,
                Code = Code.Text,
                Discount = int.Parse(Discount.Text),

            };
            _promocodeService.Update(promocode);
            Close();
        }
    }
}
