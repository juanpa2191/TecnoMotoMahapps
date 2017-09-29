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
    }
}
