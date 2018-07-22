using ShapePrinterApp.Properties;
using ShapePrinterApp.Templates;
using System;
using System.IO;

namespace ShapePrinterApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exitTriggered = false;

            try
            {
                using (var inputReader = new StreamReader(Console.OpenStandardInput()))
                {
                    Console.SetIn(inputReader);

                    using (var consoleWriter = new StreamWriter(Console.OpenStandardOutput()))
                    {
                        consoleWriter.AutoFlush = true;
                        Console.SetOut(consoleWriter);

                        while (exitTriggered == false)
                        {
                            bool firstLine = true;
                            string inputText = null;

                            while (IsHeightValid(inputText) == false)
                            {
                                if (firstLine == false)
                                {
                                    consoleWriter.WriteLine(Resources.InvalidHeightMessage);
                                }

                                consoleWriter.Write(Resources.HeightInputPrompt);
                                inputText = inputReader.ReadLine();
                                inputText = inputText.ToLower();
                                firstLine = false;

                                if (inputText == "q")
                                {
                                    exitTriggered = true;
                                    break;
                                }
                            }

                            if (exitTriggered == true) { break; }
                            int height = int.Parse(inputText);
                            PrintShape(consoleWriter, height);
                        }

                    }
                }

            }
            catch (IOException ex)
            {
                HandleException(ex, Resources.IOExceptionMessage);
            }
            catch (Exception ex)
            {
                HandleException(ex, Resources.UnhandledExceptionMessage);
            }
        }

        public static void PrintShape(StreamWriter consoleWriter, int height)
        {
            // Handle boundaries as close to print as possible to detect changes in console size.
            var boundaries = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
            var shapeTemplate = new TreeTemplate('*', boundaries);
            consoleWriter.Write(shapeTemplate.Print(height));
        }

        public static void HandleException(Exception ex, string safeErrorMessage)
        {
            // The exception should be logged here.  I considered this out of scope for the sake of clarity.
            Console.WriteLine(safeErrorMessage);
            Log(ex);
        }

        public static void Log(Exception ex)
        {
            // SERILOG RECORD EX STUB
        }

        public static bool IsHeightValid(string inputText)
        {
            if (int.TryParse(inputText, out int testOut) == false)
            {
                return false;
            }

            if (int.Parse(inputText) <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
