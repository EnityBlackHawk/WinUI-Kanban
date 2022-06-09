using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;
using SQLite;

namespace WinUI_Sample.Model
{
    public class ConfigurationModel
    {
        [PrimaryKey]
        public int id { get; set; }
        public string BackgroundType { get; set; }
        public string BackgroundImagePath { get; set; }

        [Ignore]
        public BitmapImage BitmapImage
        {
            get
            {
                return new BitmapImage(new Uri(BackgroundImagePath));
            }
        }
    }
}
