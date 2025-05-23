using Cursak.Cursak;
using CustomButton;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;


namespace Cursak
{
    public partial class Calculator : Form
    {
        bool enterValue = false;
        private LongInteger operand1 = LongInteger.Zero;
        private string pendingOperation = string.Empty;
        private const string LogFilePath = "calculation_log.txt";
        private readonly string _allowed = "0123456789";

        private string _specialDecimalDisplayString = null;
        private const int DecimalPrecision = 5;

        // Конструктор: Ініціалізує форму калькулятора, встановлює початковий дисплей.
        public Calculator()
        {
            InitializeComponent();
            if (textForDisplay != null && string.IsNullOrEmpty(textForDisplay.Text))
            {
                textForDisplay.Text = "0";
            }
            if (secondaryDisplayLabel != null)
            {
                secondaryDisplayLabel.Text = string.Empty;
            }
            this.KeyPreview = true; // Вмикає перехоплення клавіатурних подій
        }

        // Перемикає вікно між максимізованим і нормальним станом.
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        // Мінімізує вікно.
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Закриває форму.
        private void buttonWxit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void panelHistory_Paint(object sender, PaintEventArgs e)
        {

        }
        private void textDisplay1_TextChanged(object sender, EventArgs e)
        {
        }

        Point lastPoint;
        // Переміщує форму при натиснутій лівій кнопці миші.
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        // Переміщує форму при натиснутій лівій кнопці миші.
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        // Переміщує форму при натиснутій лівій кнопці миші.
        private void textDisplay1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }


        private void textDisplay1_MouseEnter(object sender, EventArgs e)
        {

        }

        // Видаляє останній символ з дисплея.
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (textForDisplay.Text.Length > 0)
                textForDisplay.Text = textForDisplay.Text.Remove(textForDisplay.Text.Length - 1, 1);
            if (textForDisplay.Text == string.Empty)
                textForDisplay.Text = "0";
        }
        // Скидає дисплей до нуля.
        private void myOwnButton9_Click(object sender, EventArgs e)
        {
            textForDisplay.Text = "0";
            _specialDecimalDisplayString = null;
        }
        // Скидає всі значення калькулятора.
        private void myOwnButton8_Click(object sender, EventArgs e)
        {
            textForDisplay.Text = "0";
            secondaryDisplayLabel.Text = string.Empty;
            operand1 = LongInteger.Zero;
            pendingOperation = string.Empty;
            enterValue = false;
            _specialDecimalDisplayString = null;
        }


        private const int MAX_DIGIT_COUNT = 150;
        // Додає цифру до дисплея.
        private void BtnNum_Click(object sender, EventArgs e)
        {
            MyOwnButton clickedButton = sender as MyOwnButton;

            if (clickedButton == null)
            {
                return;
            }

            string digitToAppend = clickedButton.Text;
            if (string.IsNullOrEmpty(digitToAppend) || digitToAppend.Length != 1 || !char.IsDigit(digitToAppend[0]))
            {
                return;
            }
            if (textForDisplay.Text == "0" || enterValue || _specialDecimalDisplayString != null)
            {
                textForDisplay.Text = string.Empty;
                _specialDecimalDisplayString = null;
            }
            enterValue = false;
            if (textForDisplay.Text.Length < MAX_DIGIT_COUNT)
            {
                textForDisplay.Text += digitToAppend;
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }

        // Виконує обчислення залежно від операції.
        private void PerformCalculation()
        {
            if (string.IsNullOrEmpty(pendingOperation) || this.textForDisplay == null)
            {
                return;
            }

            LongInteger originalOperand1 = operand1;
            LongInteger operand2 = LongInteger.Zero;

            _specialDecimalDisplayString = null;

            if (pendingOperation != "!")
            {
                try
                {
                    operand2 = new LongInteger(this.textForDisplay.Text);
                }
                catch (ArgumentException ex)
                {
                    string errorMsg = $"Некоректний формат другого числа. Введено: '{this.textForDisplay.Text}'";
                    string suggestion = "Перевірте, чи введене значення є цілим числом. Видаліть будь-які нецифрові символи (літери, зайві коми тощо).";
                    Logger.LogError($"Парсинг другого операнда для операції '{pendingOperation}'", errorMsg, ex, suggestion);

                    MessageBox.Show($"Помилка: {errorMsg}\nДеталі: {ex.Message}\nРекомендація: {suggestion}",
                                    "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetCalculatorStateOnError(isParsingError: true);
                    return;
                }
            }

            LongInteger resultOfCalculation = LongInteger.Zero;
            bool calculationErrorOccurred = false;

            try
            {
                switch (pendingOperation)
                {
                    case "+":
                        resultOfCalculation = originalOperand1 + operand2;
                        panelForHistory.AppendText($"{originalOperand1} + {operand2} = {resultOfCalculation}\n");
                        break;
                    case "-":
                        resultOfCalculation = originalOperand1 - operand2;
                        panelForHistory.AppendText($"{originalOperand1} - {operand2} = {resultOfCalculation}\n");
                        break;
                    case "×":
                        resultOfCalculation = originalOperand1 * operand2;
                        panelForHistory.AppendText($"{originalOperand1} * {operand2} = {resultOfCalculation}\n");
                        break;
                    case "÷":
                        if (operand2.IsZero)
                        {
                            string errorMsg = "Ділення на нуль неможливе!";
                            string operationDesc = $"{originalOperand1.ToString()} ÷ {operand2.ToString()}";
                            string suggestion = "Другий операнд (дільник) не може бути нулем. Будь ласка, введіть інше значення для дільника.";
                            Logger.LogError(operationDesc, errorMsg, null, suggestion);

                            MessageBox.Show($"Помилка: {errorMsg}\nРекомендація: {suggestion}",
                                            "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetCalculatorStateOnError(displaySpecificError: "Ділення на 0");
                            calculationErrorOccurred = true;
                        }
                        else
                        {
                            (LongInteger quotient, LongInteger remainder) = LongInteger.DivideAndModulo(originalOperand1, operand2);
                            Logger.LogCalculation(originalOperand1, pendingOperation, operand2, quotient);

                            resultOfCalculation = quotient;
                            _specialDecimalDisplayString = GenerateDecimalStringForDivision(originalOperand1, operand2, quotient, remainder);

                            panelForHistory.AppendText($"{originalOperand1} ÷ {operand2} = {_specialDecimalDisplayString}\n");
                        }
                        break;
                    case "^":
                        if (operand2 < LongInteger.Zero)
                        {
                            string errorMsg = "Показник степеня не може бути від'ємним.";
                            string operationDesc = $"{originalOperand1.ToString()} ^ {operand2.ToString()}";
                            string suggestion = "Для операції піднесення до степеня в цьому калькуляторі, будь ласка, використовуйте невід'ємний цілий показник степеня.";
                            Logger.LogError(operationDesc, errorMsg, null, suggestion);

                            MessageBox.Show($"Помилка: {errorMsg}\nРекомендація: {suggestion}",
                                            "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetCalculatorStateOnError(displaySpecificError: "Від'ємний степінь");
                            calculationErrorOccurred = true;
                        }
                        else
                        {
                            resultOfCalculation = LongInteger.Pow(originalOperand1, operand2);
                            panelForHistory.AppendText($"{originalOperand1} ^ {operand2} = {resultOfCalculation}\n");
                        }
                        break;
                    case "!":
                        if (originalOperand1 < LongInteger.Zero)
                        {
                            string errorMsg = "Факторіал не визначений для від'ємних чисел.";
                            string operationDesc = $"Factorial({originalOperand1.ToString()})";
                            string suggestion = "Будь ласка, введіть невід'ємне ціле число для обчислення факторіалу (наприклад, 0, 1, 5).";
                            Logger.LogError(operationDesc, errorMsg, null, suggestion);
                            MessageBox.Show($"Помилка: {errorMsg}\nРекомендація: {suggestion}",
                                            "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetCalculatorStateOnError(displaySpecificError: "Від'ємне для n!");
                            calculationErrorOccurred = true;
                        }
                        else
                        {
                            try
                            {
                                int nValue = int.Parse(originalOperand1.ToString());
                                resultOfCalculation = LongInteger.Factorial(nValue);
                                panelForHistory.AppendText($"{originalOperand1}! = {resultOfCalculation}\n");
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("Помилка: Число (введене для n!) завелике, щоб бути представленим як int.",
                                                "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ResetCalculatorStateOnError(displaySpecificError: "Число n завелике!");
                                calculationErrorOccurred = true;
                            }
                            catch (ArgumentOutOfRangeException aooreFactorial)
                            {
                                MessageBox.Show($"Помилка обчислення факторіалу: {aooreFactorial.Message}",
                                                "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ResetCalculatorStateOnError(displaySpecificError: "Помилка факторіалу!");
                                calculationErrorOccurred = true;
                            }
                        }
                        break;
                    default:
                        MessageBox.Show($"Внутрішня помилка: невідома операція '{pendingOperation}'.",
                                        "Помилка програми", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetCalculatorStateOnError();
                        calculationErrorOccurred = true;
                        break;
                }

                if (!calculationErrorOccurred)
                {
                    if (pendingOperation == "!")
                    {
                        Logger.LogUnaryOperation("Factorial", originalOperand1, resultOfCalculation);
                    }
                    else if (pendingOperation != "÷")
                    {
                        Logger.LogCalculation(originalOperand1, pendingOperation, operand2, resultOfCalculation);
                    }

                    operand1 = resultOfCalculation;
                    if (pendingOperation == "÷" && _specialDecimalDisplayString != null)
                    {
                        this.textForDisplay.Text = _specialDecimalDisplayString;
                    }
                    else
                    {
                        this.textForDisplay.Text = operand1.ToString();
                    }
                }
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Помилка: Ділення на нуль неможливе!",
                                "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetCalculatorStateOnError(displaySpecificError: "Ділення на 0");
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                MessageBox.Show($"Помилка операції '{pendingOperation}': {aoore.Message}",
                                "Арифметична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string specificError = pendingOperation == "n!" ? "Помилка факторіалу!" : $"Операція({aoore.ParamName})";
                ResetCalculatorStateOnError(displaySpecificError: specificError);
            }
            catch (ArgumentNullException anex)
            {
                MessageBox.Show("Помилка: Один з аргументів операції був null.\n" + anex.Message,
                                "Помилка аргументу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetCalculatorStateOnError();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася неочікувана арифметична помилка: {ex.Message}",
                                "Помилка обчислення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetCalculatorStateOnError();
            }
        }

        // Скидає стан калькулятора при помилці.
        private void ResetCalculatorStateOnError(bool isParsingError = false, string displaySpecificError = null)
        {
            if (this.textForDisplay == null)
            {
                return;
            }

            if (displaySpecificError != null)
            {
                textForDisplay.Text = displaySpecificError;
            }
            else if (isParsingError)
            {
                textForDisplay.Text = "Формат!";
            }
            else
            {
                textForDisplay.Text = "Помилка";
            }

            if (secondaryDisplayLabel != null)
            {
                secondaryDisplayLabel.Text = string.Empty;
            }

            operand1 = LongInteger.Zero;
            pendingOperation = string.Empty;
            enterValue = true;
        }

        // Виконує обчислення при натисканні кнопки "=".
        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pendingOperation) || textForDisplay == null || secondaryDisplayLabel == null)
            {
                return;
            }

            LongInteger operand1BeforeCalc = operand1;
            LongInteger operand2ForDisplay;

            if (pendingOperation == "!")
            {
                secondaryDisplayLabel.Text = $"{operand1BeforeCalc.ToString()}! =";
            }
            else
            {
                try
                {
                    if (textForDisplay.Text.Contains("."))
                    {
                        if (_specialDecimalDisplayString == null && !enterValue)
                        {
                            MessageBox.Show("Помилка: Другий операнд не може бути дробовим числом для цілочисельних операцій.", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetCalculatorStateOnError(isParsingError: true);
                            return;
                        }
                    }
                    operand2ForDisplay = new LongInteger(textForDisplay.Text);
                    if (operand1BeforeCalc != null && !string.IsNullOrEmpty(pendingOperation) && operand2ForDisplay != null)
                    {
                        secondaryDisplayLabel.Text = $"{operand1BeforeCalc.ToString()} {pendingOperation} {operand2ForDisplay.ToString()} =";
                    }
                }
                catch (ArgumentException)
                {
                    PerformCalculation();
                    if (pendingOperation == string.Empty && secondaryDisplayLabel != null)
                    {
                        secondaryDisplayLabel.Text = string.Empty;
                    }
                    return;
                }
            }

            PerformCalculation();

            pendingOperation = string.Empty;
            enterValue = true;
            _specialDecimalDisplayString = null;
        }

        // Обробляє натискання математичних операцій.
        private void buttonMathOperations(object sender, MouseEventArgs e)
        {
            MyOwnButton clickedOperatorButton = sender as MyOwnButton;
            if (clickedOperatorButton == null || textForDisplay == null || secondaryDisplayLabel == null)
            {
                return;
            }

            string currentOperator = clickedOperatorButton.Text;
            if (currentOperator == "!")
            {
                LongInteger numberToFactorial;
                if (enterValue && !string.IsNullOrEmpty(pendingOperation) && pendingOperation != "!")
                {
                    numberToFactorial = operand1;
                }
                else
                {
                    try
                    {
                        numberToFactorial = new LongInteger(textForDisplay.Text);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Помилка: Некоректний формат числа для факторіалу.\n{ex.Message}",
                                        "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetCalculatorStateOnError(isParsingError: true);
                        return;
                    }
                }
                secondaryDisplayLabel.Text = $"{numberToFactorial}! =";
                operand1 = numberToFactorial;

                pendingOperation = "!";
                PerformCalculation();
                pendingOperation = string.Empty;
                enterValue = true;

                _specialDecimalDisplayString = null;
                return;
            }

            if (!enterValue)
            {
                if (string.IsNullOrEmpty(pendingOperation))
                {
                    try
                    {
                        if (textForDisplay.Text.Contains("."))
                        {
                            Logger.LogError("Парсинг першого операнда", $"Некоректний формат (містить крапку): '{textForDisplay.Text}'", null, "Введіть ціле число.");
                            MessageBox.Show($"Помилка: Некоректний формат першого числа (містить крапку).\nВведено: {textForDisplay.Text}",
                                            "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetCalculatorStateOnError(isParsingError: true);
                            return;
                        }
                        else
                        {
                            operand1 = new LongInteger(textForDisplay.Text);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Помилка: Некоректний формат першого числа.\nДеталі: {ex.Message}",
                                        "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetCalculatorStateOnError(isParsingError: true);
                        return;
                    }
                }
                else
                {
                    PerformCalculation();
                }

            }

            pendingOperation = currentOperator;
            enterValue = true;

            if (operand1 != null)
            {
                secondaryDisplayLabel.Text = $"{operand1.ToString()} {pendingOperation}";
            }
            else
            {
                secondaryDisplayLabel.Text = $"{LongInteger.Zero.ToString()} {pendingOperation}";
            }
            textForDisplay.Text = "0";
            _specialDecimalDisplayString = null;
            enterValue = true;
        }

        // Фільтрує недозволені символи при введенні з клавіатури.
        private void DisplayKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Обробляє введення з клавіатури (цифри та Backspace).
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char c = e.KeyChar;
            if (_allowed.Contains(c))
            {
                if (textForDisplay.Text == "0")
                {
                    textForDisplay.Text = c.ToString();
                }
                else if (textForDisplay.Text.Length < MAX_DIGIT_COUNT)
                {
                    textForDisplay.Text += c;
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    e.Handled = true;
                    MessageBox.Show("Максимальна кількість символів перевищена!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (c == (char)Keys.Back)
            {
                if (textForDisplay.Text.Length > 0)
                    textForDisplay.Text = textForDisplay.Text.Substring(0, textForDisplay.Text.Length - 1);
                else
                    textForDisplay.Text = "0";
            }
            e.Handled = true;
        }

        // Перемикає видимість панелі історії.
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            panelHistory.Height = (panelHistory.Height == 5) ? panelHistory.Height = 450 : 5;
        }

        // Очищає історію обчислень.
        private void BtnClearHistory(object sender, EventArgs e)
        {
            panelForHistory.Clear();
        }

        // Відкриває файл логу.
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (File.Exists(LogFilePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = LogFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Log file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Генерує дробовий рядок для результату ділення.
        private string GenerateDecimalStringForDivision(
            LongInteger originalDividend,
            LongInteger originalDivisor,
            LongInteger actualQuotient,
            LongInteger actualRemainder)
        {
            StringBuilder sbDisplay = new StringBuilder();

            bool dividendIsNegative = originalDividend < LongInteger.Zero;
            bool divisorIsNegative = originalDivisor < LongInteger.Zero;
            bool overallResultIsNegative = dividendIsNegative != divisorIsNegative;

            bool isResultActuallyZero = actualQuotient.IsZero && actualRemainder.IsZero;

            if (overallResultIsNegative && !isResultActuallyZero)
            {
                sbDisplay.Append("-");
            }

            sbDisplay.Append(actualQuotient.Abs().ToString());

            if (DecimalPrecision > 0)
            {
                sbDisplay.Append(".");

                if (actualRemainder.IsZero)
                {
                    sbDisplay.Append(new string('0', DecimalPrecision));
                }
                else
                {
                    LongInteger currentRemainder = actualRemainder.Abs();
                    LongInteger absDivisor = originalDivisor.Abs();
                    LongInteger ten = new LongInteger(10L);

                    for (int i = 0; i < DecimalPrecision; i++)
                    {
                        currentRemainder = currentRemainder * ten;
                        LongInteger digit = currentRemainder / absDivisor;
                        LongInteger nextRemainder = currentRemainder % absDivisor;

                        sbDisplay.Append(digit.ToString());
                        currentRemainder = nextRemainder;

                        if (currentRemainder.IsZero)
                        {
                            for (int j = i + 1; j < DecimalPrecision; j++)
                            {
                                sbDisplay.Append("0");
                            }
                            break;
                        }
                    }
                }
            }
            return sbDisplay.ToString();
        }

        // Змінює знак числа на дисплеї.
        private void myOwnButton1_Click(object sender, EventArgs e)
        {
            if (textForDisplay.Text == "Помилка" ||
                textForDisplay.Text == "Формат!" ||
                textForDisplay.Text.StartsWith("Від'ємне") ||
                textForDisplay.Text.Contains("!"))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            if (textForDisplay == null || string.IsNullOrWhiteSpace(textForDisplay.Text))
                return;

            string currentText = textForDisplay.Text?.Trim();
            if (string.IsNullOrWhiteSpace(currentText) || currentText == "0")
            {
                textForDisplay.Text = "-";
                return;
            }

            if (_specialDecimalDisplayString != null)
            {
                if (_specialDecimalDisplayString.StartsWith("-"))
                    _specialDecimalDisplayString = _specialDecimalDisplayString.Substring(1);
                else
                    _specialDecimalDisplayString = "-" + _specialDecimalDisplayString;

                textForDisplay.Text = _specialDecimalDisplayString;
                return;
            }

            if (textForDisplay.Text.StartsWith("-"))
            {
                textForDisplay.Text = textForDisplay.Text.Substring(1);
            }
            else if (textForDisplay.Text != "0")
            {
                textForDisplay.Text = "-" + textForDisplay.Text;
            }
        }

        //Функція для вставки числа з буфера обміну
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string clipboardText = Clipboard.GetText().Trim();
                // Перевіряємо, що це рядок виду "-123" або "456"
                if (IsNumberString(clipboardText))
                {
                    textForDisplay.Text = clipboardText;
                }
                else
                {
                    MessageBox.Show("У буфері обміну має бути тільки число (можна з мінусом).", "Помилка вставки");
                }

                e.SuppressKeyPress = true;
            }
        }
        // Перевіряє, чи рядок є числом (цілим або з мінусом на початку).
        private bool IsNumberString(string input)
        {
            // Дозволяємо рядки, що складаються тільки з цифр або мають один мінус на початку
            if (string.IsNullOrEmpty(input)) return false;

            if (input[0] == '-')
                return input.Length > 1 && input.Skip(1).All(char.IsDigit);
            else
                return input.All(char.IsDigit);
        }
    }
}

