using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using umfg.venda.app.Abstracts;
using umfg.venda.app.Interfaces;

namespace umfg.venda.app.ViewModels
{
    internal sealed class MainWindowViewModel : AbstractViewModel, IObserver
    {
        private UserControl _userControl;

        public UserControl UserControl
        {
            get => _userControl;
            set => SetField(ref _userControl, value);
        }

        public MainWindowViewModel() : base("UMFG - Tela Pricipal")
        {
        }

        public void Update(ISubject subject)
        {
            throw new NotImplementedException();
        }
    }
}
