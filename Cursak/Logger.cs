using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Cursak
{
    /// <summary>
    /// Надає статичні методи для ведення журналу (логування) операцій та помилок у текстовий файл.
    /// Клас є статичним, тому його екземпляр не може бути створений.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Константа, що зберігає шлях до файлу журналу.
        /// Тип даних: const string.
        /// </summary>
        private const string LogFilePathConst = "calculation_log.txt";

        /// <summary>
        /// Отримує шлях до файлу журналу.
        /// </summary>
        public static string LogFilePath => LogFilePathConst;

        /// <summary>
        /// Записує до журналу інформацію про виконану бінарну операцію (наприклад, додавання, віднімання).
        /// </summary>
        /// <param name="firstOperand">Перший операнд.</param>
        /// <param name="operation">Символ операції (наприклад, "+", "×").</param>
        /// <param name="secondOperand">Другий операнд.</param>
        /// <param name="result">Результат обчислення.</param>
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

        /// <summary>
        /// Записує до журналу інформацію про виконану унарну операцію (наприклад, факторіал).
        /// </summary>
        /// <param name="operationName">Назва операції (наприклад, "Factorial").</param>
        /// <param name="operand">Операнд, до якого була застосована операція.</param>
        /// <param name="result">Результат обчислення.</param>
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

        /// <summary>
        /// Записує до журналу детальну інформацію про помилку, що виникла під час виконання програми.
        /// </summary>
        /// <param name="operationDescription">Опис операції, під час якої сталася помилка.</param>
        /// <param name="errorMessage">Повідомлення про помилку.</param>
        /// <param name="exDetails">Об'єкт винятку (Exception) з деталями помилки (необов'язковий).</param>
        /// <param name="suggestedFix">Рекомендація щодо усунення помилки (необов'язковий).</param>
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