using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace WinUI_Sample.ViewModel
{
    public class ConfigurationViewModel : NewObservableObject
    {
        public List<string> Backgrounds { get; set; }

        public ButtonCommand SaveCommand { get; set; }

        private string _selectedBackground;

        public string SelectedBackground
        {
            get { return _selectedBackground; }
            set { _selectedBackground = value; OnPropertyChanged(); }
        }

        private Model.ConfigurationManager _configurationManager;

        public ConfigurationViewModel()
        {
            Backgrounds = new List<string> { "Mica", "Static image" };
            _configurationManager = App.GetService<Model.ConfigurationManager>();
            SelectedBackground = _configurationManager.GetBackgroundType();
            SaveCommand = new ButtonCommand(save);
        }

        private void save()
        {
            _configurationManager.SetBackgroundType(_selectedBackground);
            _configurationManager.Save();
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.TablesView>());
        }
    }
}
