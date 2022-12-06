namespace AdventOfCode.ConsoleApp.Extensions
{
    public static class StringExtensions
    {
        public static string Alphabetize(this string s)
        {
            char[] a = s.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }
    }
}
