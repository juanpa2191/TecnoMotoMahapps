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
            UserViewModel userVM = new UserViewModel();

            string us = txtUsuario.Text;
            string pass = txtPassword.Password;
            if (string.IsNullOrEmpty(us) && string.IsNullOrEmpty(pass))
                await this.ShowMessageAsync("Error !", "Campos vacios");
            else
            {
                if (await userVM.isExist(us, pass))
                {
                    await this.ShowMessageAsync("Exito", "Tus datos son correctos", MessageDialogStyle.Affirmative);
                    Views.HomeWindow _ver = new Views.HomeWindow();
                    this.Close();
                    _ver.ShowDialog();
                }
                else
                {
                    txtPassword.Clear();
                    txtUsuario.Clear();
                    await this.ShowMessageAsync("Error !", "Verifica tus datos");
                }
            }

            //if (txtUsuario.Text == "admin" && txtPassword.Password == "123")
            //{
            //    await this.ShowMessageAsync("Exito", "Tus datos son correctos", MessageDialogStyle.Affirmative);
            //    Views.HomeWindow _ver = new Views.HomeWindow();
            //    this.Close();
            //    _ver.ShowDialog();
            //}
            //else
            //    await this.ShowMessageAsync("Error !", "Verifica tus datos");
        }
    }
}
