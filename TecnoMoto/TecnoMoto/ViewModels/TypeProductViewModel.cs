using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;

namespace TecnoMoto.ViewModels
{
    public class TypeProductViewModel
    {

        #region Properties

        public type_product typeProdModel { get; set; }
        public ICollection<type_product> listTypeProduct { get; set; }

        #endregion


        public TypeProductViewModel()
        {
            typeProdModel = new type_product();
            listTypeProduct = ListTypeProd();
        }

        public ICollection<type_product> ListTypeProd()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var list = db.type_product.ToList();
                    return list;
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
