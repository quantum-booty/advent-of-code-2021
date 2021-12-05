using System;
using System.Diagnostics;
namespace Program
{
    class Program
    {
        static void Part1Test(int[] test_input)
        {
        }
        static void Part2()
        {
            string[] raw = System.IO.File.ReadAllLines("input.txt");
        }

        class Submarine
        {
            public int Horizontal { get; set; }
            public int Depth { get; set; }
            public int Aim { get; set; }

            public void Move(string direction, int length)
            {
                switch (direction)
                {
                    case "down":
                        Depth += length;
                        break;
                    case "up":
                        Depth -= length;
                        break;
                    case "backward":
                        Horizontal -= length;
                        break;
                    case "forward":
                        Horizontal += length;
                        break;
                }
            }

            public void MoveAim(string direction, int length)
            {
                switch (direction)
                {
                    case "down":
                        Aim += length;
                        break;
                    case "up":
                        Aim -= length;
                        break;
                    case "forward":
                        Horizontal += length;
                        Depth += Aim * length;
                        break;
                }
            }

        }

        static void Part1(string[] raw)
        {
            var s = new Submarine();

            foreach (var item in raw)
            {
                var instruction = item.Trim().Split(" ");
                string direction = instruction[0];
                int.TryParse(instruction[1], out int distance);
                s.Move(direction, distance);
            }
            Console.WriteLine(s.Horizontal);
            Console.WriteLine(s.Depth);
            Console.WriteLine($"result = {s.Horizontal * s.Depth}");
        }

        static void Part2(string[] raw)
        {
            var s = new Submarine();

            foreach (var item in raw)
            {
                var instruction = item.Trim().Split(" ");
                string direction = instruction[0];
                int.TryParse(instruction[1], out int distance);
                s.MoveAim(direction, distance);
            }
            Console.WriteLine(s.Horizontal);
            Console.WriteLine(s.Depth);
            Console.WriteLine($"result = {s.Horizontal * s.Depth}");
        }


        static void Main(string[] args)
        {
            string[] test_raw = @"forward 5
                down 5
                forward 8
                up 3
                down 8
                forward 2".Split("\n");

            string[] raw = System.IO.File.ReadAllLines("input.txt");

            Part1(test_raw);
            Part1(raw);

            Part2(test_raw);
            Part2(raw);
        }
    }

}
