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
    /// <summary>
    /// Головна форма калькулятора. Відповідає за обробку вводу користувача,
    /// виконання математичних операцій з довгими цілими числами та відображення результатів.
    /// </summary>
    public partial class Calculator : Form
    {
        /// <summary>
        /// Прапор, що вказує, чи було щойно введено значення (наприклад, після натискання оператора).
        /// Якщо true, наступне введення цифри очистить дисплей перед додаванням нової цифри.
        /// </summary>
        bool enterValue = false;

        /// <summary>
        /// Перший операнд для бінарних операцій. Зберігає значення після натискання кнопки оператора.
        /// Тип даних: LongInteger - клас для роботи з довгими цілими числами.
        /// </summary>
        private LongInteger operand1 = LongInteger.Zero;

        /// <summary>
        /// Рядок, що зберігає математичну операцію, яка очікує на виконання (+, -, ×, ÷, ^).
        /// Тип даних: string.
        /// </summary>
        private string pendingOperation = string.Empty;

        /// <summary>
        /// Ім'я файлу для ведення журналу обчислень.
        /// Тип даних: const string.
        /// </summary>
        private const string LogFilePath = "calculation_log.txt";

        /// <summary>
        /// Рядок, що містить дозволені для введення символи (цифри).
        /// Тип даних: readonly string.
        /// </summary>
        private readonly string _allowed = "0123456789";

        /// <summary>
        /// Спеціальний рядок для відображення результату ділення з десятковою частиною.
        /// Якщо null, відображається стандартне ціле число.
        /// Тип даних: string.
        /// </summary>
        private string _specialDecimalDisplayString = null;

        /// <summary>
        /// Кількість знаків після коми для операції ділення.
        /// Тип даних: const int.
        /// </summary>
        private const int DecimalPrecision = 5;

        /// <summary>
        /// Максимальна кількість цифр, яку можна ввести на дисплей.
        /// Тип даних: const int.
        /// </summary>
        private const int MAX_DIGIT_COUNT = 150;

        /// <summary>
        /// Остання зафіксована позиція курсору миші для переміщення форми.
        /// Тип даних: Point.
        /// </summary>
        Point lastPoint;

        /// <summary>
        /// Конструктор класу Calculator.
        /// Ініціалізує компоненти форми, встановлює початкові значення для дисплеїв
        /// та вмикає перехоплення подій клавіатури на рівні форми.
        /// </summary>
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
            this.KeyPreview = true;
        }

        /// <summary>
        /// Обробник події для кнопки "Розгорнути/Відновити".
        /// Перемикає вікно між максимізованим і нормальним станом.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (кнопка).</param>
        /// <param name="e">Аргументи події.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        /// <summary>
        /// Обробник події для кнопки "Згорнути".
        /// Мінімізує вікно калькулятора.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (кнопка).</param>
        /// <param name="e">Аргументи події.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Обробник події для кнопки "Закрити".
        /// Закриває форму калькулятора.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (кнопка).</param>
        /// <param name="e">Аргументи події.</param>
        private void buttonWxit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обробник події переміщення миші по формі.
        /// Переміщує вікно, якщо затиснута ліва кнопка миші.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (форма).</param>
        /// <param name="e">Аргументи події миші, що містять координати.</param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        /// <summary>
        /// Обробник події натискання кнопки миші на формі.
        /// Зберігає початкову позицію курсору для подальшого переміщення вікна.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (форма).</param>
        /// <param name="e">Аргументи події миші.</param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Обробник події натискання кнопки миші на дисплеї.
        /// Зберігає початкову позицію курсору для подальшого переміщення вікна.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (дисплей).</param>
        /// <param name="e">Аргументи події миші.</param>
        private void textDisplay1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Обробник події для кнопки "Backspace" (⌫).
        /// Видаляє останній символ з головного дисплея. Якщо дисплей стає порожнім, встановлює "0".
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (textForDisplay.Text.Length > 0)
                textForDisplay.Text = textForDisplay.Text.Remove(textForDisplay.Text.Length - 1, 1);
            if (string.IsNullOrEmpty(textForDisplay.Text))
                textForDisplay.Text = "0";
        }

        /// <summary>
        /// Обробник події для кнопки "CE" (Clear Entry).
        /// Скидає поточне введене число на дисплеї до "0".
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void myOwnButton9_Click(object sender, EventArgs e)
        {
            textForDisplay.Text = "0";
            _specialDecimalDisplayString = null;
        }

        /// <summary>
        /// Обробник події для кнопки "C" (Clear).
        /// Повністю скидає стан калькулятора: очищує дисплеї, операнди та операції, що очікують.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void myOwnButton8_Click(object sender, EventArgs e)
        {
            textForDisplay.Text = "0";
            secondaryDisplayLabel.Text = string.Empty;
            operand1 = LongInteger.Zero;
            pendingOperation = string.Empty;
            enterValue = false;
            _specialDecimalDisplayString = null;
        }

        /// <summary>
        /// Обробник події для кнопок з цифрами (0-9).
        /// Додає відповідну цифру до числа на головному дисплеї.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (кнопка з цифрою).</param>
        /// <param name="e">Аргументи події.</param>
        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (sender is MyOwnButton clickedButton)
            {
                string digitToAppend = clickedButton.Text;

                if ((textForDisplay.Text == "0" || enterValue || _specialDecimalDisplayString != null) && textForDisplay.Text != "-")
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
        }

        /// <summary>
        /// Виконує математичну операцію, що очікує, використовуючи operand1 та поточне значення на дисплеї як operand2.
        /// Обробляє різні операції (+, -, *, /, ^, !) та можливі помилки (ділення на нуль, некоректний формат).
        /// </summary>
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


        /// <summary>
        /// Скидає стан калькулятора у випадку виникнення помилки обчислення або парсингу.
        /// Відображає повідомлення про помилку на головному дисплеї.
        /// </summary>
        /// <param name="isParsingError">Прапор, що вказує, чи сталася помилка при перетворенні рядка в число.</param>
        /// <param name="displaySpecificError">Спеціальний рядок помилки для відображення.</param>
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

        /// <summary>
        /// Обробник події для кнопки "=".
        /// Ініціює виконання фінального обчислення.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
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

        /// <summary>
        /// Обробник події для кнопок математичних операцій (+, -, ×, ÷, ^, !).
        /// Встановлює операцію, що очікує, та готує калькулятор до введення другого операнда.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію (кнопка операції).</param>
        /// <param name="e">Аргументи події миші.</param>
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


        /// <summary>
        /// Обробник події натискання клавіш на клавіатурі для головного дисплея.
        /// Фільтрує введення, дозволяючи лише цифри.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події натискання клавіші.</param>
        private void DisplayKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обробник події натискання клавіш на рівні форми.
        /// Дозволяє вводити цифри та використовувати Backspace для редагування числа на дисплеї.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події натискання клавіші.</param>
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

        /// <summary>
        /// Обробник події для кнопки "Історія".
        /// Перемикає видимість панелі з історією обчислень.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            panelHistory.Height = (panelHistory.Height == 5) ? panelHistory.Height = 450 : 5;
        }

        /// <summary>
        /// Обробник події для кнопки "Очистити історію".
        /// Видаляє весь текст з панелі історії.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
        private void BtnClearHistory(object sender, EventArgs e)
        {
            panelForHistory.Clear();
        }

        /// <summary>
        /// Обробник події для кнопки "Меню" (відкриття журналу).
        /// Відкриває файл журналу `calculation_log.txt` у стандартному текстовому редакторі.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
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

        /// <summary>
        /// Генерує рядкове представлення результату ділення з десятковою частиною.
        /// Обчислює знаки після коми з заданою точністю.
        /// </summary>
        /// <param name="originalDividend">Початкове ділене (тип LongInteger).</param>
        /// <param name="originalDivisor">Початковий дільник (тип LongInteger).</param>
        /// <param name="actualQuotient">Обчислена ціла частина від ділення (тип LongInteger).</param>
        /// <param name="actualRemainder">Обчислена остача від ділення (тип LongInteger).</param>
        /// <returns>Рядок, що представляє результат ділення з десятковою точкою.</returns>
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

        /// <summary>
        /// Обробник події для кнопки "+/-".
        /// Змінює знак числа, відображеного на головному дисплеї.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події.</param>
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

        /// <summary>
        /// Обробник події натискання комбінації клавіш на рівні форми.
        /// Реалізує вставку числа з буфера обміну за допомогою Ctrl+V.
        /// </summary>
        /// <param name="sender">Об'єкт, що викликав подію.</param>
        /// <param name="e">Аргументи події клавіатури.</param>
        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                string clipboardText = Clipboard.GetText().Trim();
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
        /// <summary>
        /// Перевіряє, чи є вхідний рядок представленням цілого числа.
        /// Допускаються лише цифри та один мінус на початку рядка.
        /// </summary>
        /// <param name="input">Рядок для перевірки.</param>
        /// <returns><c>true</c>, якщо рядок є коректним числовим представленням; інакше <c>false</c>.</returns>
        private bool IsNumberString(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            if (input[0] == '-')
                return input.Length > 1 && input.Skip(1).All(char.IsDigit);
            else
                return input.All(char.IsDigit);
        }

        private void panelHistory_Paint(object sender, PaintEventArgs e) { }
        private void textDisplay1_TextChanged(object sender, EventArgs e) { }
        private void textDisplay1_MouseEnter(object sender, EventArgs e) { }
    }
}