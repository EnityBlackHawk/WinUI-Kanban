using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace WinUI_Sample.ViewModel
{
    public class LoginViewModel : NewObservableObject
    {
        public ButtonCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new ButtonCommand(Login);
        }

        private void Login()
        {
            var mvm = App.GetService<ViewModel.MainViewModel>();
            mvm.ViewManager.Navegate(App.GetService<View.HomeView>());
        }
    }
}
