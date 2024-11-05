using RobloxShop.Entities;
using RobloxShop.Entities.Enums;
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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private readonly IUserService _userService;
        

        public AddUserWindow(bool allowChangeRole = true)
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();


            RoleCB.Items.Insert(0, "Пользователь");
            RoleCB.Items.Insert(1, "Администратор");

            if (!allowChangeRole)
            {
                RoleCB.SelectedIndex = 0;
                RoleCB.IsEnabled = false;
            }

        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {

            if (RoleCB.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана роль!");
                return;
            }

            if (string.IsNullOrEmpty(NameTB.Text))
            {
                MessageBox.Show("Не написано имя!");
                return;
            }

            if (string.IsNullOrEmpty(SurnameTB.Text))
            {
                MessageBox.Show("Не написана фамилия!");
                return;
            }

            if (string.IsNullOrEmpty(LoginTB.Text))
            {
                MessageBox.Show("Не написан логин!");
                return;
            }

            if (string.IsNullOrEmpty(PasswordTB.Text))
            {
                MessageBox.Show("Не написан пароль!");
                return;
            }

            if (!DateDP.SelectedDate.HasValue)
            {
                MessageBox.Show("Не выбрана дата дня рождения");
                return;
            }

            if (DateDP.SelectedDate.Value > DateTime.UtcNow)
            {
                MessageBox.Show("Укажи верную дату дня рождения");
                return;
            }

            var users = _userService.GetAll();

            if(users.Any(u=>u.Login == LoginTB.Text))
            {
                MessageBox.Show("Логин занят");
                return;
            }

            User user = new User()
            {
                Name = NameTB.Text,
                Surname = SurnameTB.Text,
                Login = LoginTB.Text,
                PasswordHash = PasswordTB.Text,
                Birthday = DateDP.SelectedDate.Value,

                Role = (Role)RoleCB.SelectedIndex 

            };

            _userService.Add(user);
            Close();
        }
            
            
        



    }
}
