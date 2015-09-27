using System;
/*
 * A permutation is an ordered arrangement of objects.
 * For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
 * If all of the permutations are listed numerically or alphabetically, 
 * we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
 * 
 * 012   021   102   120   201   210
 * 
 * What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
 */
namespace PEProblem024
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartTime = DateTime.Now;
            
            int[] list = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int count = 1;

            while (count < 1000000)
            {
                int largestNumber = -1;
                for (int i = list.Length - 2; i >= 0; i--)
                {
                    if (list[i] < list[i + 1])
                    {
                        largestNumber = i;
                        break;
                    }
                }

                if (largestNumber > -1)
                {
                    int largestNumber2 = -1;
                    for (int i = list.Length - 1; i >= 0; i--)
                    {
                        if (list[largestNumber] < list[i])
                        {
                            largestNumber2 = i;
                            break;
                        }
                    }

                    int tmp = list[largestNumber];
                    list[largestNumber] = list[largestNumber2];
                    list[largestNumber2] = tmp;

                    for (int i = largestNumber + 1, j = list.Length - 1; i < j; i++, j--)
                    {
                        tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }

                }
                    count++;
            }

            string result = "";
            for (int i = 0; i < list.Length; i++)
            {
                result += list[i].ToString();
            }

            TimeSpan elapsedTime = DateTime.Now - StartTime;

            Console.WriteLine("result: " + result.ToString());
            Console.WriteLine("elapsed time: " + elapsedTime.ToString("mm':'ss':'fff") + " mm:ss:fff");
            Console.ReadLine();
        }
    }
}
