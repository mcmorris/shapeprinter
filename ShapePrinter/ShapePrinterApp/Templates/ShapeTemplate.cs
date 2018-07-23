using System;
using System.Text;

namespace ShapePrinterApp.Templates
{
    public class ShapeTemplate : IShapeTemplate
    {
        public Rectangle Boundaries { get; set; }
        public char Pattern { get; set; }

        public ShapeTemplate(char patternCharacter, Rectangle boundaries)
        {
            this.Pattern = patternCharacter;
            this.Boundaries = boundaries;
        }

        public virtual string Print(int height)
        {
            throw new NotSupportedException("ShapeTemplate (base) does not have a native PrintLine definition.");
        }

        public virtual void PrintLine(StringBuilder printBuilder, int lineNumber, int height = 0)
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
