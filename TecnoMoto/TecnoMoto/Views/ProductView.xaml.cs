using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using TecnoMoto.Common;
using TecnoMoto.Models;
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

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            bool isExist = false;
            var tipo = splitBtnTProd.SelectedItem as type_product;
            if (MyContext.productModel.ID_PRODUCT != 0)
                isExist = await MyContext.UpdateProductAsync(MyContext.productModel, tipo);
            else
                isExist = await MyContext.SaveProd(MyContext.productModel, tipo);
            if (isExist)
                await this.ShowMessageAsync(Constantes.EXITO, Constantes.INSERCCION_EXITOSA, MessageDialogStyle.Affirmative);
            else
                await this.ShowMessageAsync(Constantes.ERROR, Constantes.VERIFICAR_DATOS);
        }

        private void listModel1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    var pro = dgr.DataContext as product;
                    MyContext.productModel = dgr.DataContext as product;
                    splitBtnTProd.SelectedIndex = ((int)pro.ID_TYPE_PRODUCT - 1);
                    //txtPass1.Password = user.PASS;
                    //txtPass.Password = user.PASS;
                }
            }
        }

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    flyProd.IsOpen = true;
        //}

        //private void btnIngresar_Click(object sender, RoutedEventArgs e)
        //{
        //    MyContext.SaveTypeProdAsync(txtNameTypeProd.Text);
        //    splitBtnTProd.Items.Refresh();
        //    flyProd.IsOpen = false;

        //}



        //private void Tile_Click(object sender, RoutedEventArgs e)
        //{

        //    var window = Window.GetWindow(this);

        //    Views.HomeWindow _home = new HomeWindow();
        //    this.Close();
        //    _home.ShowDialog();
        //}
    }
}
