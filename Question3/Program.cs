using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********* Frequency Application ************");
            List<int> firstIds = new List<int>();
            List<int> secondIds = new List<int>();
            List<int> missingIds = new List<int>();


            Console.WriteLine("Enter the length of your first list");
            var firstArrayLength = Console.ReadLine();
            Console.WriteLine("Enter your list of numbers separated by a space");
            var firstArrayString = Console.ReadLine();           

            string[] firstString = firstArrayString.Split(' ');

            foreach (var item in firstString) {
                firstIds.Add(int.Parse(item));
            }

            var firstListFrequency = firstIds.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            Console.WriteLine("Enter the length of your second list");
            var secondArrayLength = Console.ReadLine();
            Console.WriteLine("Enter your list of numbers separated by a space");
            var secondArrayString = Console.ReadLine();
            string[] secondString = secondArrayString.Split(' ');

            foreach (var item in secondString)
            {
                secondIds.Add(int.Parse(item));
            }

            var maxNum = secondIds.Max();
            var minNum = secondIds.Min();

            if (maxNum - minNum <= 100 && minNum > 0)
            {
                var secondListFrequency = secondIds.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

                foreach (var item in firstListFrequency)
                {
                    if (secondListFrequency.ContainsKey(item.Key))
                    {
                        var second = secondListFrequency.Where(x => x.Key == item.Key).Select(x => x.Value);

                        if (item.Value.ToString() != second.ToString())
                        {
                            missingIds.Add(Convert.ToInt32(item.Key));
                        }
                    }
                }
                Console.WriteLine("Missing numbers are below : ");
                foreach (var item in missingIds)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Second list of integers need to have a diffrence not more than 100 between the max and min numbers");
            }

            Console.ReadKey();

        }
    }
}
