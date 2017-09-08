﻿using MahApps.Metro.Controls;
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

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var typeUser = splitBtnTUser.SelectedItem as type_user;
            MyContext.userModel.type_user = typeUser;
            bool isValid;
            if (await MyContext.IsValid(MyContext.userModel, txtPass.Password, txtPass1.Password))
            {
                MyContext.userModel.PASS = txtPass.Password;
                if (MyContext.userModel.ID_USER != 0)
                    isValid = await MyContext.UpdateUserAsync(MyContext.userModel);
                else
                    isValid = await MyContext.SaveUserAsync(MyContext.userModel);

                if (isValid)
                    await this.ShowMessageAsync("Exito", "Insercción exitosa", MessageDialogStyle.Affirmative);
                else
                    await this.ShowMessageAsync("Error !", "Verifica tus datos");
            }
            else
                await this.ShowMessageAsync("Error !", "Verifica tus datos");



        }
    }
}