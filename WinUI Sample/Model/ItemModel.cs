using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tools;

namespace WinUI_Sample.Model
{
    public class ItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public ushort Table { get; set; }

        [Ignore]
        public Windows.UI.Color Color
        {
            get
            {
                return Windows.UI.Color.FromArgb(255, Red, Green, Blue);
            }
        }

        [Ignore]
        public Windows.UI.Color TextColor
        {
            get => GetTextColor();
        }

        private Windows.UI.Color GetTextColor() => Color.IsABrightColor() ? Windows.UI.Color.FromArgb(255, 0, 0, 0) : Windows.UI.Color.FromArgb(255, 255, 255, 255);

    }
}
