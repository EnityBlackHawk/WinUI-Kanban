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


        public async Task Load()
        {
            var connect = App.GetService<Model.DataBaseService>();
            var lc = await connect.GetAsync<Model.ConfigurationModel>();

            if (lc.Count == 0)
            {
                CreateDefaultConfig();
                return;
            }
            _configModel = lc.ElementAt(0);
            
        }

        public async Task Save()
        {
            var connect = App.GetService<Model.DataBaseService>();
            await connect.Update(_configModel);
        }

        private async Task CreateDefaultConfig()
        {
            _configModel = new ConfigurationModel { BackgroundType = "Mica" };
            var connect = App.GetService<Model.DataBaseService>();
            await connect.Add(_configModel);
        }

        public void Repair()
        {
            var connect = App.GetService<Model.DataBaseService>();
            connect.RemoveAll<Model.ConfigurationModel>();
        }

        public void SetBackgroundType(string type) => _configModel.BackgroundType = type;
        public string GetBackgroundType() => _configModel.BackgroundType;
        public void SetBackgroundImagePath(string path) => _configModel.BackgroundImagePath = path;
        public string GetBackgroundImagePath() => _configModel.BackgroundImagePath;

        public BitmapImage GetBitmapImage() => _configModel.BitmapImage;
        
    }
}
