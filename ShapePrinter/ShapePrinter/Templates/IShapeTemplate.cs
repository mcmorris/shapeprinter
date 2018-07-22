using System.Text;

namespace ShapePrinterApp.Templates
{
    public interface IShapeTemplate
    {
        Rectangle Boundaries { get; set; }

        string Print(int height);
        void PrintLine(StringBuilder printBuilder, int lineNumber);
    }
}
