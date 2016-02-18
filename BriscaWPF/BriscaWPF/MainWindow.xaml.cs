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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BriscaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModelBase();

        }

        private void btnPrimeraCarta_Click(object sender, RoutedEventArgs e)
        {
            ViewModelBase vmb = (ViewModelBase)this.DataContext;
            vmb.SeleccionarCarta(0);
        }

        private void btnSegundaCarta_Click(object sender, RoutedEventArgs e)
        {
            ViewModelBase vmb = (ViewModelBase)this.DataContext;
            vmb.SeleccionarCarta(1);
        }

        private void btnTerceraCarta_Click(object sender, RoutedEventArgs e)
        {
            ViewModelBase vmb = (ViewModelBase)this.DataContext;
            vmb.SeleccionarCarta(2);
        }
    }
}
