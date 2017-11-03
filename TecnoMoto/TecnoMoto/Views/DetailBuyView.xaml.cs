using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para DetailBuyView.xaml
    /// </summary>
    public partial class DetailBuyView : MetroWindow
    {
        #region Properties
        public DetailBuyViewModel MyContext { get; set; }
        public ObservableCollection<product> listP { get; set; }

        #endregion

        public DetailBuyView(long? idBuy)
        {
            InitializeComponent();
            MyContext = new DetailBuyViewModel(idBuy);
            this.DataContext = MyContext;
            txtCodeP.Focusable = true;
            txtCodeP.Focus();
            listP = MyContext.listProduct;
        }

        private void splitBtnProv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var us = splitBtnProv.SelectedItem as users;
                if (us.ID_TYPE_USER != 0)
                    MyContext.userModel = us;
                else
                    MyContext.userModel = new users();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async void listProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                long c = 0;
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        var u = splitBtnProv.SelectedItem as users;
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        var pro = dgr.DataContext as product;
                        if (u.ID_USER !=0 && pro.ID_PRODUCT != 0)
                        {
                            if (!string.IsNullOrEmpty(pCant.Text))
                                c = long.Parse(pCant.Text);
                            else
                                c++;

                            await MyContext.addProduct(MyContext.buyModel.ID_BUY, pro, u, c);
                            pCant.Clear();
                        }
                        else
                            await this.ShowMessageAsync(Constantes.ERROR, Constantes.FALTA_PRESTADOR);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtCodeP_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodeP.Text) || !string.IsNullOrEmpty(txtNameProd.Text))
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtNameProd_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodeP.Text) || !string.IsNullOrEmpty(txtNameProd.Text))
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
