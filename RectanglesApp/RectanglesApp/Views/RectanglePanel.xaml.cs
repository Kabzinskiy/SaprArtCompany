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
    /// Логика взаимодействия для RectanglePanel.xaml
    /// </summary>
    public partial class RectanglePanel : UserControl
    {
        private const double rectanglePanelWidth = 745;
        private const double rectanglePanelHeight = 430;

        public RectanglePanel()
        {
            InitializeComponent();
            var mainRectangleViewModel = new MainRectangleViewModel();
            var rectanglePanelViewModel = new RectanglePanelViewModel(mainRectangleViewModel, rectanglePanelWidth, rectanglePanelHeight);
            DataContext = rectanglePanelViewModel;
            MainRectangle.DataContext = mainRectangleViewModel;
            this.Width = rectanglePanelWidth;
            this.Height = rectanglePanelHeight;
        }

        internal RectanglePanelViewModel GetViewModel() => DataContext as RectanglePanelViewModel;

        public void testMethod() 
        {
            var temp = this.Width;
            temp = this.Height;
        }
    }
}
