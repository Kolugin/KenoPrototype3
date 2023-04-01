using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        const int NUM_COMBINATIONS = 6;
        const int NUM_ELEMENTS = 60;
        static void Main(string[] args)
        {
            int[] combination = new int[NUM_COMBINATIONS];

            Console.WriteLine("All combinations of 6 numbers from 1 to 60:");

            GenerateCombinations(0, NUM_COMBINATIONS, NUM_ELEMENTS, combination);
        }

        static void GenerateCombinations(int index, int k, int n, int[] combination)
        {
            if (index == k)
            {
                Console.Write("Combination: ");
                for (int i = 0; i < k; i++)
                {
                    Console.Write(combination[i] + " ");
                }
                Console.WriteLine();
                SaveCombinationToFile(combination, index + 1);
                return;
            }
            int start = 1;
            if (index > 0)
            {
                start = combination[index - 1] + 1;
            }
            for (int i = start; i <= n - k + index + 1; i++)
            {
                combination[index] = i;
                GenerateCombinations(index + 1, k, n, combination);
            }
        }

        static void SaveCombinationToFile(int[] combination, int index)
        {
            using (StreamWriter writer = new StreamWriter("combination_" + (index + 1) + ".txt", true))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Combination " + (index + 1) + ": ");
                for (int i = 0; i < combination.Length; i++)
                {
                    sb.Append(combination[i] + " ");
                }
                writer.WriteLine(sb.ToString());
            }
        }
    }
}
