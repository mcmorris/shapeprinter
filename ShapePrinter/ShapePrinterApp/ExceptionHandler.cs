using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePrinterApp
{
    public static class ExceptionHandler
    {
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
    }
}
