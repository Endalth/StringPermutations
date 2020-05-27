using System;
using System.Diagnostics;

namespace StringPermutations
{
    class Program
    {
        static void Permutations(string prefix, string word)
        {
            if (word.Length == 1)
            {
                Console.WriteLine(prefix + word);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                string current = word[i].ToString();
                string before = word[..i];
                string after = word[(i + 1)..];

                Permutations(prefix + current, before + after);
            }
        }

        static void PermutationsSecondWay(string str, int left, int right)
        {
            if (left == right)
                Console.WriteLine(str);

            for (int i = left; i < right; i++)
            {
                str = Swap(str, i, left);
                PermutationsSecondWay(str, left + 1, right);
                str = Swap(str, i, left);
            }
        }

        static string Swap(string str, int i, int left)
        {
            char[] tempArray = str.ToCharArray();
            char temp;
            temp = tempArray[i];
            tempArray[i] = tempArray[left];
            tempArray[left] = temp;
            return new string(tempArray);
        }
        static void Main(string[] args)
        {
            string text = "abcdefgh";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            Permutations("", text);
            Console.WriteLine("First Way: " + stopwatch.ElapsedMilliseconds + "ms");

            stopwatch.Restart();
            PermutationsSecondWay(text, 0, text.Length);
            Console.WriteLine("Second Way: " + stopwatch.ElapsedMilliseconds + "ms");
            stopwatch.Stop();

            Console.ReadKey();
        }
    }
}
