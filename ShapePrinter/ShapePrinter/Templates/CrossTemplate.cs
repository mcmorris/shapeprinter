using ShapePrinterApp.Properties;
using System.Text;

namespace ShapePrinterApp.Templates
{
    public class CrossTemplate : ShapeTemplate, IShapeTemplate
    {
        public CrossTemplate(char patternChar, Rectangle boundaries)
            : base(patternChar, boundaries)
        {

        }

        public override string Print(int height)
        {
            var printBuilder = new StringBuilder(height);

            for (int i = 0; i < height; i++)
            {
                if (DoesShapeFit(Boundaries.Y + i) == true)
                {
                    PrintLine(printBuilder, i);
                }
                else
                {
                    printBuilder.AppendLine(Resources.ShapeTruncatedMessage);
                    break;
                }
            }

            return printBuilder.ToString();
        }

        public override void PrintLine(StringBuilder printBuilder, int lineNumber)
        {
            
        }
    }
}
