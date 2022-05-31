using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Sample.ViewModel
{
    public class MainViewModel : Tools.NewObservableObject
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public View.ViewManager ViewManager;

        public MainViewModel()
        {
            //CurrentView = App.GetService<View.LoginView>();
            ViewManager = App.GetService<View.ViewManager>();

            ViewManager.Navegate(App.GetService<View.TablesView>());
        }


    }
}
