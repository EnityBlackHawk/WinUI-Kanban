using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace WinUI_Sample.ViewModel
{
    public class HomeViewModel : NewObservableObject
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public ButtonCommand ButtonCommand { get; set; }

        public HomeViewModel()
        {
            Message = "Hello from singelton";
            ButtonCommand = new ButtonCommand(GoBack);
        }

        public void GoBack()
        {
            var mvm = App.GetService<MainViewModel>();
            //mvm.ViewManager.Navegate(App.GetService<View.LoginView>());
            mvm.ViewManager.GoBack();
        }
    }
}
