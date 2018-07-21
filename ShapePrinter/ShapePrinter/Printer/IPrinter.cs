using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShapePrinter.Printer
{
    public interface IPrinter
    {
        bool DoesShapeFit(int height);

        void Print(ref Stream outStream, int height);
    }
}
