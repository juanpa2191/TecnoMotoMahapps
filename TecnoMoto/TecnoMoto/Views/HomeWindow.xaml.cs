using MahApps.Metro.Controls;
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

namespace TecnoMoto.Views
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeWindow : MetroWindow
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void Tile_Click_Prod(object sender, RoutedEventArgs e)
        {
            Views.ProductView _prod = new ProductView();
            this.Close();
            _prod.ShowDialog();
        }

        private void Tile_Click_Type_Prod(object sender, RoutedEventArgs e)
        {
            Views.TypeProductView _TProd = new TypeProductView();
            this.Close();
            _TProd.ShowDialog();
        }
    }
}
