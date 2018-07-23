using ShapePrinterApp.Properties;
using System.Text;

namespace ShapePrinterApp.Templates
{
    public class TreeTemplate : ShapeTemplate, IShapeTemplate
    {
        public TreeTemplate(char patternCharacter, Rectangle boundaries)
            : base(patternCharacter, boundaries)
        {

        }

        public override string Print(int height)
        {
            var printBuilder = new StringBuilder(height);

            for (int i = 0; i < height; i++)
            {
                if (DoesShapeFit(Boundaries.Y + i) == true)
                {
                    PrintLine(printBuilder, i, height);
                }
                else
                {
                    printBuilder.AppendLine(Resources.ShapeTruncatedMessage);
                    break;
                }
            }

            return printBuilder.ToString();
        }

        public override void PrintLine(StringBuilder printBuilder, int lineNumber, int height = 0)
        {
            for (int j = Boundaries.Height - lineNumber; j > 0; j--)
            {
                printBuilder.Append(" ");
            }

            for (int k = 0; k <= 2 * lineNumber; k++)
            {
                printBuilder.Append(Pattern);
            }

            printBuilder.Append("\n");
        }
    }
}
