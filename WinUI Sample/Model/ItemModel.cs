using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

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
        public SolidColorBrush Color
        {
            get
            {
                return new SolidColorBrush(Windows.UI.Color.FromArgb(255, Red, Green, Blue));
            }
        }

    }
}
