using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Tools;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Sample.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemDetailView : Page
    {
        public ViewModel.ItemDetailViewModel ViewModelInstance { get; set; }

        public ItemDetailView()
        {
            this.InitializeComponent();
            ViewModelInstance = App.GetService<ViewModel.ItemDetailViewModel>();
        }

        private void ColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            ViewModelInstance.Color = sender.Color;
            if(sender.Color.IsABrightColor())
            {
                tileBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                messageBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
            else
            {
                tileBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                messageBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            colorPicker.Color = ViewModelInstance.Color;
        }
    }
}
