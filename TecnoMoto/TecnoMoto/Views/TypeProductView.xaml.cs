using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para TypeProductView.xaml
    /// </summary>
    public partial class TypeProductView : MetroWindow
    {

        #region Properties

        public TypeProductViewModel MyContext { get; set; }
        #endregion
        public TypeProductView()
        {
            InitializeComponent();
            MyContext = new TypeProductViewModel();
            this.DataContext = MyContext;
        }

        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isValid;
                if (MyContext.typeProdModel.ID_TYPE_PRODUCT != 0)
                    isValid = await MyContext.UpdateTypeProdAsync(MyContext.typeProdModel);
                else
                    isValid = await MyContext.SaveTypeProdAsync(MyContext.typeProdModel);

                if (isValid)
                    await this.ShowMessageAsync(Constantes.EXITO, Constantes.INSERCCION_EXITOSA, MessageDialogStyle.Affirmative);
                else
                    await this.ShowMessageAsync(Constantes.ERROR, Constantes.VERIFICAR_DATOS);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listModel1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        MyContext.typeProdModel = dgr.DataContext as type_product;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
