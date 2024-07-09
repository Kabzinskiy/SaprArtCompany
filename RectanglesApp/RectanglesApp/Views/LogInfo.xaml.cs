using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using RectanglesApp.ViewModels;
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
    /// Логика взаимодействия для LogInfo.xaml
    /// </summary>
    public partial class LogInfo : UserControl
    {
        public LogInfo()
        {
            InitializeComponent();
            DataContext = new LogInfoViewModel();
        }

        internal LogInfoViewModel GetViewModel() => DataContext as LogInfoViewModel;
    }
}
