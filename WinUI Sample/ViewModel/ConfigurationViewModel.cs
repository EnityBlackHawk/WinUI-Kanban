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
        public AsyncCommand SaveCommand { get; set; }
        public ButtonCommand PathCommand { get; set; }

        public ButtonCommand CancelCommand { get; set; }

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

        private bool _isAcrylic;

        public bool IsAcrylic
        {
            get { return _isAcrylic; }
            set { _isAcrylic = value; OnPropertyChanged(); }
        }

        private bool _isMicaAvalible;

        public bool IsMicaAvalible
        {
            get { return _isMicaAvalible; }
            set { _isMicaAvalible = value; OnPropertyChanged(); }
        }


        private Model.ConfigurationManager _configurationManager;

        public ConfigurationViewModel()
        {
            Backgrounds = new List<string> { "Mica", "Static image" };
            _configurationManager = App.GetService<Model.ConfigurationManager>();
            
            SaveCommand = new AsyncCommand(save);
            PathCommand = new ButtonCommand(GetPath);
            CancelCommand = new ButtonCommand(Cancel);

            Load();

            IsMicaAvalible = Mica.IsSupported();
            if (!IsMicaAvalible) Backgrounds.RemoveAt(0);
        }

        private async Task save()
        {
            await Task.Run(() =>
            {
                _configurationManager.SetBackgroundType(SelectedBackground);
                _configurationManager.SetBackgroundImagePath(Path);
                _configurationManager.SetAcrylicActivated(IsAcrylic);

            });
            await _configurationManager.Save();
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.TablesView>());

        }

        private async void GetPath()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpeg");

            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(App.GetService<MainWindow>());
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hwnd);

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            Path = file != null ? file.Path : Path;
        }

        private void Cancel()
        {
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.TablesView>());
        }

        public void Load()
        {
            SelectedBackground = _configurationManager.GetBackgroundType();
            Path = _configurationManager.GetBackgroundImagePath();
            IsAcrylic = _configurationManager.IsAcrylicActivated();
        }
    }
}
