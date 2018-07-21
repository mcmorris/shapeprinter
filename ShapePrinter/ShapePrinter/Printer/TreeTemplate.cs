using ShapePrinter.Templates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ShapePrinter.Printer
{
    public class TreeTemplate : ShapeTemplate, IShapeTemplate
    {
        public TreeTemplate(int height)
            : base(height)
        {
            
        }

        public override int GetWidth(int height) {
            return height + (height - 1);
        }

        public override string Print()
        {
            var printBuilder = new StringBuilder(Boundaries.Height);

            for (int i = 0; i < Boundaries.Height; i++)
            {
                for (int j = 0; j < Boundaries.Height - i; j++) {
                    printBuilder.Append(" ");
                }

                for (int k = 0; k <= i; k++) {
                    printBuilder.Append("*");
                }

                printBuilder.Append("\n");
            }

            return printBuilder.ToString();
        }
    }
}
