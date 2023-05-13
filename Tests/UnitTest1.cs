using NumericWordsConversion;
using Services.Convert.NumberToWord;

namespace Tests
{
    public class Tests
    {
        private NumberToWordConverterService service;
        private CurrencyWordsConverter converter;
        private Random random;

        [SetUp]
        public void Setup()
        {
            service = new NumberToWordConverterService();
            random = new Random();
            converter = new CurrencyWordsConverter(new CurrencyWordsConversionOptions()
            {
                Culture = Culture.International,
                OutputFormat = OutputFormat.English,
                CurrencyUnitSeparator = "and",
                CurrencyUnit = "dollars",
                SubCurrencyUnit = "cents",
                EndOfWordsMarker = ""
            });
        }

        [Test]
        public void TestRandomNumbers()
        {
            double[] numbers = GetRandomNumbers(1000, 0, 999999999.99);
            string word = "";
            string compareTo = "";
            foreach (double number in numbers)
            {
                word = service.ToWord(number).ToLower().Trim().Replace("  ", " ");
                compareTo = converter.ToWords((decimal)number).ToLower().Trim().Replace("  ", " ");
                Assert.That(word, Is.EqualTo(compareTo));
            }
        }

        private double[] GetRandomNumbers(int count, double min, double max)
        {
            double[] numbers = new double[count];
            for (int i = 0; i < count; i++)
            {
                double rNumber = random.NextDouble();
                rNumber = Math.Round(rNumber * (max - min) + min, 2);
                numbers[i] = rNumber;
            }

            return numbers;
        }
    }
}