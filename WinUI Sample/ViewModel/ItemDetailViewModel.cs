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
        private TableViewModel _tableViewModel;
        public AsyncCommand SaveCommand { get; set; }
        public ButtonCommand CancelCommand { get; set; }

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


        private Windows.UI.Color _color;

        public Windows.UI.Color Color
        {
            get => _color;
            set { _color = value; OnPropertyChanged(); }
        }


        public ItemDetailViewModel()
        {
            _tableViewModel = App.GetService<TableViewModel>();

            SaveCommand = new AsyncCommand(Save);
            CancelCommand = new ButtonCommand(() =>
            {
                _tableViewModel.GetFromDetail();
                App.GetService<View.ViewManager>().GoBack();
            });
        }

        public void Load()
        {
            var itemModel = _tableViewModel.SelectedItem;
            Title = itemModel.Title;
            Message = itemModel.Message;

            Color = Windows.UI.Color.FromArgb(255, itemModel.Red, itemModel.Green, itemModel.Blue);
        }

        private async Task Save()
        {
            _tableViewModel.SelectedItem.Title = Title;
            _tableViewModel.SelectedItem.Message = Message;
            _tableViewModel.SelectedItem.Blue = Color.B;
            _tableViewModel.SelectedItem.Red = Color.R;
            _tableViewModel.SelectedItem.Green = Color.G;

            _tableViewModel.GetFromDetail();
            App.GetService<View.ViewManager>().GoBack();
        }
    }
}
