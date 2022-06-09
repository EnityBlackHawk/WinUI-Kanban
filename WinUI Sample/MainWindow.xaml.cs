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

namespace WinUI_Sample
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public ViewModel.MainViewModel ViewModel { get; }
        public View.ViewManager ViewManager { get; }

        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = App.GetService<ViewModel.MainViewModel>();
            ViewManager = App.GetService<View.ViewManager>();
            (rootGrid.Resources["Str2"] as Storyboard).Begin();
            (rootGrid.Resources["Str1"] as Storyboard).Begin();

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(titleBar);
        }


    }
}
