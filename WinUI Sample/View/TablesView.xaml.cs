using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Sample.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TablesView : Page
    {
        public ViewModel.TableViewModel ViewModelInstance { get; set; }

        private string _sourceName = string.Empty;
        private Model.ItemModel _itemModel;

        public TablesView()
        {
            this.InitializeComponent();
            ViewModelInstance = App.GetService<ViewModel.TableViewModel>();
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            ListView lv = sender as ListView;
            ViewModelInstance.ChangeItemList(_itemModel, _sourceName, lv.Name);
            (lv.Resources["an_Off"] as Storyboard).Begin();

        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
            ListView lv = sender as ListView;
            (lv.Resources["an_On"] as Storyboard).Begin();
        }

        private void ListView_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            _sourceName = (sender as ListView).Name;
            foreach(var a in e.Items)
            {
                _itemModel = (Model.ItemModel)a;
            }
            (DeleteBorder.Resources["pop_up"] as Storyboard).Begin();
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void ToDoList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModelInstance.EditItem((sender as ListView).Name, e.ClickedItem as Model.ItemModel);
        }

        private void ListView_DragLeave(object sender, DragEventArgs e)
        {
            ListView lv = sender as ListView;
            (lv.Resources["an_Off"] as Storyboard).Begin();
        }

        private void ListView_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            (DeleteBorder.Resources["pop_down"] as Storyboard).Begin();
        }

        private async void Grid_Drop(object sender, DragEventArgs e)
        {
            await ViewModelInstance.Remove(_sourceName, _itemModel);
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }
    }
}
