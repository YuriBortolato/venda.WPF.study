using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace umfg.venda.app.Abstracts
{
    internal abstract class AbstractViewModel : AbstractNotifyPropertyChange
    {
        private string _titulo = string.Empty;

        public string Titulo
        {
            get => _titulo;
            set => SetField(ref _titulo, value);
        }

        protected AbstractViewModel(string titulo)
        {
            Titulo = titulo;
        }
    }
}
