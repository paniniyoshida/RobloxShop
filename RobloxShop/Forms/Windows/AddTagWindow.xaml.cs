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
    /// Логика взаимодействия для AddTagWindow.xaml
    /// </summary>
    public partial class AddTagWindow : Window
    {
        private readonly ITagService _tagService;
        public AddTagWindow()
        {
            InitializeComponent();
            _tagService = DependencyResolver.GetService<ITagService>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tagNameTextBox.Text))
            {
                MessageBox.Show("Не написано название!");
                return;
            }

            Entities.Tag tag = new Entities.Tag()
            {
                Name = tagNameTextBox.Text,

            };

            _tagService.Add(tag);
            Close();
        }
    }
}
