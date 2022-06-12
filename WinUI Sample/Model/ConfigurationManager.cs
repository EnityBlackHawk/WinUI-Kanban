using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUI_Sample.Model
{
    public class ConfigurationManager
    {
        private ConfigurationModel _configModel;
        private DataBaseService _dataBaseService;

        public async Task Load()
        {
            
            _dataBaseService = App.GetService<Model.DataBaseService>();
            var lc = await _dataBaseService.GetAsync<Model.ConfigurationModel>();

            if (lc.Count == 0)
            {
                await CreateDefaultConfig();
                return;
            }
            _configModel = lc.ElementAt(0);
            App.GetService<MainWindow>().SetBackground();

        }

        public async Task Save()
        {
            await _dataBaseService.Update(_configModel);
            App.GetService<MainWindow>().SetBackground();
        }

        public async Task CreateDefaultConfig()
        {
            _configModel = new ConfigurationModel
            {
                BackgroundType = "Static image",
                BackgroundImagePath = "https://images.wallpaperscraft.com/image/single/bridge_sea_fog_304152_1920x1080.jpg",
                IsAcrylicActivated = true,
                AcrylicStrength = 0.8,
            };
            await _dataBaseService.Add(_configModel);
            App.GetService<MainWindow>().SetBackground();
        }

        public async Task Repair()
        {
            await _dataBaseService.RemoveAll<Model.ConfigurationModel>();
        }

        public void SetBackgroundType(string type) => _configModel.BackgroundType = type;
        public string GetBackgroundType() => _configModel.BackgroundType;
        public void SetBackgroundImagePath(string path) => _configModel.BackgroundImagePath = path;
        public string GetBackgroundImagePath() => _configModel.BackgroundImagePath;

        public bool IsAcrylicActivated() => _configModel.IsAcrylicActivated;
        public void SetAcrylicActivated(bool isActivated) => _configModel.IsAcrylicActivated = isActivated;
        public BitmapImage GetBitmapImage() => _configModel.BitmapImage;
        
    }
}
