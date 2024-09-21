﻿using RobloxShop.Entities;
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

namespace RobloxShop.Forms.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPromocodeWindow.xaml
    /// </summary>
    public partial class AddPromocodeWindow : Window
    {
        private readonly IPromocodeService _promocodeService;

        public AddPromocodeWindow()
        {
            InitializeComponent();

            _promocodeService = DependencyResolver.GetService<IPromocodeService>();
        }

        private void addProductCartButton_Click(object sender, RoutedEventArgs e)
        {
            Promocode promocode = new Promocode()
            {
                Name = Name.Text,
                Code = Code.Text,
                Discount = int.Parse(Discount.Text),

            };
            _promocodeService.Add(promocode);
            Close();
        }
    }
}
