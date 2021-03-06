﻿using System;
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
using TecnoMoto.Views;

namespace TecnoMoto.ControlUser
{
    /// <summary>
    /// Lógica de interacción para HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {
        public HomeUserControl()
        {
            InitializeComponent();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {

            var window = Window.GetWindow(this);

            Views.HomeWindow _home = new HomeWindow();
            window.Close();
            _home.ShowDialog();
        }
    }
}
