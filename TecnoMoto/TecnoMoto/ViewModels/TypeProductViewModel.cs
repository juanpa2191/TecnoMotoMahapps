using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class TypeProductViewModel : ObservableObject
    {

        #region Properties

        public type_product _typeProdModel;
        public type_product typeProdModel
        {
            get { return _typeProdModel; }
            set
            {
                _typeProdModel = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<type_product> listTypeProduct { get; set; }
        #endregion


        public TypeProductViewModel()
        {
            typeProdModel = new type_product();
            listTypeProduct = ListTypeProd();
        }

        public ObservableCollection<type_product> ListTypeProd()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    return new ObservableCollection<type_product>(db.type_product.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> SaveTypeProdAsync(string name, bool active)
        {
            using (Db_TecnoMotos db = new Db_TecnoMotos())
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        type_product tp = new type_product()
                        {
                            ACTIVE = active,
                            NAME_TYPE_PRODUCT = name
                        };

                        db.type_product.Add(tp);
                        await db.SaveChangesAsync();
                        tran.Commit();
                        listTypeProduct.Add(tp);
                        typeProdModel = new type_product();
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

    }
}
