using System;
using System.Globalization;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapePrinterApp.InputHandling;

namespace PrinterUserTests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void TestInputCheck()
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

                    inputTest = "a";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), false);

                    inputTest = "1.0001";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), false);

                    inputTest = "Johnny picked a pack of pickled peppers";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), false);

                    inputTest = "0";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), false);
                                        
                    inputTest = int.MinValue.ToString(CultureInfo.InvariantCulture);
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), false);

                    inputTest = int.MaxValue.ToString(CultureInfo.InvariantCulture);
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), true);

                    inputTest = "1";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), true);

                    inputTest = "50";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), true);

                    inputTest = "100";
                    Assert.AreEqual(inputHandler.IsInputValid(inputTest), true);
                }
            }
        }

    }
}
