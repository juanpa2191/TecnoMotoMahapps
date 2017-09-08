using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class ProviderViewModel : ObservableObject
    {

        //#region Properties
        //public provider _providerModel;
        //public provider providerModel
        //{
        //    get { return _providerModel; }
        //    set
        //    {
        //        _providerModel = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public ObservableCollection<provider> listProvider { get; set; }


        //#endregion


        //public ProviderViewModel()
        //{
        //    providerModel = new provider();
        //    listProvider = ListProvi();
        //}

        //#region methods
        //public ObservableCollection<provider> ListProvi()
        //{

        //    using (Db_TecnoMotos db = new Db_TecnoMotos())
        //    {
        //        try
        //        {
        //            return new ObservableCollection<provider>(db.providers.ToList());
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}


        //public async Task<bool> SaveProviderAsync(provider tp)
        //{
        //    using (Db_TecnoMotos db = new Db_TecnoMotos())
        //    {
        //        using (var tran = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                db.providers.Add(tp);
        //                await db.SaveChangesAsync();
        //                tran.Commit();
        //                listProvider.Add(tp);
        //                providerModel = new provider();
        //                return await Task.FromResult(true);
        //            }
        //            catch (Exception)
        //            {
        //                tran.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        //public async Task<bool> UpdateProviderAsync(provider prod)
        //{
        //    try
        //    {
        //        using (Db_TecnoMotos db = new Db_TecnoMotos())
        //        {
        //            db.Entry(prod).State = EntityState.Modified;
        //            await db.SaveChangesAsync();
        //            var pro = listProvider.Where(X => X.ID_PROVIDER == prod.ID_PROVIDER).First();
        //            pro = prod;
        //            providerModel = new provider();
        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //        throw;
        //    }
        //}

        //#endregion

    }
}
