using ShapePrinterApp.Properties;
using System.Text;

namespace ShapePrinterApp.Templates
{
    public class CrossTemplate : ShapeTemplate, IShapeTemplate
    {
        public CrossTemplate(char patternCharacter, Rectangle boundaries)
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

        public override void PrintLine(StringBuilder printBuilder, int lineNumber, int height=0)
        {
            for (int j = 0; j < height; j++)
            {
                if (lineNumber == j || j == (height - lineNumber - 1))
                {
                    printBuilder.Append("*");
                }
                else
                {
                    printBuilder.Append(" ");
                }
            }

            printBuilder.Append("\n");
        }
    }
}
