using RectanglesApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace RectanglesApp.ViewModels
{
    public class RectanglePanelViewModel : BaseViewModel
    {

        private readonly double rectanglePanelWidth;

        private readonly double rectanglePanelHeight;

        private List<DataRectangle2D> subRectangles;

        private MainRectangleViewModel mainRectangle;


        public RectanglePanelViewModel(MainRectangleViewModel mainRectangleViewModel, double rectanglePanelWidth, double rectanglePanelHeight) 
        {
            this.rectanglePanelWidth = rectanglePanelWidth;
            this.rectanglePanelHeight = rectanglePanelHeight;
            mainRectangle = mainRectangleViewModel;
            this.InitializeMainRectangleByDefault();
        }

        /// <summary>
        /// Responsible for outputting logs
        /// </summary>
        public LogInfoViewModel LogInfo { get; set; }

        public List<DataRectangle2D> SubRectangles 
        { 
            get => subRectangles; 
            set => this.SetProperty(ref subRectangles, value);
        }

        /// <summary>
        /// Adds a rectangle to SubRectangles
        /// </summary>
        public void AddRectangle(double top, 
                                 double left, 
                                 double right, 
                                 double bottom, 
                                 Color backgroundColor, 
                                 Color borderColor) 
        {
            var newSubRectangles = new List<DataRectangle2D>();
            if(subRectangles != null)
            {
                newSubRectangles.AddRange(subRectangles);
            }
            else
            {
                subRectangles = new List<DataRectangle2D>();
            }

            var newSubRectangle = this.CreateRectangleData(top, left, right, bottom, backgroundColor, borderColor);
            if(CheckPanelBorders(newSubRectangle) && AreRectangleSidesCorrect(newSubRectangle))
            {
                newSubRectangles.Add(newSubRectangle);
                SubRectangles = newSubRectangles;
                LogInfo?.ShowLog($"{LogInfoMessages.CreatedRectangleMsg}{newSubRectangle}");
                return;
            }

            LogInfo?.ShowLog(LogInfoMessages.ErrorWhenCreateRectangleMsg);
        }

        /// <summary>
        /// Checks if the sides of a rectangle are too small
        /// </summary>
        private bool AreRectangleSidesCorrect(DataRectangle2D dataRectangle) 
            => dataRectangle.Width >= 5 && dataRectangle.Height >= 5;

        /// <summary>
        /// Creates data for a rectangle
        /// </summary>
        private DataRectangle2D CreateRectangleData(double top, double left, double right, double bottom, Color backgroundColor, Color borderColor)
        {
            var leftTopPoint = new DataPoint2D(left, top);
            var rightTopPoint = new DataPoint2D(right, top);
            var leftBottomPoint = new DataPoint2D(left, bottom);
            var rightBottomPoint = new DataPoint2D(right, bottom);
            this.SetIsExcludedToPoint(leftTopPoint);
            this.SetIsExcludedToPoint(rightTopPoint);
            this.SetIsExcludedToPoint(leftBottomPoint);
            this.SetIsExcludedToPoint(rightBottomPoint);
            return new DataRectangle2D(leftTopPoint, rightTopPoint, leftBottomPoint, rightBottomPoint, backgroundColor, borderColor);
        }

        /// <summary>
        /// Checks the coordinates of a point and excludes if necessary
        /// </summary>
        /// <param name="point"></param>
        private void SetIsExcludedToPoint(DataPoint2D point) 
            => point.IsExcluded = this.IsPointInsideMainRectangle(point);

        /// <summary>
        /// Checks if a point is inside a panel
        /// </summary>
        private bool CheckPanelBorders(DataRectangle2D rectangleData)
            => rectangleData.Top >= 0 &&
            rectangleData.Left >= 0 &&
            rectangleData.Right <= rectanglePanelWidth &&
            rectangleData.Bottom <= rectanglePanelHeight;

        /// <summary>
        /// Reset all rectangle data
        /// </summary>
        public void ClearRectangles() 
        {
            SubRectangles = new List<DataRectangle2D>();
            this.InitializeMainRectangleByDefault();
            LogInfo?.ShowLog(LogInfoMessages.ToolHasBeenCleanedMsg);
        }

        /// <summary>
        /// Reset Main Rectangle
        /// </summary>
        public void InitializeMainRectangleByDefault() 
        {
            mainRectangle.Left = 0;
            mainRectangle.Top = 0;
            mainRectangle.Width = rectanglePanelWidth;
            mainRectangle.Height = rectanglePanelHeight;
        }

        /// <summary>
        /// Updates the main rectangle based by the allowed points
        /// </summary>
        public void RefreshMainRectangle(List<Color> excludedColors, int margin)
        {
            if(SubRectangles == null)
            {
                LogInfo?.ShowLog(LogInfoMessages.CantDoMsg);
                return;
            }

            double top = rectanglePanelHeight;
            double left = rectanglePanelWidth;
            double right = 0;
            double bottom = 0;
            var allowedPoints = this.GetAllowedPoints(excludedColors);
            foreach(var dataPoint in allowedPoints)
            {
                bottom = Math.Max(bottom, dataPoint.Y);
                top = Math.Min(top, dataPoint.Y);
                right = Math.Max(right, dataPoint.X);
                left = Math.Min(left, dataPoint.X);
            }

            mainRectangle.Left = left;
            mainRectangle.Top = top;
            mainRectangle.Right = right;
            mainRectangle.Bottom = bottom;
            this.SetMarginToMainRectangle(margin);
        }

        /// <summary>
        /// Set the margin from the allowed points
        /// </summary>
        private void SetMarginToMainRectangle(int margin) 
        {
            if(margin > 0)
            {
                mainRectangle.Left = mainRectangle.Left - margin < 0 ? 0 : mainRectangle.Left - margin;
                mainRectangle.Right = mainRectangle.Right + 2 * margin > rectanglePanelWidth ? rectanglePanelWidth : mainRectangle.Right + 2 * margin;
                mainRectangle.Top = mainRectangle.Top - margin < 0 ? 0 : mainRectangle.Top - margin;
                mainRectangle.Bottom = mainRectangle.Bottom + 2 * margin > rectanglePanelHeight ? rectanglePanelHeight : mainRectangle.Bottom + 2 * margin;
            }
        }

        /// <summary>
        /// Checks if all non-excluded points are in the main rectangle
        /// </summary>
        public void CheckMainRectangle(List<Color> excludedColors, int margin) 
        {
            if(SubRectangles == null)
            {
                LogInfo?.ShowLog(LogInfoMessages.CantDoMsg);
                return;
            }

            var allowedPoints = this.GetAllowedPoints(excludedColors);
            if(this.ArePointsInsideMainRectangle(allowedPoints))
            {
                LogInfo?.ShowLog(LogInfoMessages.PointsCorrectMsg);
            }
            else
            {
                LogInfo?.ShowLog(LogInfoMessages.PointsOutsideMsg);
            }
        }

        /// <summary>
        /// Determines whether the points are inside the main rectangle.
        /// </summary>
        private bool ArePointsInsideMainRectangle(List<DataPoint2D> points) 
        {
            foreach(var point in points)
            {
                if(this.IsPointInsideMainRectangle(point))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether a point is inside the main rectangle.
        /// </summary>
        private bool IsPointInsideMainRectangle(DataPoint2D point) 
        {
            return point.X < mainRectangle.Left ||
                   point.X > mainRectangle.Right ||
                   point.Y < mainRectangle.Top ||
                   point.Y > mainRectangle.Bottom;
        }

        /// <summary>
        /// Returns only points that are not excluded
        /// </summary>
        /// <param name="excludedColors">Colors we excluded</param>
        private List<DataPoint2D> GetAllowedPoints(List<Color> excludedColors)
        {
            var allowedRectangles = SubRectangles.Where(x => !excludedColors.Contains(x.BackgroundColor));
            return allowedRectangles.SelectMany(x => x.GetPointList).Where(x => !x.IsExcluded).ToList();
        }
    }
}
