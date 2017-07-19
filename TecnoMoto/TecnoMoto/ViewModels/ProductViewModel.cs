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

        #endregion


        public ProductViewModel()
        {
            listTypeProduct = tpVM.ListTypeProd();

        }

        public bool SaveTypeProdAsync(string name)
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
        }

    }
}
