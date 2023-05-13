using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Services.Converter.NumeralToWordConverter
{
    public class NumeralToWordConverterService : INumeralToWordConverterService
    {

        public static Dictionary<int, string> Units = new Dictionary<int, string>()
        {
            { 0, "zero" }, { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
            { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" }, { 11, "eleven" },
            { 12, "twelve" }, { 13 , "thirteen" }, { 14, "fourteen" }, { 15, "fifteen" }, { 16, "sixteen" },
            { 17, "seventeen" }, { 18 , "eighteen" }, { 19, "nineteen" }
        };

        public static Dictionary<int, string> Tens = new Dictionary<int, string>()
        {
            { 20, "twenty" }, { 30, "thirty" }, { 40, "forty" }, { 50 , "fifty" },
            { 60, "sixty" }, { 70, "seventy" }, { 80, "eighty" }, { 90, "ninety" },
            { 100, "hundred" }, { 1000, "thousand"}, { 1000000, "million"}
        };

        public string ToWord(Double value)
        {
            if (value == 0)
                return Units[0];

            int integerNumber = (int)Math.Truncate(value);
            int decimals = (int) Math.Round(((value - integerNumber) * 100));

            string word = NumberToWords(integerNumber) + " dollars";

            if (decimals > 0)
            {
                word += $" and {NumberToWords(decimals)} cents";
            }

            return word;
        }

        public string NumberToWords(int number)
        {
            string words = "";

            if (number == 0)
                return Units[0];

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {

                if (number < 20)
                    words += Units[number];
                else
                {
                    words += Tens[(number / 10) * 10];
                    if ((number % 10) > 0)
                        words += " " + Units[number % 10];
                }
            }

            return words;
        }

        //private void ConvertNumber(int i, ref string word)
        //{
        //    if (i < 20)
        //    {
        //        word += Units[i];
        //    }
        //    else if (i < 100)
        //    {
        //        word += Tens[(int)(i / 10) * 10];
        //        if (i % 10 > 0)
        //            ConvertNumber(i % 10, ref word);
        //    }
        //    else if (i < 1000)
        //    {
        //        word += Units[(int)(i / 100)] + " hundred";
        //        if (i % 100 > 0)
        //        {
        //            word += " and ";
        //            ConvertNumber(i % 100, ref word);
        //        }

        //    }
        //    else if (i < 100000)
        //    {
        //        ConvertNumber(i / 1000, ref word);
        //        word += " thousand ";
        //        if (i % 1000 > 0)
        //            ConvertNumber(i % 1000, ref word);
        //    }
        //    else if (i < 100000000)
        //    {

        //    }
        //    else if (i < 1000000000)
        //    {
        //        ConvertNumber(i / 10000000, ref word);
        //        word += " million ";
        //        if (i % 10000000 > 0)
        //            ConvertNumber(i % 100000000, ref word);
        //    }
        //}

        private (int n, int e) Decompose(double v)
        {
            int exp = 1;
            double res;
            while ((res = v / exp) > 10)
            {
                exp *= 10;
            }

            return ((int)res, exp);
        }
    }
}