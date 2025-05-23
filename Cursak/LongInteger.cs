using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class LongInteger : IComparable<LongInteger>
{
    private List<byte> _digits;
    private bool _isNegative;
    public static long LastOperationIterations { get; private set; }

    public static readonly LongInteger Zero = new LongInteger("0");
    public static readonly LongInteger One = new LongInteger("1");
    public static readonly LongInteger MinusOne = new LongInteger("-1");
    private static readonly LongInteger Two = new LongInteger("2");

    #region Конструктори
    public LongInteger(string number)
    {
        if (string.IsNullOrEmpty(number))
            throw new ArgumentException("Рядок числа не може бути порожнім.");

        _digits = new List<byte>();
        int startIndex = 0;
        _isNegative = false;

        if (number[0] == '-')
        {
            _isNegative = true;
            startIndex = 1;
            if (number.Length == 1) throw new ArgumentException("Некоректний рядок числа: '-'");
        }
        else if (number[0] == '+')
        {
            startIndex = 1;
            if (number.Length == 1) throw new ArgumentException("Некоректний рядок числа: '+'");
        }

        for (int i = number.Length - 1; i >= startIndex; i--)
        {
            if (!char.IsDigit(number[i]))
                throw new ArgumentException($"Некоректний символ '{number[i]}' у рядку числа.");
            _digits.Add((byte)(number[i] - '0'));
        }

        RemoveLeadingZeros();
        if (_digits.Count == 1 && _digits[0] == 0)
        {
            _isNegative = false;
        }
    }

    public LongInteger(long number)
    {
        _digits = new List<byte>();
        if (number == 0)
        {
            _digits.Add(0);
            _isNegative = false;
            return;
        }

        if (number < 0)
        {
            _isNegative = true;
            if (number == long.MinValue)
            {
                var temp = new LongInteger(long.MaxValue.ToString());
                temp = temp + One;
                this._digits = new List<byte>(temp._digits);
                this._isNegative = true;
                return;
            }
            number = -number;
        }
        else
        {
            _isNegative = false;
        }

        while (number > 0)
        {
            _digits.Add((byte)(number % 10));
            number /= 10;
        }
    }

    private LongInteger(List<byte> newDigits, bool newIsNegative, bool skipNormalization = false)
    {
        this._digits = new List<byte>(newDigits);
        this._isNegative = newIsNegative;
        if (!skipNormalization)
        {
            RemoveLeadingZeros();
            if (this._digits.Count == 1 && this._digits[0] == 0)
            {
                this._isNegative = false;
            }
        }
    }
    #endregion

    private void RemoveLeadingZeros()
    {
        if (_digits == null) return;

        int i = _digits.Count - 1;
        while (i > 0 && _digits[i] == 0)
        {
            _digits.RemoveAt(i);
            i--;
        }
        if (_digits.Count == 0)
        {
            _digits.Add(0);
        }
    }

    public override string ToString()
    {
        if (IsZero)
            return "0";

        StringBuilder sb = new StringBuilder();
        if (_isNegative)
        {
            sb.Append('-');
        }
        for (int i = _digits.Count - 1; i >= 0; i--)
        {
            sb.Append(_digits[i]);
        }
        return sb.ToString();
    }

    public bool IsZero => _digits.Count == 1 && _digits[0] == 0 && !_isNegative;

    #region Порівняння
    public int CompareTo(LongInteger other)
    {
        if (other is null) return 1;

        if (this.IsZero && other.IsZero) return 0;
        if (this.IsZero) return other._isNegative ? 1 : -1;
        if (other.IsZero) return this._isNegative ? -1 : 1;

        if (_isNegative && !other._isNegative) return -1;
        if (!_isNegative && other._isNegative) return 1;

        int magnitudeComparison = CompareMagnitude(_digits, other._digits);

        return _isNegative ? -magnitudeComparison : magnitudeComparison;
    }

    private static int CompareMagnitude(List<byte> d1, List<byte> d2)
    {
        long iterations = 0;
        if (d1.Count > d2.Count) { LastOperationIterations = iterations; return 1; }
        if (d1.Count < d2.Count) { LastOperationIterations = iterations; return -1; }
        for (int i = d1.Count - 1; i >= 0; i--)
        {
            iterations++;
            if (d1[i] > d2[i]) { LastOperationIterations = iterations; return 1; }
            if (d1[i] < d2[i]) { LastOperationIterations = iterations; return -1; }
        }
        LastOperationIterations = iterations;
        return 0;
    }

    public static bool operator ==(LongInteger a, LongInteger b)
    {
        if (ReferenceEquals(a, null))
        {
            return ReferenceEquals(b, null);
        }
        return a.Equals(b);
    }
    public static bool operator !=(LongInteger a, LongInteger b) => !(a == b);
    public static bool operator <(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        return a.CompareTo(b) < 0;
    }
    public static bool operator <=(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        return a.CompareTo(b) <= 0;
    }
    public static bool operator >(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        return a.CompareTo(b) > 0;
    }
    public static bool operator >=(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        return a.CompareTo(b) >= 0;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (GetType() != obj.GetType()) return false;

        LongInteger other = (LongInteger)obj;
        if (this.IsZero && other.IsZero) return true;

        return _isNegative == other._isNegative && _digits.SequenceEqual(other._digits);
    }

    public LongInteger Abs()
    {
        if (IsZero) return Zero;
        return new LongInteger(new List<byte>(_digits), false, true);
    }
    #endregion

    #region Арифметичні операції

    public static LongInteger operator +(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        if (a.IsZero) { LastOperationIterations = 0; return b; }
        if (b.IsZero) { LastOperationIterations = 0; return a; }

        if (a._isNegative == b._isNegative)
        {
            List<byte> resultDigits = AddMagnitude(a._digits, b._digits);
            return new LongInteger(resultDigits, a._isNegative);
        }
        else
        {
            int comparison = CompareMagnitude(a._digits, b._digits);
            if (comparison == 0) { LastOperationIterations = LastOperationIterations; return Zero; }

            if (comparison > 0)
            {
                List<byte> resultDigits = SubtractMagnitude(a._digits, b._digits);
                return new LongInteger(resultDigits, a._isNegative);
            }
            else
            {
                List<byte> resultDigits = SubtractMagnitude(b._digits, a._digits);
                return new LongInteger(resultDigits, b._isNegative);
            }
        }
    }

    private static List<byte> AddMagnitude(List<byte> d1, List<byte> d2)
    {
        long iterations = 0;
        List<byte> result = new List<byte>();
        int carry = 0;
        int len1 = d1.Count;
        int len2 = d2.Count;
        int maxLen = Math.Max(len1, len2);

        for (int i = 0; i < maxLen; i++)
        {
            iterations++;
            int val1 = (i < len1) ? d1[i] : 0;
            int val2 = (i < len2) ? d2[i] : 0;
            int sum = val1 + val2 + carry;
            result.Add((byte)(sum % 10));
            carry = sum / 10;
        }
        if (carry > 0)
        {
            iterations++;
            result.Add((byte)carry);
        }
        LastOperationIterations = iterations;
        return result;
    }

    public static LongInteger operator -(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        if (b.IsZero) { LastOperationIterations = 0; return a; }
        LongInteger negativeB = new LongInteger(new List<byte>(b._digits), !b._isNegative, true);
        return a + negativeB;
    }

    private static List<byte> SubtractMagnitude(List<byte> d1, List<byte> d2)
    {
        long iterations = 0;
        List<byte> result = new List<byte>();
        int borrow = 0;
        int len1 = d1.Count;
        int len2 = d2.Count;

        for (int i = 0; i < len1; i++)
        {
            iterations++;
            int val1 = d1[i];
            int val2 = (i < len2) ? d2[i] : 0;
            int diff = val1 - val2 - borrow;
            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            result.Add((byte)diff);
        }
        LastOperationIterations = iterations;
        return result;
    }

    public static LongInteger operator *(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        if (a.IsZero || b.IsZero) { LastOperationIterations = 0; return Zero; }

        bool resultIsNegative = a._isNegative != b._isNegative;

        const int KARATSUBA_THRESHOLD = 6;

        if (a._digits.Count < KARATSUBA_THRESHOLD || b._digits.Count < KARATSUBA_THRESHOLD)
        {
            List<byte> resultDigits = StandardMultiplyMagnitude(a._digits, b._digits);
            return new LongInteger(resultDigits, resultIsNegative);
        }
        else
        {
            LongInteger absA = a._isNegative ? new LongInteger(new List<byte>(a._digits), false, true) : a;
            LongInteger absB = b._isNegative ? new LongInteger(new List<byte>(b._digits), false, true) : b;
            LongInteger resultAbs = KaratsubaMultiply(absA, absB);
            return new LongInteger(new List<byte>(resultAbs._digits), resultIsNegative, true);
        }
    }

    private static List<byte> StandardMultiplyMagnitude(List<byte> d1, List<byte> d2)
    {
        long iterations = 0;
        int len1 = d1.Count;
        int len2 = d2.Count;
        List<int> tempResult = new List<int>(new int[len1 + len2]);

        for (int i = 0; i < len1; i++)
        {
            if (d1[i] == 0) continue;
            int carry = 0;
            for (int j = 0; j < len2; j++)
            {
                iterations++;
                int product = d1[i] * d2[j] + tempResult[i + j] + carry;
                tempResult[i + j] = product % 10;
                carry = product / 10;
            }
            if (carry > 0)
            {
                tempResult[i + len2] += carry;
            }
        }

        List<byte> finalResult = new List<byte>();
        bool nonZeroFound = false;
        for (int i = tempResult.Count - 1; i >= 0; i--)
        {
            if (tempResult[i] != 0) nonZeroFound = true;
            if (nonZeroFound || i == 0)
            {
                finalResult.Add((byte)tempResult[i]);
            }
        }
        if (finalResult.Count == 0) finalResult.Add(0);
        finalResult.Reverse();
        LastOperationIterations = iterations;
        return finalResult;
    }

    private static LongInteger KaratsubaMultiply(LongInteger x, LongInteger y)
    {
        if (x._isNegative || y._isNegative)
            throw new ArgumentException("KaratsubaMultiply expects positive numbers.");

        int nX = x._digits.Count;
        int nY = y._digits.Count;
        int n = Math.Max(nX, nY);

        const int KARATSUBA_THRESHOLD = 6;
        if (n < KARATSUBA_THRESHOLD)
        {
            return new LongInteger(StandardMultiplyMagnitude(x._digits, y._digits), false);
        }

        int m = (n + 1) / 2;

        LongInteger x_low = x.SplitLow(m);
        LongInteger x_high = x.SplitHigh(m);
        LongInteger y_low = y.SplitLow(m);
        LongInteger y_high = y.SplitHigh(m);

        LongInteger z0 = KaratsubaMultiply(x_low, y_low);
        LongInteger z2 = KaratsubaMultiply(x_high, y_high);

        LongInteger sum_x = x_low + x_high;
        LongInteger sum_y = y_low + y_high;

        LongInteger z1_intermediate = KaratsubaMultiply(sum_x, sum_y);
        LongInteger z1 = z1_intermediate - z2 - z0;

        LongInteger term_z2_shifted = z2.ShiftLeft(2 * m);
        LongInteger term_z1_shifted = z1.ShiftLeft(m);

        var finalResult = term_z2_shifted + term_z1_shifted + z0;
        LastOperationIterations = finalResult._digits.Count;
        return finalResult;
    }

    private LongInteger SplitLow(int m)
    {
        if (m <= 0) return Zero;
        if (m >= _digits.Count) return new LongInteger(new List<byte>(_digits), false, true);
        return new LongInteger(_digits.Take(m).ToList(), false, true);
    }
    private LongInteger SplitHigh(int m)
    {
        if (m <= 0) return new LongInteger(new List<byte>(_digits), _isNegative, true);
        if (m >= _digits.Count) return Zero;
        return new LongInteger(_digits.Skip(m).ToList(), false, true);
    }
    private LongInteger ShiftLeft(int m)
    {
        if (IsZero || m == 0) return this;
        if (m < 0) throw new ArgumentOutOfRangeException(nameof(m), "Зсув не може бути від'ємним.");

        List<byte> newDigits = new List<byte>(m + _digits.Count);
        for (int i = 0; i < m; i++)
        {
            newDigits.Add(0);
        }
        newDigits.AddRange(_digits);
        return new LongInteger(newDigits, _isNegative, true);
    }


    public static LongInteger operator /(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        return DivideAndModulo(a, b).quotient;
    }
    public static LongInteger operator %(LongInteger a, LongInteger b)
    {
        if (a is null || b is null) throw new ArgumentNullException(a is null ? "a" : "b");
        return DivideAndModulo(a, b).remainder;
    }

    public static (LongInteger quotient, LongInteger remainder) DivideAndModulo(LongInteger dividend, LongInteger divisor)
    {
        long iterations = 0;
        if (divisor is null) throw new ArgumentNullException(nameof(divisor));
        if (divisor.IsZero) throw new DivideByZeroException("Ділення на нуль.");
        if (dividend is null) throw new ArgumentNullException(nameof(dividend));

        if (dividend.IsZero)
        {
            LastOperationIterations = iterations;
            return (Zero, Zero);
        }

        LongInteger absDividend = dividend.Abs();
        LongInteger absDivisor = divisor.Abs();

        long comparisonIterations = 0; 
        if (absDividend < absDivisor) 
        {
            comparisonIterations = LastOperationIterations;
            LastOperationIterations = comparisonIterations;
            return (Zero, new LongInteger(new List<byte>(dividend._digits), dividend._isNegative, true));
        }

        bool finalQuotientNegative = dividend._isNegative != divisor._isNegative;
        bool finalRemainderNegative = dividend._isNegative;

        List<byte> quotientDigits = new List<byte>();
        LongInteger currentPart = Zero;

        for (int i = absDividend._digits.Count - 1; i >= 0; i--)
        {
            iterations++;
            currentPart = currentPart.ShiftLeft(1);
            LongInteger nextDigitValue = new LongInteger((long)absDividend._digits[i]);
            currentPart = currentPart + nextDigitValue;

            int digitCount = 0;
            while (currentPart >= absDivisor)
            {
                iterations++;
                currentPart -= absDivisor;
                digitCount++;
            }
            quotientDigits.Add((byte)digitCount);
        }

        quotientDigits.Reverse();

        LongInteger finalQuotient = new LongInteger(quotientDigits, finalQuotientNegative);
        LongInteger finalRemainder = new LongInteger(new List<byte>(currentPart._digits), finalRemainderNegative);
        if (finalRemainder.IsZero)
        {
            finalRemainder = Zero;
        }
        else if (finalRemainder._isNegative != dividend._isNegative)
        {
            finalRemainder = new LongInteger(new List<byte>(finalRemainder._digits), dividend._isNegative, true);
        }

        LastOperationIterations = iterations;
        return (finalQuotient, finalRemainder);
    }

    public static LongInteger Pow(LongInteger baseVal, LongInteger exponent)
    {
        long iterations = 0;
        if (baseVal is null) throw new ArgumentNullException(nameof(baseVal));
        if (exponent is null) throw new ArgumentNullException(nameof(exponent));

        if (exponent < Zero)
            throw new ArgumentOutOfRangeException(nameof(exponent), "Степінь не може бути від'ємною для LongInteger.Pow.");

        if (exponent.IsZero) { LastOperationIterations = iterations; return One; }
        if (baseVal.IsZero) { LastOperationIterations = iterations; return Zero; }
        if (baseVal == One) { LastOperationIterations = iterations; return One; }
        if (baseVal == MinusOne)
        {
            LastOperationIterations = iterations;
            return exponent.IsEven() ? One : MinusOne;
        }


        int exponentIntValue;
        try
        {
            exponentIntValue = int.Parse(exponent.ToString());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Внутрішня помилка при конвертації показника степеня. Степінь має бути в межах від 0 до 2147483647", ex);
        }

        const long COMPUTATIONAL_COMPLEXITY_THRESHOLD = 500000;

        if (baseVal.Abs() > One)
        {
            long estimatedComplexity = (long)baseVal._digits.Count * exponentIntValue;
            if (estimatedComplexity > COMPUTATIONAL_COMPLEXITY_THRESHOLD)
            {
                throw new ArgumentOutOfRangeException(nameof(exponent),
                    $"Обчислення {baseVal.ToString()} ^ {exponent.ToString()} оцінюється як надто складне або призведе до надто великого результату (фактор складності: {estimatedComplexity} > {COMPUTATIONAL_COMPLEXITY_THRESHOLD}). Зменшіть основу або показник степеня.");
            }
        }

        LongInteger result = One;
        LongInteger currentPower = baseVal;
        LongInteger exp = new LongInteger(new List<byte>(exponent._digits), exponent._isNegative, false);

        while (exp > Zero)
        {
            iterations++;
            if (exp.IsOdd())
            {
                result *= currentPower;
            }
            if (exp > One)
            {
                currentPower *= currentPower;
            }
            exp /= Two;
        }
        LastOperationIterations = iterations;
        return result;
    }

    private bool IsEven()
    {
        if (IsZero) return true;
        return (_digits[0] % 2 == 0);
    }
    private bool IsOdd()
    {
        if (IsZero) return false;
        return (_digits[0] % 2 != 0);
    }

    public static LongInteger Factorial(int n)
    {
        long iterations = 0;
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Факторіал не визначений для від'ємних чисел.");
        if (n == 0 || n == 1) { LastOperationIterations = iterations; return One; }
        if (n > 30000)
            throw new ArgumentOutOfRangeException(nameof(n), "Факторіал занадто великий для обчислення LongInteger. Максимальне значення - 30000");

        LongInteger result = One;
        for (int i = 2; i <= n; i++)
        {
            iterations++;
            result *= new LongInteger(i);
        }
        LastOperationIterations = iterations;
        return result;
    }
    #endregion
}
