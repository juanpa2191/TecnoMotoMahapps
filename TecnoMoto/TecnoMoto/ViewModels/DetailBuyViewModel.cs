using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Common;
using TecnoMoto.Models;
using TecnoMoto.Services;

namespace TecnoMoto.ViewModels
{
    public class DetailBuyViewModel : ObservableObject
    {

        #region Properties

        public ObservableCollection<product> listProduct { get; set; }

        public ObservableCollection<users> listUserProv { get; set; }

        public ObservableCollection<detail_buy> listDetailBuy { get; set; }

        private detail_buy _detailBuy;

        public detail_buy detailBuyModel
        {
            get { return _detailBuy; }
            set
            {
                _detailBuy = value;
                OnPropertyChanged();
            }
        }

        private long _cant;

        public long cant
        {
            get { return _cant; }
            set
            {
                _cant = value;
                OnPropertyChanged();
            }
        }

        private long _Total;

        public long total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                OnPropertyChanged();
            }
        }
        private users _User;

        public users userModel
        {
            get { return _User; }
            set
            {
                _User = value;
                OnPropertyChanged();
            }
        }


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
            if (idBuy.Value != 0)
            {
                listUserProv = listProvider(idBuy.Value);
                userModel = listUserProv.First();
                buyModel = getBuy(idBuy.Value);
                listDetailBuy = listDetBuy(idBuy.Value);
                totalValue();
            }
            else
            {
                listUserProv = listProvider();
                userModel = new users();
                buyModel = new buy();
                listDetailBuy = new ObservableCollection<detail_buy>();
            }
            listProduct = listProd();
            
        }

        #region NewBuy
        public ObservableCollection<users> listProvider()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    List<users> listUser = new List<users>();

                    listUser.Add(new users()
                    {
                        ID_TYPE_USER = 0,
                        USERNAME = Constantes.SELECCIONE
                    });
                    listUser.AddRange(db.users.Where(x => x.ID_TYPE_USER == Constantes.TipoUsuario.PROVEEDOR).ToList());
                    return new ObservableCollection<users>(listUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<detail_buy> listDetBuy(long idBuy)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var detail = db.detail_buy
                        .Include("product")
                        .Where(x => x.ID_BUY == idBuy).ToList();

                    return new ObservableCollection<detail_buy>(detail);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task addProduct(long? idBuy, product p, users u, long cant)
        {
            using (Db_TecnoMotos db = new Db_TecnoMotos())
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    try
                    {
                        buyModel = db.buy.Find(idBuy.Value);

                        if (buyModel == null)
                        {
                            buyModel = new buy()
                            {
                                COMPLETE = false,
                                DATE_REGISTER = DateTime.Now,
                                ID_USER = u.ID_USER
                            };

                            db.buy.Add(buyModel);
                            await db.SaveChangesAsync();
                        }

                        var detail = new detail_buy()
                        {
                            ID_PRODUCT = p.ID_PRODUCT,
                            ID_BUY = buyModel.ID_BUY,
                            CANT = cant,
                            VALUE = p.VALUE_PRODUCT_BUY
                        };

                        listDetailBuy.Add(detail);
                        db.detail_buy.Add(detail);

                        var prod = db.products.Find(p.ID_PRODUCT);
                        prod.CANT_PRODUCT = p.CANT_PRODUCT + cant;
                        //p.CANT_PRODUCT = p.CANT_PRODUCT + cant;
                        db.Entry(prod).State = EntityState.Modified;
                        await db.SaveChangesAsync();

                        tran.Commit();
                        totalValue();
                        updateListP(p, cant);

                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }

                //return await Task.FromResult( new detail_buy());
            }

        }

        public void totalValue()
        {
            try
            {
                cant  = 0;
                total = 0;
                foreach (var item in listDetailBuy)
                {
                    cant += item.CANT.Value;
                    total += (item.CANT.Value * item.product.VALUE_PRODUCT_BUY);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void updateListP(product p, long cant)
        {
            try
            {
                var pro = listProduct.Where(X => X.ID_PRODUCT == p.ID_PRODUCT).First();
                listProduct.Remove(pro);
                pro.CANT_PRODUCT += cant;
                listProduct.Insert(listProduct.Count, p);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public buy getBuy(long idBuy)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                    return db.buy.Find(idBuy);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ObservableCollection<product> listProd()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    return new ObservableCollection<product>(db.products.Where(x => x.ACTIVE).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region DetailBuy
        public ObservableCollection<users> listProvider(long idBuy)
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                    return new ObservableCollection<users>(db.buy.Include("users").Where(x => x.ID_BUY == idBuy).Select(x => x.users).ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion




    }
}
