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
using TecnoMoto.Models;
using TecnoMoto.ViewModels;

namespace TecnoMoto.Views
{
    /// <summary>
    /// Lógica de interacción para ProviderView.xaml
    /// </summary>
    public partial class ProviderView : MetroWindow
    {
        #region Properties
        public ProviderViewModel MyContext { get; set; }

        #endregion

        public ProviderView()
        {
            InitializeComponent();
            MyContext = new ProviderViewModel();
            this.DataContext = MyContext;
        }

        private async void btnSave_provider(object sender, RoutedEventArgs e)
        {
            bool isValid;
            if (MyContext.providerModel.ID_PROVIDER != 0)
                isValid = await MyContext.UpdateProviderAsync(MyContext.providerModel);
            else
                isValid = await MyContext.SaveProviderAsync(MyContext.providerModel);

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
                    MyContext.providerModel = dgr.DataContext as provider;
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(MyContext.providerModel.NAME_PROVIDER))
            {
                var asd = MyContext.listProvider.Where(X => X.NAME_PROVIDER.Contains(MyContext.providerModel.NAME_PROVIDER)).ToList();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
