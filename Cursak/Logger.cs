
namespace Cursak
{
    namespace Cursak
    {
        using System;
        using System.IO;
        using System.Text;
        using System.Diagnostics;

        public static class Logger
        {
            private const string LogFilePathConst = "calculation_log.txt";

            public static string LogFilePath => LogFilePathConst;

            public static void LogCalculation(LongInteger firstOperand, string operation, LongInteger secondOperand, LongInteger result)
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string logEntry = $"[{timestamp}] INFO: Calculation: {firstOperand} {operation} {secondOperand} = {result} (Iterations: {LongInteger.LastOperationIterations}){Environment.NewLine}";
                    File.AppendAllText(LogFilePathConst, logEntry, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to write calculation to log file: {ex.Message}");
                    Console.WriteLine($"Failed to write calculation to log file: {ex.Message}");
                }
            }

            public static void LogUnaryOperation(string operationName, LongInteger operand, LongInteger result)
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string logEntry = $"[{timestamp}] INFO: Unary Operation: {operationName}({operand}) = {result} (Iterations: {LongInteger.LastOperationIterations}){Environment.NewLine}";
                    File.AppendAllText(LogFilePathConst, logEntry, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to write unary operation to log file: {ex.Message}");
                    Console.WriteLine($"Failed to write unary operation to log file: {ex.Message}");
                }
            }

            public static void LogError(string operationDescription, string errorMessage, Exception exDetails = null, string suggestedFix = "N/A")
            {
                try
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    StringBuilder logEntryBuilder = new StringBuilder();
                    logEntryBuilder.AppendLine($"[{timestamp}] ERROR");
                    logEntryBuilder.AppendLine($"  Operation: {operationDescription}");
                    logEntryBuilder.AppendLine($"  Message: {errorMessage}");
                    if (exDetails != null)
                    {
                        logEntryBuilder.AppendLine($"  Exception Type: {exDetails.GetType().FullName}");
                        logEntryBuilder.AppendLine($"  Exception Message: {exDetails.Message}");
                        if (exDetails.InnerException != null)
                        {
                            logEntryBuilder.AppendLine($"  Inner Exception: {exDetails.InnerException.Message}");
                        }
                        logEntryBuilder.AppendLine($"  Stack Trace: {exDetails.StackTrace}");
                    }
                    logEntryBuilder.AppendLine($"  Suggested Fix: {suggestedFix}");
                    logEntryBuilder.AppendLine("--------------------------------------------------");

                    File.AppendAllText(LogFilePathConst, logEntryBuilder.ToString(), Encoding.UTF8);
                }
                catch (Exception loggingException)
                {
                    Debug.WriteLine($"CRITICAL LOGGING ERROR: Could not write error to log file. Original error: '{errorMessage}'. Logging attempt error: {loggingException.Message}");
                    Console.WriteLine($"CRITICAL LOGGING ERROR: Could not write error to log file. Original error: '{errorMessage}'. Logging attempt error: {loggingException.Message}");
                }
            }
        }
    }
}
