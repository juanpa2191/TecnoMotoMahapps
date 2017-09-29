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
    public class BuyViewModel : ObservableObject
    {


        #region MyRegion

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

        //TypeProductViewModel tpVM = new TypeProductViewModel();
        public ObservableCollection<buy> listBuy { get; set; }

        //public ObservableCollection<product> listProduct { get; set; }

        #endregion



        public BuyViewModel()
        {
            buyModel = new buy();
            listBuy = FindBuy();
            //listTypeProduct = tpVM.ListTypeProd();
            //listProduct = FindProduct();
        }


        public ObservableCollection<buy> FindBuy()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                    return new ObservableCollection<buy>(db.buy.Include("users.type_user").Where(x => x.ID_USER == Constantes.TipoUsuario.PROVEEDOR).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
