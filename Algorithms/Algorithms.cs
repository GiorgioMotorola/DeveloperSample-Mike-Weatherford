using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException($"{n} is a negative number");

            if (n == 0 || n == 1)
                return 1;

            return n * GetFactorial(n - 1);
        }

        public static string FormatSeparators(params string[] items)
        {

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (items.Length == 0)
                return string.Empty;

            if (items.Length == 1)
                return items[0];

            string separator = ", ";
            string lastSeparator = " and ";

            return string.Join(separator, items.Take(items.Length - 1)) + lastSeparator + items.Last();
        }
    }
}