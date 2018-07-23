using System.IO;

namespace ShapePrinterApp.InputHandling
{
    public interface IInputHandler
    {
        bool IsInputValid(string inputText);
        int? LoopUntilValidInput(StreamWriter outputWriter, StreamReader inputReader);
    }
}
