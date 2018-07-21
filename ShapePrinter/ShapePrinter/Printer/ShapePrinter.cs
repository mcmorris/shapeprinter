using ShapePrinter.Templates;
using System;
using System.Drawing;
using System.IO;

namespace ShapePrinter.Printer
{
    internal class ShapePrinter : IPrinter
    {
        private IShapeTemplate _template;

        public ShapePrinter(IShapeTemplate shapeTemplate)
        {
            this._template = shapeTemplate;
        }

        public bool DoesShapeFit(int height)
        {
            if (height < Console.WindowHeight && _template.GetWidth(height) < Console.WindowWidth) {
                return true;
            }

            return false;
        }

        public void Print(ref Stream outStream, int height)
        {
            try
            {
                using (var streamWriter = new StreamWriter(outStream))
                {
                    streamWriter.Write(_template.Print());
                    if (DoesShapeFit(height) == false) {
                        Console.WriteLine("Shape is too large to display properly and has been truncated");
                    }
                }
            }
            finally
            {
                if (outStream != null) {
                    outStream.Close();
                }
            }
        }
        
    }
}
