using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
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
    /// Логика взаимодействия для UpdateProductCartWindow.xaml
    /// </summary>
    public partial class UpdateProductCartWindow : Window
    {
        private readonly IUserService _userService;

        private readonly IProductService _productService;

        private readonly IProductCartService _productCartService;

        private int _productId;

        public UpdateProductCartWindow(int productId)
        {
            _productId = productId;
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();
            _productCartService = DependencyResolver.GetService<IProductCartService>();

            ProductCart productCart = _productCartService.Get(productId);


            List<User> users = _userService.GetAll();

            foreach (User user in users)
            {
                addUserComboBox.Items.Insert(user.Id, user.Name + "" + user.Surname);
            }

            addUserComboBox.SelectedIndex = productCart.UserId;
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (addUserComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не указан покупатель");
                return;
            }

            ProductCart productCart = new ProductCart()
            {
                Id = _productId,
                UserId = addUserComboBox.SelectedIndex,
            };

            _productCartService.Update(productCart);
            Close();
        }
    }
}
