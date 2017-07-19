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
using TecnoMoto.ViewModels;

namespace TecnoMoto.Views
{
    /// <summary>
    /// Lógica de interacción para ProductView.xaml
    /// </summary>
    public partial class ProductView : MetroWindow
    {

        #region Properties

        public ProductViewModel MyContext { get; set; }

        #endregion

        public ProductView()
        {
            InitializeComponent();
            MyContext = new ProductViewModel();
            this.DataContext = MyContext;
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            flyProd.IsOpen = true;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            MyContext.SaveTypeProdAsync(txtNameTypeProd.Text);
            flyProd.IsOpen = false;
        }



        //private void Tile_Click(object sender, RoutedEventArgs e)
        //{

        //    var window = Window.GetWindow(this);

        //    Views.HomeWindow _home = new HomeWindow();
        //    this.Close();
        //    _home.ShowDialog();
        //}
    }
}
