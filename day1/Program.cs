using System;
using System.Diagnostics;
namespace Program
{
    class Program
    {
        static int CountDepth(int[] input)
        {
            int depth = 0;
            Console.WriteLine($"{input[0]} (no previous measurement)");
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > input[i - 1])
                {
                    Console.WriteLine($"{input[i]} (increased)");
                    depth++;
                }
                else
                {
                    Console.WriteLine($"{input[i]} (not increased)");
                }
            }
            return depth;
        }

        static int[] RollingSum(int[] input, int window)
        {
            int output_length = input.Length - window + 1;
            int[] output = new int[output_length];
            for (int i = 0; i < output_length; i++)
            {
                output[i] = input[i..(i + window)].Sum();
            }
            return output;
        }


        static int[] ToArray(string[] input)
        {
            int i = 0;
            return (from s in input where int.TryParse(s, out i) select i).ToArray();
        }

        static void Part1Test(int[] input)
        {
            int depth = CountDepth(input);
            Console.WriteLine(depth);
            Debug.Assert(depth == 7);
        }


        static void Part1()
        {
            string[] raw = System.IO.File.ReadAllLines("input.txt");
            int[] input = ToArray(raw);
            int depth = CountDepth(input);
            Console.WriteLine(depth);
        }

        static void Part2Test(int[] test_input)
        {
            int[] rolling_sum = RollingSum(test_input, 3);
            int depth = CountDepth(rolling_sum);
            Debug.Assert(depth == 5);
        }
        static void Part2()
        {
            string[] raw = System.IO.File.ReadAllLines("input.txt");
            int[] input = ToArray(raw);
            int[] rolling_sum = RollingSum(input, 3);
            int depth = CountDepth(rolling_sum);
            Console.WriteLine(depth);
        }

        static void Main(string[] args)
        {
            string[] test_raw = @"199
                200
                208
                210
                200
                207
                240
                269
                260
                263".Replace(" ", "").Split("\n");
            int[] test_input = ToArray(test_raw);

            // Part1Test(test_input);
            // Part1();
            // Part2Test(test_input);
            Part2();
        }
    }

}
