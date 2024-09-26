using Newtonsoft.Json;
using RobloxShop.Entities;
using RobloxShop.Forms.Windows;
using RobloxShop.Forms.Windows.Update;
using RobloxShop.Services;
using RobloxShop.Services.Interfaces;
using RobloxShop.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RobloxShop.Forms.Pages
{
    /// <summary>
    /// Логика взаимодействия для TagPage.xaml
    /// </summary>
    public partial class TagPage : Page
    {
        private readonly ITagService _tagService;
        public TagPage()
        {
            InitializeComponent();
            _tagService = DependencyResolver.GetService<ITagService>();

            Reload();

        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            AddTagWindow tagWindow = new AddTagWindow();
            tagWindow.ShowDialog();
            Reload();

        }
        void Reload()
        {
            table_grid.ItemsSource = _tagService.GetAll().Select(t => new TagViewData
            {
                Id = t.Id,
                Name = t.Name,
            });
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as TagViewData;
            if (viewdata != null)
            {
                _tagService.Delete(viewdata.Id);
            }
                Reload();
        }

        private class TagViewData
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as TagViewData;

            //UpdateTagWindow tagWindow = new UpdateTagWindow(viewdata.Id);

           // tagWindow.ShowDialog();

            Reload();
        }

        private void import_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }


                string fileName = openFileDialog.FileName;

                string json = File.ReadAllText(fileName);

                Tag tag = JsonConvert.DeserializeObject<Tag>(json);


                _tagService.Add(tag);

                Reload();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Возникла ошибка");
            }
        }

        private void export_button_Click(object sender, RoutedEventArgs e)
        {
            var viewdata = table_grid.SelectedItem as TagViewData;
            if (viewdata != null)
            {


                Tag tag = _tagService.Get(viewdata.Id);

                string json = JsonConvert.SerializeObject(tag);

                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }



                string fileName = saveFileDialog.FileName;

                File.WriteAllText(fileName, json);

            }
        }
    }
}
