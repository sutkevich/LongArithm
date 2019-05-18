using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace long_ar
{
    public class Number
    {
        public List<byte> digits;
        public bool negative;

        public void Insert(string number)
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
        }
        
        public override string ToString()
        {
            string finish = "";
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

    }
}