using RobloxShop.Entities;
using RobloxShop.Entities.Enums;
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
    /// Логика взаимодействия для UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        private readonly IUserService _userService;

        private int _userId;

        public UpdateUserWindow(int userId)
        {
            _userId = userId;
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();


            RoleCB.Items.Insert(0, "Пользователь");
            RoleCB.Items.Insert(1, "Администратор");

            User user = _userService.Get(userId);

            RoleCB.SelectedIndex = (int)user.Role;

            NameTB.Text = user.Name;
            SurnameTB.Text = user.Surname;
            LoginTB.Text = user.Login;
            PasswordTB.Text = user.PasswordHash;

            DateDP.SelectedDate = user.Birthday;

        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                Id = _userId,
                Name = NameTB.Text,
                Surname = SurnameTB.Text,
                Login = LoginTB.Text,
                PasswordHash = PasswordTB.Text,
                Birthday = DateDP.SelectedDate.Value,

                Role = (Role)RoleCB.SelectedIndex

            };

            _userService.Update(user);
            Close();
        }
    }
}
