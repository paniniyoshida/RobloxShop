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

        private readonly Dictionary<int, int> _promocodeComboBoxMap = new Dictionary<int, int>();
        private readonly Dictionary<int, int> _userComboBoxMap = new Dictionary<int, int>();

        public UpdateCheckWindow(int checkId)
        {
            _checkId = checkId;
            InitializeComponent();

            _checkService = DependencyResolver.GetService<ICheckService>();
            _userService = DependencyResolver.GetService<IUserService>();
            _promocodeService = DependencyResolver.GetService<IPromocodeService>();

            List<User> users = _userService.GetAll();
            List<Promocode> promocodes = _promocodeService.GetAll();

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
                if (!_userComboBoxMap.TryGetValue(addUserComboBoxIndex, out _))
                {
                    _userComboBoxMap.Add(addUserComboBoxIndex, user.Id);
                    addUserComboBox.Items.Insert(addUserComboBoxIndex, user.Name + " " + user.Surname);
                    addPromocodeComboBoxIndex++;
                }
            }

            Check check = _checkService.Get(checkId);

            addDateDatePicker.DisplayDate = check.Date;

            addUserComboBox.SelectedIndex = _userComboBoxMap.FirstOrDefault(x => x.Value == check.UserID).Key;

            addPromocodeComboBox.SelectedIndex =_promocodeComboBoxMap.FirstOrDefault(x => x.Value == (check.PromocodeID ?? 0)).Key;
        }

        private void addCheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (addPromocodeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран промокод!");
                return;
            }

            if (addUserComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран пользователь!");
                return;
            }

            if (!addDateDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Не выбрана дата");
                return;
            }

            if (addDateDatePicker.SelectedDate.Value > DateTime.UtcNow)
            {
                MessageBox.Show("Дата не может быть больше текущей");
                return;
            }

            Check check = new Check()
            {
                Id = _checkId,
                UserID = _userComboBoxMap[addUserComboBox.SelectedIndex],
                PromocodeID = _promocodeComboBoxMap[addPromocodeComboBox.SelectedIndex],
                Date = addDateDatePicker.SelectedDate.Value
            };

            _checkService.Update(check);
            Close();
        }
    }
}
