using MaterialDesignThemes.Wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using umfg.venda.app.UserControls;
using umfg.venda.app.ViewModels;

namespace umfg.venda.app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MainWindowViewModel();
            viewModel.UserControl = new ucListarProdutos();

            DataContext = viewModel;
        }
    }
}