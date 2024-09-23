using RobloxShop.Entities;
using RobloxShop.Repository.Interfaces;
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

namespace RobloxShop.Forms.Windows.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdateCheckWindow.xaml
    /// </summary>
    public partial class UpdateCheckWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ICheckService _checkService;
        private readonly IPromocodeService _promocodeService;
        private int _checkId = 0;

        public UpdateCheckWindow(int checkId)
        {
            _checkId = checkId;
            InitializeComponent();

            _checkService = DependencyResolver.GetService<ICheckService>();
            _userService = DependencyResolver.GetService<IUserService>();
            _promocodeService = DependencyResolver.GetService<IPromocodeService>();

            List<User> users = _userService.GetAll();
            List<Promocode> promocodes = _promocodeService.GetAll();

            foreach (User user in users)
            {
                addUserComboBox.Items.Insert(user.Id, user.Name + " " + user.Surname);
            }

            foreach (Promocode promocode in promocodes)
            {
                addPromocodeComboBox.Items.Insert(promocode.Id, promocode.Name);
            }

            Check check = _checkService.Get(checkId);

            addDateDatePicker.DisplayDate = check.Date;

            addUserComboBox.SelectedIndex = check.UserID;

            addPromocodeComboBox.SelectedIndex = check.PromocodeID ?? 0;
        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
           
            Check check = new Check()
            {
                Id = _checkId,
                UserID = addUserComboBox.SelectedIndex,
                PromocodeID = addPromocodeComboBox.SelectedIndex,
                Date = addDateDatePicker.SelectedDate.Value
            };

            _checkService.Update(check);
        }
    }
}
