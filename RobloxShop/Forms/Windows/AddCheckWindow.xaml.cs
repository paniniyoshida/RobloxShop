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

        private readonly Dictionary<int, int> _promocodeComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _userComboBoxMap = new Dictionary<int, int>();



        public AddCheckWindow()
        {
            InitializeComponent();

            _userService = DependencyResolver.GetService<IUserService>();
            _promocodeService = DependencyResolver.GetService<IPromocodeService>();
            _checkService = DependencyResolver.GetService<ICheckService>();

            List<Promocode> promocodes = _promocodeService.GetAll();

            List<User> users = _userService.GetAll();

            addPromocodeComboBox.Items.Insert(0, "Пусто");

            int addPromocodeComboBoxIndex = 0;
            foreach (Promocode promocode in promocodes)
            {
                _promocodeComboBoxMap.Add(addPromocodeComboBoxIndex, promocode.Id);
                addPromocodeComboBox.Items.Insert(addPromocodeComboBoxIndex, promocode.Name);
                addPromocodeComboBoxIndex++;
            }

            int addUserComboBoxIndex = 0;
            foreach (User user in users)
            {
                _userComboBoxMap.Add(addUserComboBoxIndex, user.Id);
                addUserComboBox.Items.Insert(addUserComboBoxIndex, user.Name + " " + user.Surname);
                addPromocodeComboBoxIndex ++;
            }

        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            Check check = new Check()
            {
                UserID =_userComboBoxMap[addUserComboBox.SelectedIndex],
                PromocodeID =_promocodeComboBoxMap[addPromocodeComboBox.SelectedIndex],
                Date = addDateDatePicker.SelectedDate.Value
            };

            _checkService.Add(check);
        }
    }
}
