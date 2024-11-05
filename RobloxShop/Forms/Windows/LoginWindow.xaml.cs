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
using ConsolePasswordMasker;
using ConsolePasswordMasker.Core;
using System.Dynamic;
using Microsoft.VisualBasic.Logging;

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;

        private const string _defaultUserLogin = "admin";
        private const string _defaultUserPassword = "admin";

        public LoginWindow()
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();

            CheckDefaultUser();
        }

        private void CheckDefaultUser()
        {
            User? user = _userService.GetByLoginAndPassword(_defaultUserLogin, _defaultUserPassword);

            if (user is not null)
                return;

            user = new User()
            {
                Login = _defaultUserLogin,
                PasswordHash = _defaultUserPassword,
                Role = Entities.Enums.Role.Admin,
                Surname = _defaultUserLogin,
                Name = _defaultUserLogin,
                Birthday = DateTime.UtcNow
            };
            
            _userService.Add(user);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string login = Login.Text;
            string password = Password.Password.ToString();
            User? user = _userService.GetByLoginAndPassword(login, password);
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }
            Hide();
            MainWindow mainWindow = new MainWindow(user.Role);
            mainWindow.ShowDialog();
            Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow(false);
            addUserWindow.ShowDialog();
            

        }
    }
}
