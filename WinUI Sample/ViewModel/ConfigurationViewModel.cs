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

        private string _path;

        public string Path
        {
            get { return _path; }
            set { _path = value; OnPropertyChanged(); }
        }


        private Model.ConfigurationManager _configurationManager;

        public ConfigurationViewModel()
        {
            Backgrounds = new List<string> { "Mica", "Static image" };
            _configurationManager = App.GetService<Model.ConfigurationManager>();
            SelectedBackground = _configurationManager.GetBackgroundType();
            Path = _configurationManager.GetBackgroundImagePath();
            SaveCommand = new ButtonCommand(save);
        }

        private void save()
        {
            _configurationManager.SetBackgroundType(SelectedBackground);
            _configurationManager.SetBackgroundImagePath(Path);
            _configurationManager.Save();
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.TablesView>());
        }
    }
}
