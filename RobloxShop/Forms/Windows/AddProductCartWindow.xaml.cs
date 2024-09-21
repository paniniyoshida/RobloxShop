using RobloxShop.Entities;
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
using System.Windows.Shapes;

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductCartWindow.xaml
    /// </summary>
    public partial class AddProductCartWindow : Window
    {
        private readonly IUserService _userService;
        private readonly IProductCartService _productCartService;


        public AddProductCartWindow()
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();


            List<User> users = _userService.GetAll();


            foreach (User user in users)
            {
                addUserComboBox.Items.Insert(user.Id, user.Name);
            }
        }



        

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductCart productCart = new ProductCart()
            {
                UserId = addUserComboBox.SelectedIndex,

            };

            _productCartService.Add(productCart);

            Close();
        }
    }
}
