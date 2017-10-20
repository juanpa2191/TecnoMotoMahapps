using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class DetailBuyViewModel : ObservableObject
    {

        #region Properties
        public ObservableCollection<product> listProduct { get; set; }

        public ObservableCollection<users> listUser { get; set; }

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

        }
    }
}
