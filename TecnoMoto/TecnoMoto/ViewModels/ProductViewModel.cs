using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.DataManager;
using TecnoMoto.Models;

namespace TecnoMoto.ViewModels
{
    public class ProductViewModel
    {

        #region MyRegion

        TypeProductViewModel tpVM = new TypeProductViewModel();
        ProductDataManager tDM = new ProductDataManager();
        public ICollection<type_product> listTypeProduct { get; set; }

        public ICollection<product> listProduct { get; set; }

        #endregion


        public ProductViewModel()
        {
            listTypeProduct = tpVM.ListTypeProd();
            listProduct = tDM.FindProduct();

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
                        ACTIVE = "1",
                        NAME_TYE_PRODUCT = name
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

    }
}
