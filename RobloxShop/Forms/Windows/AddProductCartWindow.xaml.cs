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

        private readonly Dictionary<int, int> _userComboBoxMap = new Dictionary<int, int>();



        public AddProductCartWindow()
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();

            _productCartService = DependencyResolver.GetService<IProductCartService>();

            List<User> users = _userService.GetAll();


            int UserIndex = 0;
            foreach (User user in users)
            {
                _userComboBoxMap.Add(UserIndex, user.Id);
                addUserComboBox.Items.Insert(UserIndex, user.Name + "" + user.Surname);
                UserIndex++;
            }
        }



        

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (addUserComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран покупатель!");
                return;
            }

            ProductCart productCart = new ProductCart()
            {
                UserId = _userComboBoxMap[addUserComboBox.SelectedIndex]

            };

            _productCartService.Add(productCart);

            Close();
        }
    }
}
