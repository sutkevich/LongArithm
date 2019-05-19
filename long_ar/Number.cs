using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace long_ar
{
    public class Number
    {
        private List<byte> digits;
        private bool negative;
        private int rang;
        private Number(string number)
        {
            digits = new List<byte>();
            for (int i = number.Length - 1; i > 0; --i)
            {
                digits.Add(Convert.ToByte(number[i]-48));
            }

            if (number[0] == '-')
            {
                negative = true;
            }
            else
            {
                negative = false;
                digits.Add(Convert.ToByte(number[0]-48));
            }

            rang = digits.Count;
        }
        
        public override string ToString()
        {
            var finish = "";
            if (negative)
            {
                finish += '-';
            }
            for (int i = digits.Count - 1; i >= 0; --i)
            {
                finish += digits[i];
            }
            return finish;
        }
        
        public static implicit operator Number(string val)
        {
            return new Number(val);
        }

        public static Number operator+(Number num1, Number num2)
        {
            return new Number(Add(num1,num2));
        }
        public static Number operator-(Number num1, Number num2)
        {
            return new Number(subtraction(num1,num2));
        }
        public static Number operator*(Number num1, Number num2)
        {
            return new Number(multiplication(num1,num2));
        }
        public static Number operator/(Number num1, Number num2)
        {
            return new Number(split(num1,num2));
        }
        public static Number operator%(Number num1, Number num2)
        {
            return new Number(residueSplit(num1,num2));
        }

        private static string Add(Number num1, Number num2)
        {
            int rang;
            int highrang;
            bool drift = false;
            int buf;
            string rezalt = "";
            Number _num1 = new Number(StringConvert(num1));
            Number _num2 = new Number(StringConvert(num2));
            Number bigger = _num1;
            Number lower = _num2;
            if (num1.rang > num2.rang)
            {
                rang = _num2.rang;
                highrang = _num1.rang;
                bigger = _num1;
                lower = _num2;
            }
            else if (num1.rang < num2.rang)
            {
                rang = _num1.rang;
                highrang = _num2.rang;
                bigger = _num2;
                lower = _num1;
            }
            else
            {
                int i = 0;
                rang = _num1.rang;
                highrang = rang;
                do
                {
                    if (_num1.digits[i] > _num2.digits[i])
                    {
                        bigger = _num1;
                        lower = _num2;
                    }
                    else if (_num1.digits[i] < _num2.digits[i])
                    {
                        bigger = _num2;
                        lower = _num1;
                    }
                    ++i;
                }
                while (_num1.digits[i] == _num2.digits[i] && i + 1 < _num1.digits.Count);
                if (i == _num1.digits.Count)
                {
                    bigger = _num1;
                    lower = _num2;
                }

            }
            if (_num1.negative == _num2.negative)
            {
                for (int i = 0; i < rang; ++i)
                {
                    buf = _num1.digits[i] + _num2.digits[i];
                    if (drift)
                    {
                        buf++;
                        drift = false;
                    }
                    if (buf / 10 > 0)
                    {
                        drift = true;
                        buf %= 10;
                    }
                    rezalt += buf;
                }

                for (int i = rang; i < highrang; ++i)
                {
                    buf = bigger.digits[i];
                    if (drift)
                    {
                        buf++;
                        drift = false;
                    }
                    if (buf / 10 > 0)
                    {
                        drift = true;
                        buf %= 10;
                    }
                    rezalt += buf;
                }
    
                if (_num1.negative)
                {
                    rezalt += '-';
                }

                string finish = "";
                for (int i = rezalt.Length - 1; i >= 0; --i)
                {
                    finish += rezalt[i];
                }

                return finish;
            }
            else
            {
                for (int i = 0; i < rang; ++i)
                {
                    buf = bigger.digits[i] - lower.digits[i];
                    if (drift)
                    {
                        buf--;
                        drift = false;
                    }
                    if (buf < 0)
                    {
                        buf += 10;
                        drift = true;
                    }

                    rezalt += buf;
                }

                for (int i = rang; i < highrang; ++i)
                {
                    buf = bigger.digits[i];
                    if (drift)
                    {
                        buf--;
                        drift = false;
                    }
                    if (buf < 0)
                    {
                        buf += 10;
                        drift = true;
                    }

                    rezalt += buf;
                }

                while ((rezalt[rezalt.Length - 1]) == '0' && rezalt.Length > 1)
                {
                    rezalt = rezalt.Remove(rezalt.Length - 1);
                }
                    
                if (bigger.negative)
                {
                    rezalt += '-';
                }

                string finish = "";
                for (int i = rezalt.Length - 1; i >= 0; --i)
                {
                    finish += rezalt[i];
                }

                return finish;
            }
        }

        private static string subtraction(Number num1, Number num2)
        {
            Number _num1 = new Number(StringConvert(num1));
            Number _num2 = new Number(StringConvert(num2));
            if (num2.negative)
            {
                _num2.negative = false;
            }
            else
            {
                _num2.negative = true;
            }
            return Add(_num1, _num2);
        }

        private static string multiplication(Number num1, Number num2)
        {
            Number _num1 = new Number(StringConvert(num1));
            Number _num2 = new Number(StringConvert(num2));
            Number bigger = _num1;
            Number lower = _num2;
            bool drift = false;
            int core = 0;
            int buf;
            if (num1.rang > num2.rang)
            {
                bigger = _num1;
                lower = _num2;
            }
            else if (num1.rang < num2.rang)
            {
                bigger = _num2;
                lower = _num1;
            }
            else
            {
                int i = 0;
                do
                {
                    if (_num1.digits[i] > _num2.digits[i])
                    {
                        bigger = _num1;
                        lower = _num2;
                    }
                    else if (_num1.digits[i] < _num2.digits[i])
                    {
                        bigger = _num2;
                        lower = _num1;
                    }
                    ++i;
                }
                while (_num1.digits[i] == _num2.digits[i] && i + 1 < _num1.digits.Count);
                if (i == _num1.digits.Count)
                {
                    bigger = _num1;
                    lower = _num2;
                }
            }
            int[,] matrix = new int[lower.digits.Count, bigger.digits.Count + lower.digits.Count];
            for (int i = 0; i < lower.digits.Count; ++i)
            {
                for(int j = 0; j < bigger.digits.Count; ++j)
                {
                    buf = bigger.digits[j] * lower.digits[i];
                    if (drift)
                    {
                        buf += core;
                        drift = false;
                        core = 0;
                    }
                    if (buf / 10 > 0)
                    {
                        drift = true;
                        core = buf / 10;
                    }
                    buf %= 10;
                    matrix[i, j + i] = buf;
                }
            }
            matrix[lower.digits.Count - 1, bigger.digits.Count + lower.digits.Count - 1] = core;
            core = 0;
            buf = 0;
            drift = false;
            string rezalt = "";
            string finish = "";
            for (int i = 0; i < bigger.digits.Count + lower.digits.Count; ++i)
            {
                for (int j = 0; j < lower.digits.Count; ++j)
                {
                    buf += matrix[j, i];    //поменял
                }
                if (drift)
                {
                    buf += core;
                    drift = false;
                    core = 0;
                }
                if (buf / 10 > 0)
                {
                    drift = true;
                    core = buf / 10;
                }
                buf %= 10;
                rezalt += buf;
                buf = 0;
            }
            if (bigger.negative != lower.negative)
            {
                finish = "-";
            }
            for (int i = rezalt.Length - 1; i >= 0; --i)
            {
                finish += rezalt[i];
            }
            return finish;
        }

        private static string split(Number num1, Number num2)
        {
            return null;
        }

        private static string residueSplit(Number num1, Number num2)
        {
            return null;
        }
        private static string StringConvert (Number num)
        {
            var finish = "";
            if (num.negative)
            {
                finish += '-';
            }
            for (int i = num.digits.Count - 1; i >= 0; --i)
            {
                finish += num.digits[i];
            }
            return finish;
        }
    }
}