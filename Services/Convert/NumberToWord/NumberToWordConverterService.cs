﻿using Core.Interface.Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Convert.NumberToWord
{
    public class NumberToWordConverterService : INumberToWordService
    {
        private readonly static Dictionary<int, string> Units = new ()
        {
            { 0, "zero" },{ 1, "one" },{ 2, "two" },{ 3, "three" },{ 4, "four" },{ 5, "five" },{ 6, "six" },{ 7, "seven" },{ 8, "eight" },{ 9, "nine" },
            { 10, "ten" },{ 11, "eleven" },{ 12, "twelve" },{ 13, "thirteen" },{ 14, "fourteen" },{ 15, "fifteen" },{ 16, "sixteen" },{ 17, "seventeen" },{ 18, "eighteen" },{ 19, "nineteen" },
        };

        private readonly static Dictionary<int, string> Tens = new ()
        {
            { 20, "twenty" }, { 30, "thirty" }, { 40, "forty" }, { 50, "fifty" }, { 60, "sixty" }, { 70, "seventy" }, { 80, "eighty" }, { 90, "ninety" }
        };

        public string ToWord(double number)
        {
            int integerPart = (int) Math.Floor(number);
            int decimalPart = (int) Math.Round((number - integerPart) * 100);

            string word = ConvertNumber(integerPart) + " dollars";

            if (decimalPart > 0)
            {
                word += $" and {ConvertNumber(decimalPart)} cents";
            }

            return word;
        }

        private string ConvertNumber(int number)
        {
            if (number == 0)
                return Units[0];

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += ConvertNumber(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertNumber(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertNumber(number / 100) + " hundred ";
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
    }
}
