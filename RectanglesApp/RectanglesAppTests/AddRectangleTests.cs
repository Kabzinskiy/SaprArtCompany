using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectanglesApp.ViewModels;
using System.Linq;
using System.Windows.Media;

namespace RectanglesAppTests
{
    [TestClass]
    public class AddRectangleTests
    {
        [TestMethod]
        public void AddCorrectRectangleDataTest()
        {
            double panelSize = 300;
            int expectedSubrectanglesCount = 1;
            MainRectangleViewModel mainRectangleViewModel = new MainRectangleViewModel();
            RectanglePanelViewModel rectanglePanelViewModel = new RectanglePanelViewModel(mainRectangleViewModel, panelSize, panelSize);
            double top = 0;
            double left = 0;
            double right = 50;
            double bottom = 50;
            var backgroundColor = Colors.AliceBlue;
            var borderColor = Colors.Black;

            rectanglePanelViewModel.AddRectangle(top, left, right, bottom, backgroundColor, borderColor);

            Assert.AreEqual(rectanglePanelViewModel.SubRectangles.Count, expectedSubrectanglesCount);
            var rectangle = rectanglePanelViewModel.SubRectangles.First();
            Assert.AreEqual(rectangle.Left, left);
            Assert.AreEqual(rectangle.Right, right);
            Assert.AreEqual(rectangle.Top, top);
            Assert.AreEqual(rectangle.Bottom, bottom);
            Assert.AreEqual(rectangle.BackgroundColor, backgroundColor);
            Assert.AreEqual(rectangle.BorderColor, borderColor);
        }

        [TestMethod]
        public void AddRectangleLargerThanPanelTest()
        {
            double panelSize = 300;
            int expectedSubrectanglesCount = 0;
            MainRectangleViewModel mainRectangleViewModel = new MainRectangleViewModel();
            RectanglePanelViewModel rectanglePanelViewModel = new RectanglePanelViewModel(mainRectangleViewModel, panelSize, panelSize);
            double top = 0;
            double left = 0;
            double right = 500;
            double bottom = 500;
            var backgroundColor = Colors.AliceBlue;
            var borderColor = Colors.Black;

            rectanglePanelViewModel.AddRectangle(top, left, right, bottom, backgroundColor, borderColor);

            Assert.AreEqual(rectanglePanelViewModel.SubRectangles.Count, expectedSubrectanglesCount);
        }

        [TestMethod]
        public void AddRectangleWithTooSmallSidesTest()
        {
            double panelSize = 300;
            int expectedSubrectanglesCount = 0;
            MainRectangleViewModel mainRectangleViewModel = new MainRectangleViewModel();
            RectanglePanelViewModel rectanglePanelViewModel = new RectanglePanelViewModel(mainRectangleViewModel, panelSize, panelSize);
            double top = 0;
            double left = 0;
            double right = 1;
            double bottom = 1;
            var backgroundColor = Colors.AliceBlue;
            var borderColor = Colors.Black;

            rectanglePanelViewModel.AddRectangle(top, left, right, bottom, backgroundColor, borderColor);

            Assert.AreEqual(rectanglePanelViewModel.SubRectangles.Count, expectedSubrectanglesCount);
        }
    }
}
