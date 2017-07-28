using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;

namespace TecnoMoto.ViewModels
{
    public class ProductViewModel
    {

        #region MyRegion

        TypeProductViewModel tpVM = new TypeProductViewModel();
        public ICollection<type_product> listTypeProduct { get; set; }

        public ICollection<product> listProduct { get; set; }

        #endregion


        public ProductViewModel()
        {
            listTypeProduct = tpVM.ListTypeProd();
            listProduct = FindProduct();

        }

        public bool SaveTypeProdAsync(string name)
        {
            type_product tp = new type_product();
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    tp = new type_product()
                    {
                        ACTIVE = true,
                        NAME_TYPE_PRODUCT = name
                    };

                    db.type_product.Add(tp);
                    db.SaveChanges();
                    listTypeProduct = tpVM.ListTypeProd();
                    //listTypeProduct.Add(tpVM);
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<product> FindProduct()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var list = db.products.Include("provider").Include("type_product").ToList();
                    return list;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
