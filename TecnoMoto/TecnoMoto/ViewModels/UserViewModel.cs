using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class UserViewModel : ObservableObject
    {

        #region Properties

        private bool canExecute = true;

        public ICommand RefreshCommand { get; set; }

        //public users userModel { get; set; }

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

        public ObservableCollection<users> listUsers { get; set; }

        public ObservableCollection<type_user> listTypeUser { get; set; }

        private users _userModel;

        public users userModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public UserViewModel()
        {
            userModel = new users();
            RefreshCommand = new RelayCommand(SaveClient, param => this.CanExecute);
            listUsers = ListUsers();
            listTypeUser = ListTUsers();
        }

        #region Methods
        private void SaveClient(object obj)
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
                    {

                    }
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

        public async Task<bool> isExist(string us, string pass)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var user = db.users.Where(X => X.USERS.ToUpper() == us.ToUpper() && X.PASS == pass).FirstOrDefault();

                    if (user != null)
                        return await Task.FromResult(true);
                    else
                        return await Task.FromResult(false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ObservableCollection<users> ListUsers()
        {

            using (Db_TecnoMotos db = new Db_TecnoMotos())
            {
                try
                {
                    return new ObservableCollection<users>(db.users.Include(J => J.type_user).ToList());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public ObservableCollection<type_user> ListTUsers()
        {

            using (Db_TecnoMotos db = new Db_TecnoMotos())
            {
                try
                {
                    return new ObservableCollection<type_user>(db.type_user.ToList());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public async Task<bool> SaveUserAsync(users u)
        {
            using (Db_TecnoMotos db = new Db_TecnoMotos())
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.users.Add(u);
                        await db.SaveChangesAsync();
                        tran.Commit();
                        listUsers.Add(u);
                        userModel = new users();
                        return await Task.FromResult(true);
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        public async Task<bool> UpdateUserAsync(users us)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    db.Entry(us).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    var pro = listUsers.Where(X => X.ID_USER == us.ID_USER).First();
                    pro = us;
                    userModel = new users();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> IsValid(users us , string pass, string pass1)
        {
            try
            {
                if (pass.Equals(pass1) 
                    || !(string.IsNullOrEmpty(us.PHONE) 
                    || string.IsNullOrEmpty(us.USERNAME) 
                    || string.IsNullOrEmpty(us.USERS) 
                    || us.ID_TYPE_USER == 0))
                    return await Task.FromResult(true);
                else
                    return await Task.FromResult(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion





    }
}
