using NumberToWordConverter;
using NumericWordsConversion;
using Services.Converter.NumeralToWordConverter;
using System;


namespace Tests
{
    public class Tests
    {
        private NumeralToWordConverterService service;
        private CurrencyWordsConverter converter;
        private Random random;

        [SetUp]
        public void Setup()
        {
            random = new Random();
            service = new NumeralToWordConverterService();
            converter = new CurrencyWordsConverter(new CurrencyWordsConversionOptions()
            {
                Culture = Culture.International,
                OutputFormat = OutputFormat.English,
                CurrencyUnitSeparator = "and",
                CurrencyUnit = "dollars",
                SubCurrencyUnit = "cents",
                EndOfWordsMarker = "",
            });
        }

        //compare my results to a nuget package results
        [Test]
        public void TestRandomNumbers()
        {
            double[] randomDoubles = GenerateRandomDoubles(1000);
            foreach (double number in randomDoubles) 
            {
                string result = service.ToWord(number).ToLower().Trim().Replace("  ", " "); ;
                decimal decimalValue = (decimal)number;
                string compareTo = converter.ToWords(decimalValue).ToLower().Trim().Replace("  ", " ");

                Assert.That(compareTo, Is.EqualTo(result));
            }
        }

        [Test]
        public void TestAllNumbers()
        {
            for (double i = 1; i < 999999999.99; i = Math.Round(i + 0.05, 2))
            {
                string result = service.ToWord(i).ToLower().Trim().Replace("  ", " "); ;
                decimal decimalValue = (decimal)i;
                string compareTo = converter.ToWords(decimalValue).ToLower().Trim().Replace("  ", " ");

                Assert.That(compareTo, Is.EqualTo(result));
            }
        }

        private double[] GenerateRandomDoubles(int count)
        {
            double[] items = new double[count];
            for (int i = 0; i < count; i++)
            {
                var rDouble = random.NextDouble();
                var rRangeDouble = Math.Round(rDouble * (999999999.99 - 1) + 1, 2);
                items[i] = rRangeDouble;
            }

            return items;

        }
    }
}