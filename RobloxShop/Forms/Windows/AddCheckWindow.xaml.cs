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

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCheckWindow.xaml
    /// </summary>
    public partial class AddCheckWindow : Window
    {

        private readonly IPromocodeService _promocodeService;

        private readonly IUserService _userService;

        private readonly ICheckService _checkService;



        public AddCheckWindow()
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();
            _promocodeService = DependencyResolver.GetService<IPromocodeService>();
            _checkService = DependencyResolver.GetService<ICheckService>();

            List<Promocode> promocodes = _promocodeService.GetAll();

            List<User> users = _userService.GetAll();


            foreach (Promocode promocode in promocodes)
            {
                addPromocodeComboBox.Items.Insert(promocode.Id, promocode.Name);
            }

            foreach (User user in users)
            {
                addUserComboBox.Items.Insert(user.Id, user.Name + " " + user.Surname);
            }

        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            Check check = new Check()
            {
                UserID = addUserComboBox.SelectedIndex,
                PromocodeID = addPromocodeComboBox.SelectedIndex,
                Date = addDateDatePicker.SelectedDate.Value
            };

            _checkService.Add(check);
        }
    }
}
