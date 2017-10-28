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
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : MetroWindow
    {
        #region MyRegion
        public UserViewModel MyContext { get; set; }
        #endregion

        public UserView()
        {
            InitializeComponent();
            MyContext = new UserViewModel();
            this.DataContext = MyContext;
        }

        private void listModel1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    var user = dgr.DataContext as users;
                    MyContext.userModel = dgr.DataContext as users;
                    splitBtnTUser.SelectedIndex = ((int)user.type_user.ID_TYPE_USER -1);
                    txtPass1.Password = user.PASS;
                    txtPass.Password = user.PASS;
                }
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtPass1.Password == txtPass.Password)
            {
                var typeUser = splitBtnTUser.SelectedItem as type_user;

                bool isValid;
                if (await MyContext.IsValid(MyContext.userModel, typeUser, txtPass.Password, txtPass1.Password))
                {
                    MyContext.userModel.PASS = txtPass.Password;
                    if (MyContext.userModel.ID_USER != 0)
                        isValid = await MyContext.UpdateUserAsync(MyContext.userModel, typeUser);
                    else
                        isValid = await MyContext.SaveUserAsync(MyContext.userModel, typeUser);

                    if (isValid)
                    {
                        txtPass.Clear();
                        txtPass1.Clear();
                        await this.ShowMessageAsync(Constantes.EXITO, Constantes.INSERCCION_EXITOSA, MessageDialogStyle.Affirmative);
                    }
                    else
                        await this.ShowMessageAsync(Constantes.ERROR, Constantes.VERIFICAR_DATOS);
                }
                else
                    await this.ShowMessageAsync(Constantes.ERROR, Constantes.VERIFICAR_DATOS);
            }
            else
                await this.ShowMessageAsync(Constantes.ERROR, Constantes.CONTRASENA_INCORRECTA);


        }
    }
}
