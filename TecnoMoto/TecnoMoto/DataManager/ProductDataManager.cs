using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;

namespace TecnoMoto.DataManager
{
    public class ProductDataManager
    {

        public List<product> FindProduct ()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    //var list = db.products.ToList();
                    var list = db.products.Include("provider").Include("type_product").ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /*public bool SaveTypeProdAsync(string name)
        {
            type_product tpVM = new type_product();
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    tpVM = new type_product()
                    {
                        ACTIVE = "1",
                        NAME_TYE_PRODUCT = name
                    };

                    db.type_product.Add(tpVM);
                    db.SaveChanges();
                    listTypeProduct.Add(tpVM);
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}
