using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace WinUI_Sample.View
{
    public class ViewManager : NewObservableObject
    {
        private object _frameOneContent;

        public object FrameOneContent
        {
            get { return _frameOneContent; }
            set { _frameOneContent = value; OnPropertyChanged(); }
        }

        private object _frameTwoContent;

        public object FrameTwoContent
        {
            get { return _frameTwoContent; }
            set { _frameTwoContent = value; OnPropertyChanged(); }
        }

        private double _frameOneOpacity = 0;

        public double FrameOneOpacity
        {
            get { return _frameOneOpacity; }
            set { _frameOneOpacity = value; OnPropertyChanged(); }
        }

        private double _frameTwoOpacity = 0;

        public double FrameTwoOpacity
        {
            get { return _frameTwoOpacity; }
            set { _frameTwoOpacity = value; OnPropertyChanged(); }
        }

        private int _frameOneZindex = 1;

        public int FrameOneZindex
        {
            get { return _frameOneZindex; }
            set { _frameOneZindex = value; OnPropertyChanged(); }
        }

        private int _frameTwoZindex = 0;

        public int FrameTwoZindex
        {
            get { return _frameTwoZindex; }
            set { _frameTwoZindex = value; OnPropertyChanged(); }
        }


        public uint LastFrameFilled { get; set; } = 0;

        public void Navegate(object target, bool keepBackVisible = false)
        {

            if(LastFrameFilled == 0)
            {
                LastFrameFilled = 1;
                FrameOneContent = target;
                FrameOneOpacity = 1;
            }
            else if(LastFrameFilled == 1)
            {
                LastFrameFilled = 2;
                FrameTwoContent = target;
                FrameTwoZindex = 2;
                FrameOneZindex = 1;
                FrameTwoOpacity = 1;
                FrameOneOpacity = keepBackVisible ? 1 : 0;
                
            }
            else if(LastFrameFilled == 2)
            {
                LastFrameFilled = 1;
                FrameOneContent = target;
                FrameOneOpacity = 1;
                FrameOneZindex = 2;
                FrameTwoZindex = 1;
                FrameTwoOpacity = keepBackVisible ? 1 : 0;

            }
        }

        public void GoBack()
        {
            if (LastFrameFilled == 1)
            {
                LastFrameFilled = 2;
                FrameTwoZindex = 2;
                FrameOneZindex = 1;
                FrameTwoOpacity = 1;
                FrameOneOpacity = 0;
            }
            else if (LastFrameFilled == 2)
            {
                LastFrameFilled = 1;
                FrameOneZindex = 2;
                FrameTwoZindex = 1;
                FrameOneOpacity = 1;
                FrameTwoOpacity = 0;
                
            }
        }
    }
}
