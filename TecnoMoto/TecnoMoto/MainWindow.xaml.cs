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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TecnoMoto.Common;
using TecnoMoto.ViewModels;

namespace TecnoMoto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public UserViewModel MyContext { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MyContext = new UserViewModel();
            this.DataContext = MyContext;
        }


        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Wait.IsActive = true;
                UserViewModel userVM = new UserViewModel();

                string us = txtUsuario.Text;
                string pass = txtPassword.Password;
                if (string.IsNullOrEmpty(us) && string.IsNullOrEmpty(pass))
                    await this.ShowMessageAsync(Constantes.ERROR, Constantes.CAMPOS_VACIOS);
                else
                {
                    if (await userVM.isExist(us, pass))
                    {
                        Wait.IsActive = false;
                        await this.ShowMessageAsync(Constantes.EXITO, Constantes.DATOS_CORRECTOS, MessageDialogStyle.Affirmative);
                        Views.HomeWindow _ver = new Views.HomeWindow();
                        this.Close();
                        _ver.ShowDialog();
                    }
                    else
                    {
                        Wait.IsActive = false;
                        txtPassword.Clear();
                        txtUsuario.Clear();
                        await this.ShowMessageAsync(Constantes.ERROR, Constantes.VERIFICAR_DATOS);
                    }
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync(Constantes.ERROR, ex.Message);
                throw;
            }
        }
    }
}
