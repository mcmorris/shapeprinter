using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapePrinterApp;
using ShapePrinterApp.InputHandling;
using ShapePrinterApp.Templates;

namespace PrinterUserTests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void TestTreePattern()
        {
            using (var inputReader = new StreamReader(Console.OpenStandardInput()))
            {
                using (var consoleWriter = new StreamWriter(Console.OpenStandardOutput()))
                {
                    consoleWriter.AutoFlush = true;
                    Console.SetOut(consoleWriter);
                    Console.SetIn(inputReader);

                    IInputHandler inputHandler = new InputHandler();

                    string inputTest = null;
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), false);

                    var boundaries = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
                    var shapeTemplate = new TreeTemplate('*', boundaries);

                    // Point is to test algorithm, so avoid using another algorithm to test with.
                    var shape = shapeTemplate.Print(1);
                    String checkString = "                              *\n";

                    Assert.AreEqual(shape, checkString);

                    shape = shapeTemplate.Print(2);
                    checkString  = "                              *\n";
                    checkString += "                             ***\n";

                    Assert.AreEqual(shape, checkString);

                    shape = shapeTemplate.Print(5);
                    checkString  = "                              *\n";
                    checkString += "                             ***\n";
                    checkString += "                            *****\n";
                    checkString += "                           *******\n";
                    checkString += "                          *********\n";
                    Assert.AreEqual(shape, checkString);

                    shape = shapeTemplate.Print(10);
                    checkString  = "                              *\n";
                    checkString += "                             ***\n";
                    checkString += "                            *****\n";
                    checkString += "                           *******\n";
                    checkString += "                          *********\n";
                    checkString += "                         ***********\n";
                    checkString += "                        *************\n";
                    checkString += "                       ***************\n";
                    checkString += "                      *****************\n";
                    checkString += "                     *******************\n";
                    Assert.AreEqual(shape, checkString);

                    // Check the truncation message is displayed.
                    shape = shapeTemplate.Print(100000);
                    Assert.AreNotEqual(shape.IndexOf("The rest of this shape is too large to display properly."), 0);
                }
            }
        }
    }
}
