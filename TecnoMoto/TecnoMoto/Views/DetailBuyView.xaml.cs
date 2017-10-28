using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TecnoMoto.Models;
using TecnoMoto.ViewModels;

namespace TecnoMoto.Views
{
    /// <summary>
    /// Lógica de interacción para DetailBuyView.xaml
    /// </summary>
    public partial class DetailBuyView : MetroWindow
    {
        #region Properties
        public DetailBuyViewModel MyContext { get; set; }
        #endregion

        public DetailBuyView(long? idBuy)
        {
            InitializeComponent();
            MyContext = new DetailBuyViewModel(idBuy);
            this.DataContext = MyContext;
        }

        private void splitBtnProv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var us = splitBtnProv.SelectedItem as users;
                if (us.ID_TYPE_USER != 0)
                    MyContext.userModel = us;
                else
                    MyContext.userModel = new users();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
