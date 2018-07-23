using ShapePrinterApp.InputHandling;
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
                    using (var consoleWriter = new StreamWriter(Console.OpenStandardOutput()))
                    {
                        consoleWriter.AutoFlush = true;
                        Console.SetOut(consoleWriter);
                        Console.SetIn(inputReader);

                        while (exitTriggered == false)
                        {
                            IInputHandler inputHandler = new InputHandler();
                            int? height = inputHandler.LoopUntilValidInput(consoleWriter, inputReader);
                            if (height.HasValue == false) {
                                exitTriggered = true;
                                continue;
                            }

                            PrintShape(consoleWriter, height.Value);
                        }

                    }
                }

            }
            catch (IOException ex)
            {
                ExceptionHandler.HandleException(ex, Resources.IOExceptionMessage);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, Resources.UnhandledExceptionMessage);
            }
        }
        
        public static void PrintShape(TextWriter consoleWriter, int height)
        {
            // Handle boundaries as close to print as possible to detect changes in console size.
            var boundaries = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
            var shapeTemplate = new TreeTemplate('*', boundaries);
            consoleWriter.Write(shapeTemplate.Print(height));
        }
    }
}
