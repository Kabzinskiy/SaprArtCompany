using RectanglesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Dynamic;
using System.Windows.Media;

namespace RectanglesApp.ViewModels
{
    public class RectangleCreationSettingsViewModel : BaseViewModel
    {
        private const string GreenColorName = "Green";

        private const string PinkColorName = "Pink";

        private const string VioletColorName = "Violet";

        private const string DefaultNullValue = "0";


        private string top = DefaultNullValue;

        private string bottom = DefaultNullValue;

        private string left = DefaultNullValue;

        private string right = DefaultNullValue;

        private string selectedColor = GreenColorName;


        public RectangleCreationSettingsViewModel() 
        {
            CreateCommand = new RelayCommand(obj => CreateRectangleAction?.Invoke());
            ClearCommand = new RelayCommand(obj => ClearRectanglesAction?.Invoke());
        }


        public ICommand CreateCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        public Action CreateRectangleAction { get; set; }

        public Action ClearRectanglesAction { get; set; }


        public string Top 
        { 
            get => top;
            set => SetPropertyWithDoubleCheck(ref this.top, value);
        }

        public string Bottom 
        { 
            get => bottom; 
            set => SetPropertyWithDoubleCheck(ref this.bottom, value);
        }


        public string Left 
        { 
            get => left; 
            set => SetPropertyWithDoubleCheck(ref this.left, value);
        }


        public string Right 
        { 
            get => right; 
            set => SetPropertyWithDoubleCheck(ref this.right, value);
        }

        public string SelectedColor 
        { 
            get => selectedColor; 
            set => SetProperty(ref selectedColor, value); 
        }


        public Color GetSelectedColor() 
        {
            switch(selectedColor)
            {
                case PinkColorName:
                    return Colors.Pink;
                case VioletColorName:
                    return Colors.Violet;
                default:
                    return Colors.Green;
            }
        }

        private void SetPropertyWithDoubleCheck(ref string storage, string value) 
        {
            value = value.TrimStart('0');
            if(double.TryParse(value, out double result))
            {
                SetProperty(ref storage, value);
            }
            else
            {
                SetProperty(ref storage, DefaultNullValue);
            }
        }

        public double GetTop() 
        {
            double.TryParse(Top, out double result);
            return result;
        }

        public double GetLeft()
        {
            double.TryParse(Left, out double result);
            return result;
        }

        public double GetRight()
        {
            double.TryParse(Right, out double result);
            return result;
        }

        public double GetBottom()
        {
            double.TryParse(Bottom, out double result);
            return result;
        }
    }
}
