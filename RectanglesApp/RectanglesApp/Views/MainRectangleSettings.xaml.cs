using RectanglesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RectanglesApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainRectangleSettings.xaml
    /// </summary>
    public partial class MainRectangleSettings : UserControl
    {
        public MainRectangleSettings()
        {
            InitializeComponent();
            DataContext = new MainRectangleSettingsViewModel();
        }

        internal MainRectangleSettingsViewModel GetViewModel() => DataContext as MainRectangleSettingsViewModel;
    }
}
