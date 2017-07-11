using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class UserViewModel
    {

        #region Properties

        private bool canExecute = true;

        public ICommand RefreshCommand { get; set; }

        //private ICommand toggleExecuteCommand { get; set; }

        public users userModel { get; set; }
       // public client clientModel { get; set; }

        //public ObservableCollection<client> listModel { get; set; }

        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }

        /*public ICommand ToggleExecuteCommand
        {
            get
            {
                return toggleExecuteCommand;
            }
            set
            {
                toggleExecuteCommand = value;
            }
        }

        public ICommand HiButtonCommand
        {
            get
            {
                return RefreshCommand;
            }
            set
            {
                RefreshCommand = value;
            }
        }*/

        //public struct Tipos
        //{
        //    public int ID { get; set; }
        //    public string Display { get; set; }
        //}

        //public ObservableCollection<Tipos> TiposID { get; set; }

        #endregion


        public UserViewModel()
        {
            userModel = new users();
            RefreshCommand = new RelayCommand(SaveClient, param => this.CanExecute);
        }


        private  void SaveClient(object obj)
        {
            try
            {
                var passwordBox = obj as PasswordBox;
                var password = passwordBox.Password;
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var user = db.users.Where(X => X.PASS == password && X.USERS == userModel.USERS).FirstOrDefault();
                    if (user != null)
                    {
                        //return await Task.FromResult(true);
                    }
                    else
                        //return await Task.FromResult(true);
                    //await db.SaveChangesAsync();
                    //listModel.Add(clientModel);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool isExist()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var client = db.clients.FirstOrDefault();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
