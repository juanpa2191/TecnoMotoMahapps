using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
using TecnoMoto.Common;
using TecnoMoto.Models;
using TecnoMoto.ViewModels;

namespace TecnoMoto.Views
{
    /// <summary>
    /// Lógica de interacción para BuyView.xaml
    /// </summary>
    public partial class BuyView : MetroWindow
    {

        #region MyRegion
        public BuyViewModel MyContext { get; set; }
        #endregion

        public BuyView()
        {
            InitializeComponent();
            MyContext = new BuyViewModel();
            this.DataContext = MyContext;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            flyProd.IsOpen = true;
        }

        private void btnNewBuy_Click(object sender, RoutedEventArgs e)
        {
            Views.DetailBuyView _detailBuy = new DetailBuyView(0);
            this.Close();
            _detailBuy.ShowDialog();
        }

        private void btnGoDetailBuy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                {
                    object ID = ((Button)sender).CommandParameter;
                    if (ID != null)
                    {
                        Views.DetailBuyView _detailBuy = new DetailBuyView(long.Parse(ID.ToString()));
                        this.Close();
                        _detailBuy.ShowDialog();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
