using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShapePrinter.Templates
{
    public interface IShapeTemplate
    {
        Rectangle Boundaries { get; }

        string Print();
        int GetWidth(int height);
    }
}
