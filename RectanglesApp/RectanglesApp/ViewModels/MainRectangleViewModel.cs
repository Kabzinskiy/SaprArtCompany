using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RectanglesApp.ViewModels
{
    public class MainRectangleViewModel : BaseViewModel
    {
        private double top;

        private double left;

        private double width;

        private double height;


        public MainRectangleViewModel() 
        {
        }


        public double Top
        {
            get => this.top;
            set => SetProperty(ref this.top, value);
        }

        public double Left
        {
            get => this.left;
            set => SetProperty(ref this.left, value);
        }

        public double Width
        {
            get => this.width;
            set => SetProperty(ref this.width, value);
        }

        public double Height
        {
            get => this.height;
            set => SetProperty(ref this.height, value);
        }

        public double Right 
        {
            get => Left + Width;
            set 
            {
                Width = value - left;       
            }
        }

        public double Bottom 
        {
            get => Top + Height;
            set 
            {
                Height = value - top;
            }
        }
    }
}
