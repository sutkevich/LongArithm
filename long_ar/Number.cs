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
            Number bigger;
            Number lower;
            if (num1.rang >= num2.rang)
            {
                rang = num2.rang;
                highrang = num1.rang;
                bigger = num1;
                lower = num2;
            }
            else
            {
                rang = num1.rang;
                highrang = num2.rang;
                bigger = num2;
                lower = num1;
            }
            if (num1.negative == num2.negative)
            {
                for (int i = 0; i < rang; ++i)
                {
                    buf = num1.digits[i] + num2.digits[i];
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
    
                if (num1.negative)
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

                while ((rezalt[rezalt.Length - 1]) == '0')
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
            if (num2.negative)
            {
                num2.negative = false;
            }
            else
            {
                num2.negative = true;
            }
            return Add(num1, num2);
        }

        private static string multiplication(Number num1, Number num2)
        {
            return null;
        }

        private static string split(Number num1, Number num2)
        {
            return null;
        }

        private static string residueSplit(Number num1, Number num2)
        {
            return null;
        }
    }
}