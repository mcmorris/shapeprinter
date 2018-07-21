using ShapePrinter.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShapePrinter.Printer
{
    public class ShapeTemplate : IShapeTemplate
    {
        public Rectangle Boundaries { get; private set; }

        public ShapeTemplate(int height)
        {
            Boundaries = new Rectangle(
                0,
                0,
                Math.Min(GetWidth(height), Console.WindowWidth),
                Math.Min(height, Console.WindowHeight)
            );
        }

        public virtual int GetWidth(int height) {
            return height;
        }

        public virtual string Print()
        {
            throw new NotImplementedException("ShapeTemplate (base) does not have a native PrintLine definition.");
        }

    }
}
