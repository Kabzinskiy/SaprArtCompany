using System.Collections.Generic;
using System.Windows.Media;

namespace RectanglesApp.Common
{
    public class DataRectangle2D
    {
        public DataRectangle2D(DataPoint2D leftTopPoint, 
                               DataPoint2D rightTopPoint, 
                               DataPoint2D leftBottomPoint, 
                               DataPoint2D rightBottomPoint,
                               Color backgroundColor,
                               Color borderColor
                               ) 
        {
            LeftTopPoint = leftTopPoint;
            RightTopPoint = rightTopPoint;
            LeftBottomPoint = leftBottomPoint;
            RightBottomPoint = rightBottomPoint;
            BackgroundColor = backgroundColor;
            BorderColor = borderColor;
        }

        public DataPoint2D LeftTopPoint { get; }

        public DataPoint2D RightTopPoint { get; }

        public DataPoint2D LeftBottomPoint { get; }

        public DataPoint2D RightBottomPoint { get; }

        public Color BackgroundColor { get; }

        public Color BorderColor { get; }

        public double Left => LeftTopPoint.X;

        public double Top => LeftTopPoint.Y;

        public double Right => RightBottomPoint.X;

        public double Bottom => RightBottomPoint.Y;

        public double Width => RightTopPoint.X - LeftTopPoint.X;

        public double Height => LeftBottomPoint.Y - LeftTopPoint.Y;

        public List<DataPoint2D> GetPointList 
            => new List<DataPoint2D> { LeftTopPoint, RightTopPoint , LeftBottomPoint, RightBottomPoint};

        public override string ToString()
        {
            return $"\nLeftTopPoint = {LeftTopPoint}\nRightTopPoint = {RightTopPoint}\nLeftBottomPoint = {LeftBottomPoint}\nRightBottomPoint = {RightBottomPoint}";
        }
    }
}
