using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace RectanglesApp.ViewModels
{
    public class MainRectangleSettingsViewModel : BaseViewModel
    {
        private int margin;

        private bool isGreenEnabled = true;

        private bool isPinkEnabled = true;

        private bool isVioletEnabled = true;


        public MainRectangleSettingsViewModel() 
        {
            CheckCommand = new RelayCommand(obj => { CheckAction?.Invoke(); });
            RefreshCommand = new RelayCommand(obj => { RefreshAction?.Invoke(); });
        }


        public ICommand CheckCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        public Action CheckAction { get; set; }

        public Action RefreshAction { get; set; }


        public string Margin 
        { 
            get => this.margin.ToString();
            set 
            {
                if(Equals(value, string.Empty))
                {
                    SetProperty(ref this.margin, 0);
                }
                else if(int.TryParse(value, out int result) && result > 0 && result < 101)
                {
                    SetProperty(ref this.margin, result);
                }
            }
        }

        public bool IsGreenEnabled 
        {
            get => this.isGreenEnabled; 
            set => SetProperty(ref this.isGreenEnabled, value);
        }

        public bool IsPinkEnabled 
        { 
            get => this.isPinkEnabled; 
            set => SetProperty(ref this.isPinkEnabled, value); 
        }

        public bool IsVioletEnabled 
        { 
            get => this.isVioletEnabled; 
            set => SetProperty(ref this.isVioletEnabled, value); 
        }


        public List<Color> GetExcludedColors() 
        {
            var excludedColors = new List<Color>();
            if(!isGreenEnabled)
            {
                excludedColors.Add(Colors.Green);
            }

            if(!isPinkEnabled)
            {
                excludedColors.Add(Colors.Pink);
            }

            if(!isVioletEnabled)
            {
                excludedColors.Add(Colors.Violet);
            }

            return excludedColors;
        }

        public int GetMargin() => margin;
    }
}
