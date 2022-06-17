using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI_Sample.CustomControls
{
    public sealed class CircleBackground : Control
    {
        public Brush Color1
        {
            get { return (Brush)GetValue(Color1Property); }
            set { SetValue(Color1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Color1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Color1Property =
            DependencyProperty.Register("Color1", typeof(Brush), typeof(CircleBackground), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));


        public Brush Color2
        {
            get { return (Brush)GetValue(Color2Property); }
            set { SetValue(Color2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Color2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Color2Property =
            DependencyProperty.Register("Color2", typeof(Brush), typeof(CircleBackground), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 0, 0))));


        public CircleBackground()
        {
            this.DefaultStyleKey = typeof(CircleBackground);

        }
    }
}
