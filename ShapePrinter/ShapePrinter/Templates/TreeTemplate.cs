using ShapePrinterApp.Properties;
using System.Text;

namespace ShapePrinterApp.Templates
{
    public class TreeTemplate : ShapeTemplate, IShapeTemplate
    {
        public TreeTemplate(char patternChar, Rectangle boundaries)
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
            for (var j = Boundaries.Height - lineNumber; j > 0; j--)
            {
                printBuilder.Append(" ");
            }

            for (var k = 0; k <= 2 * lineNumber; k++)
            {
                printBuilder.Append(PatternChar);
            }

            printBuilder.Append("\n");
        }
    }
}
