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
    public class ProductViewModel : ObservableObject
    {

        #region MyRegion

        private product _ProductModel;

        public product productModel
        {
            get { return _ProductModel; }
            set
            {
                _ProductModel = value;
                OnPropertyChanged();
            }
        }

        TypeProductViewModel tpVM = new TypeProductViewModel();
        public ObservableCollection<type_product> listTypeProduct { get; set; }

        public ObservableCollection<product> listProduct { get; set; }

        #endregion


        public ProductViewModel()
        {
            productModel = new product();
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

        public async Task<bool> SaveProd (product p , type_product tp)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    p.ID_TYPE_PRODUCT = tp.ID_TYPE_PRODUCT;
                    p.ACTIVE = true;
                    db.products.Add(p);
                    await db.SaveChangesAsync();
                    p.type_product = tp;
                    listProduct.Add(p);
                    productModel = new product();
                    return await Task.FromResult(true);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
                throw;
            }
        }

        public async Task<bool> UpdateProductAsync(product p, type_product tp)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    p.ID_TYPE_PRODUCT = tp.ID_TYPE_PRODUCT;
                    p.type_product = tp;
                    db.Entry(p).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    var pro = listProduct.Where(X => X.ID_PRODUCT == p.ID_PRODUCT).First();
                    listProduct.Remove(pro);
                    listProduct.Insert(listProduct.Count, p);
                    pro = p;
                    productModel = new product();
                    return await Task.FromResult(true);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
                throw;
            }
        }


        public ObservableCollection<product> FindProduct()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                    return new ObservableCollection<product>(db.products.Include("type_product").ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
