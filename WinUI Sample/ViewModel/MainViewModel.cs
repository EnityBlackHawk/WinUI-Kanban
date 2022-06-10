using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Sample.ViewModel
{
    public class MainViewModel : Tools.NewObservableObject
    {

        public View.ViewManager ViewManager;

        public MainViewModel()
        {
            ViewManager = App.GetService<View.ViewManager>();

            ViewManager.Navegate(App.GetService<View.TablesView>());
            
        }


    }
}
