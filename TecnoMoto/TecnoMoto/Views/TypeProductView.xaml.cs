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
            var name = txtProd.Text;
            var ac = switchActive.IsChecked;

            var isValid = await MyContext.SaveTypeProdAsync(name, ac.Value);

            if (isValid)
                await this.ShowMessageAsync("Exito", "Insercción exitosa", MessageDialogStyle.Affirmative);
            else
                await this.ShowMessageAsync("Error !", "Verifica tus datos");
        }

        private void listModel1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    var asd = dgr.DataContext as type_product;
                    var rowview = grid.SelectedItem as DataRowView;
                }
            }
        }
    }
}
