using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using WinUI_Sample.Model;

namespace WinUI_Sample.ViewModel
{
    public class ItemDetailViewModel : NewObservableObject
    {
        public ItemModel ItemModel { get; set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public ItemDetailViewModel(ItemModel itemModel)
        {
            ItemModel = itemModel;
        }
    }
}
