using System;
using System.Text;

namespace ShapePrinterApp.Templates
{
    public class ShapeTemplate : IShapeTemplate
    {
        public Rectangle Boundaries { get; set; }
        public char PatternChar { get; set; }

        public ShapeTemplate(char patternChar, Rectangle boundaries)
        {
            this.PatternChar = patternChar;
            this.Boundaries = boundaries;
        }

        public virtual string Print(int height)
        {
            throw new NotSupportedException("ShapeTemplate (base) does not have a native PrintLine definition.");
        }

        public virtual void PrintLine(StringBuilder printBuilder, int lineNumber)
        {
            throw new NotSupportedException("ShapeTemplate (base) does not have a native PrintLine definition.");
        }

        public bool DoesShapeFit(int height)
        {
            if (height <= Boundaries.Height)
            {
                return true;
            }

            return false;
        }

    }
}
