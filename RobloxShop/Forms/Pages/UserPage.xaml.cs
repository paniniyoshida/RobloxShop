using RobloxShop.Entities.Enums;
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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {

        private readonly IUserService _userService;

        public UserPage()
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();
            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow userWindow = new AddUserWindow();
            userWindow.ShowDialog();
            Reload();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as UserViewData;
            if (viewdata != null)
            {
                _userService.Delete(viewdata.Id);
            }
            Reload();
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as UserViewData;
            UpdateUserWindow userWindow = new UpdateUserWindow(viewdata.Id);
            userWindow.ShowDialog();
            Reload();
        }

        void Reload()
        {
            table_grid.ItemsSource = _userService.GetAll().Select(t => new UserViewData
            {
                Id = t.Id,
                Name = t.Name,
                Surname = t.Surname,
                Login = t.Login,
                PasswordHash = t.PasswordHash,
                Role = t.Role == Role.Admin ?"Администратор": "Пользователь",
                Birthday = t.Birthday.ToShortDateString(),
            });
        }

        private class UserViewData
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Surname { get; set; }

            public string Login { get; set; }

            public string PasswordHash { get; set; }

            public string Role { get; set; }

            public string Birthday { get; set; }
        }
    }
}
