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

namespace RobloxShop.Forms.Windows.Update
{
    /// <summary>
    /// Логика взаимодействия для UpdateTagWindow.xaml
    /// </summary>
    public partial class UpdateTagWindow : Window
    {
        private readonly ITagService _tagService;

        private int _tagId;

        public UpdateTagWindow(int tagId)
        {
            InitializeComponent();
            _tagId = tagId;


            _tagService = DependencyResolver.GetService<ITagService>();

            Tag tag = _tagService.Get(tagId);

            tagNameTextBox.Text = tag.Name;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tag tag = new Tag()
            {
                Id = _tagId,
                Name = tagNameTextBox.Text,
             
            };
            _tagService.Update(tag);
            Close();
        }
    }
}
