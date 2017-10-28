using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Common;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class DetailBuyViewModel : ObservableObject
    {

        #region Properties

        //public TypeProductViewModel tpVM = new TypeProductViewModel();

        //public BuyViewModel bVM = new BuyViewModel();
        public ObservableCollection<product> listProduct { get; set; }

        public ObservableCollection<users> listUserProv { get; set; }

        public ObservableCollection<type_product> listTypeProd { get; set; }

        private users _User;

        public users userModel
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged();
            }
        }


        private buy _Buy;

        public buy buyModel
        {
            get { return _Buy; }
            set
            {
                _Buy = value;
                OnPropertyChanged();
            }
        }


        #endregion

        public DetailBuyViewModel(long? idBuy)
        {
            listUserProv = idBuy.Value != 0 ? listProvider(idBuy.Value) : listProvider();
            userModel = idBuy.Value != 0 ? listUserProv.First() : new users();
            listProduct = listProd();
            listTypeProd = listTProd();

        }

        #region NewBuy
        public ObservableCollection<users> listProvider()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    List<users> listUser = new List<users>();

                    listUser.Add(new users()
                    {
                        ID_TYPE_USER = 0,
                        USERNAME = Constantes.SELECCIONE
                    });
                    listUser.AddRange(db.users.Where(x => x.ID_TYPE_USER == Constantes.TipoUsuario.PROVEEDOR).ToList());
                    return new ObservableCollection<users>(listUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<type_product> listTProd()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    List<type_product> listTProd = new List<type_product>();

                    listTProd.Add(new type_product()
                    {
                        ID_TYPE_PRODUCT = 0,
                        NAME_TYPE_PRODUCT = Constantes.SELECCIONE
                    });
                    listTProd.AddRange(db.type_product.ToList());
                    return new ObservableCollection<type_product>(listTProd);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<product> listProd()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    return new ObservableCollection<product>(db.products.Where(x => x.ACTIVE).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region DetailBuy
        public ObservableCollection<users> listProvider(long idBuy)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                    return new ObservableCollection<users>(db.buy.Include("users").Where(x => x.ID_BUY == idBuy).Select(x => x.users).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        

    }
}
