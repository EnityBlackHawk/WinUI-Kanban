using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WinUI_Sample.Model;

namespace WinUI_Sample.ViewModel
{
    public class TableViewModel : Tools.NewObservableObject
    {
        private DataBaseService _dataBase;
        public Tools.AsyncCommand SaveCommand { get; set; }
        public Tools.ButtonCommand NewCommand { get; set; }

        private ItemModel _selectedItem;

        public ItemModel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        private int _editingIndex = -1;

        public ObservableCollection<ItemModel> ToDoList { get; set; }
        public ObservableCollection<ItemModel> InProgressList { get; set; }
        public ObservableCollection<Model.ItemModel> DoneList { get; set; }
        public TableViewModel()
        {
            ToDoList = new();
            InProgressList = new();
            DoneList = new();

            SaveCommand = new Tools.AsyncCommand(Save);
            NewCommand = new Tools.ButtonCommand(NewItem);

            _dataBase = App.GetService<DataBaseService>();

            Load();
        }

        private async Task Load()
        {
            ICollection<ItemModel> list = await _dataBase.GetAsync<ItemModel>();
            foreach(ItemModel item in list)
            {
                if (item.Table == 0) ToDoList.Add(item);
                else if (item.Table == 1) InProgressList.Add(item);
                else if (item.Table == 2) DoneList.Add(item);
            }
        }

        public async Task ChangeItemList(ItemModel item, string sourceName, string targetName)
        {
            if (sourceName == targetName) return;

            if (sourceName == "ToDoList")
            {
                ToDoList.Remove(item);
            }
            else if(sourceName == "InProgressList")
            {
                InProgressList.Remove(item);
            }
            else if(sourceName == "DoneList")
            {
                DoneList.Remove(item);
            }    

            if(targetName == "ToDoList")
            {
                item.Table = 0;
                ToDoList.Add(item);
            }
            else if(targetName == "InProgressList")
            {
                item.Table = 1;
                InProgressList.Add(item);
            }
            else if(targetName == "DoneList")
            {
                item.Table = 2;
                DoneList.Add(item);
            }

            await _dataBase.Update(item);
            
        }

        public void NewItem()
        {
            ItemModel im = new();
            SelectedItem = im;
            im.Red = 68;
            im.Blue = 68;
            im.Green = 68;
            App.GetService<ViewModel.ItemDetailViewModel>().Load();
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.ItemDetailView>(), true);
        }

        public void EditItem(string sourceName, ItemModel itemModel)
        {
            ItemModel im = null;
            if (sourceName == "ToDoList")
            {
                for (int i = 0; i < ToDoList.Count; i++)
                {
                    if (ToDoList[i] == itemModel)
                    { 
                        im = ToDoList[i];
                        ToDoList.RemoveAt(i);
                        _editingIndex = i;
                        break;
                    }
                }
            }
            else if (sourceName == "InProgressList")
            {
                for (int i = 0; i < InProgressList.Count; i++)
                {
                    if (InProgressList[i] == itemModel)
                    {
                        im = InProgressList[i];
                        InProgressList.RemoveAt(i);
                        _editingIndex = i;
                        break;
                    }
                }
            }
            else if (sourceName == "DoneList")
            {
                for (int i = 0; i < DoneList.Count; i++)
                {
                    if (DoneList[i] == itemModel)
                    {
                        im = DoneList[i];
                        DoneList.RemoveAt(i);
                        _editingIndex = i;
                        break;
                    }
                }
            }
            SelectedItem = im;
            App.GetService<ViewModel.ItemDetailViewModel>().Load();
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.ItemDetailView>(), true);
        }

        public void GetFromDetail()
        {
            if (_editingIndex == -1)
            {
                Add();
                return;
            }
            int table = SelectedItem.Table;
            if (table == 0) ToDoList.Insert(_editingIndex, SelectedItem);
            else if (table == 1) InProgressList.Insert(_editingIndex, SelectedItem);
            else if (table == 2) DoneList.Insert(_editingIndex, SelectedItem);
            _editingIndex = -1;
        }

        public async void Add()
        {
            if (_editingIndex != -1) return;
            if (string.IsNullOrEmpty(SelectedItem.Title)) return;
            int table = SelectedItem.Table;
            if (table == 0) ToDoList.Add(SelectedItem);
            else if (table == 1) InProgressList.Add(SelectedItem);
            else if (table == 2) DoneList.Add(SelectedItem);

            await _dataBase.Add(SelectedItem);
        }

        public async Task Save()
        {
            var conection = _dataBase;
            await conection.Update(ToDoList);
            await conection.Update(InProgressList);
            await conection.Update(DoneList);
        }

        public async Task Remove(string sourceName, ItemModel item)
        {
            if (sourceName == "ToDoList")
            {
                ToDoList.Remove(item);
            }
            else if (sourceName == "InProgressList")
            {
                InProgressList.Remove(item);
            }
            else if (sourceName == "DoneList")
            {
                DoneList.Remove(item);
            }

            await _dataBase.Remove(item);
        }

    }
}
