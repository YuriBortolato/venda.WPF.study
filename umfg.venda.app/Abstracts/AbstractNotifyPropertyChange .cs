using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace umfg.venda.app.Abstracts
{
    internal abstract class AbstractNotifyPropertyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetField<T>(ref T field, T value,
            [CallerMemberName] string nameProperty = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaizePropertyChange(nameProperty);
            }
        }

        private void RaizePropertyChange(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }
    }
}
