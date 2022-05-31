using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class NewObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private Action? _action;

        public void OnPropertyChanged([CallerMemberName] string propertyname = null, Action action = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            action?.Invoke();
        }
    }
}
