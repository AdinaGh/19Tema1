using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19Tema1
{
    class Program
    {
        static void Main(string[] args)
        {
            var abc = new GenericList<string>();
            abc.Add("1");
            abc.Add("2");
            abc.Add("555");
            abc[2] = "3";

            Console.WriteLine(abc.ToString());
            Console.WriteLine(abc[0]);
            Console.WriteLine(abc[2]);
            abc.RemoveByIndex(2);
            Console.WriteLine(abc.ToString());

            abc.Add("33");
            abc.Add("44");
            abc.Add("55");
            abc.Add("66");
            abc.Add("77");
            abc.Add("88");

            Console.WriteLine($"Max: {abc.Max()}");
            Console.WriteLine($"Min: {abc.Min()}");
            abc.AddAtIndex(0, "added");
            Console.WriteLine(abc.ToString());

            abc.AddAtIndex(9, "added2");
            Console.WriteLine(abc.ToString());


            Console.WriteLine($"Element found at index :{abc.Find("ddd222")}");
            Console.WriteLine($"Element found at index :{abc.Find("88")}");

            abc.Clear();
            Console.WriteLine($"Clear: {abc.Length}");


            TestErrors(abc);
        }

        private static void TestErrors(GenericList<string> abc)
        {
            Console.WriteLine();
            Console.WriteLine("Errors");
            var i = 0;
            try
            {
                i++;
                abc[233] = "5";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {i}:{ex.Message}");
            }

            try
            {
                i++;
                Console.WriteLine(abc[2333]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {i}:{ex.Message}");
            }

            try
            {
                i++;
                abc.RemoveByIndex(3333);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {i}:{ex.Message}");
            }
            try
            {
                i++;
                abc.RemoveByIndex(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {i}:{ex.Message}");
            }

            try
            {
                i++;
                abc.AddAtIndex(-1, "ddd");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {i}:{ex.Message}");
            }

            try
            {
                i++;
                abc.AddAtIndex(abc.Length, "nnn");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {i}:{ex.Message}");
            }

        }
    }
}
