using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WinUI_Sample.Model;

namespace WinUI_Sample.ViewModel
{
    public class TableViewModel : Tools.NewObservableObject
    {
        public Tools.AsyncCommand SaveCommand { get; set; }

        public ObservableCollection<ItemModel> ToDoList { get; set; }
        public ObservableCollection<ItemModel> InProgressList { get; set; }
        public ObservableCollection<Model.ItemModel> DoneList { get; set; }
        public TableViewModel()
        {
            ToDoList = new();
            InProgressList = new();
            DoneList = new();

            SaveCommand = new Tools.AsyncCommand(Save);

            Load();
        }

        private async Task Load()
        {
            ICollection<ItemModel> list = await App.GetService<DataBaseService>().GetAsync<ItemModel>();
            foreach(ItemModel item in list)
            {
                if (item.Table == 0) ToDoList.Add(item);
                else if (item.Table == 1) InProgressList.Add(item);
                else if (item.Table == 2) DoneList.Add(item);
            }
        }

        public void ChangeItemList(ItemModel item, string sourceName, string targetName)
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
        }

        public void EditItem(string sourceName, ItemModel itemModel)
        {
            App.GetService<View.ViewManager>().Navegate(App.GetService<View.ItemDetailView>(), true);
        }

        public async Task Save()
        {
            var conection = App.GetService<Model.DataBaseService>();
            await conection.Update(ToDoList);
            await conection.Update(InProgressList);
            await conection.Update(DoneList);
        }

    }
}
