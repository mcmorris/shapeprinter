using ShapePrinterApp.Properties;
using System;
using System.Globalization;
using System.IO;

namespace ShapePrinterApp.InputHandling
{
    public class InputHandler : IInputHandler
    {
        public int? LoopUntilValidInput(StreamWriter outputWriter, StreamReader inputReader)
        {
            string inputText = null;
            bool firstLine = true;

            while (IsInputValid(inputText) == false)
            {
                if (firstLine == false)
                {
                    outputWriter.WriteLine(Resources.InvalidHeightMessage);
                }

                outputWriter.Write(Resources.HeightInputPrompt);
                if (inputReader == null)
                {
                    throw new InvalidOperationException("Input reader was lost.");
                }

                inputText = inputReader.ReadLine();
                inputText = inputText.ToLower(CultureInfo.InvariantCulture);
                firstLine = false;

                if (inputText == "q") {
                    return null;
                }
            }

            return int.Parse(inputText, CultureInfo.InvariantCulture);
        }

        public bool IsInputValid(string inputText)
        {
            if (int.TryParse(inputText, out int testOut) == false)
            {
                return false;
            }

            if (int.Parse(inputText, CultureInfo.InvariantCulture) <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
