

namespace RectanglesApp.Common
{
    public class DataPoint2D
    {
        public DataPoint2D(double x, double y) 
        {
            X = x; 
            Y = y;   
            IsExcluded = false;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public bool IsExcluded { get; set; }

        public override string ToString() => $"X = {X}; Y = {Y}; IsExcluded = {IsExcluded};";
    }
}
