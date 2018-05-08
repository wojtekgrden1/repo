using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witamy na kursie");
            Console.WriteLine("Podaj zmienna x:");
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj zmienna y:");
            var y = int.Parse(Console.ReadLine());

            var calc = new ExampleCalculator();
            var result = calc.Add(x, y);

            Console.WriteLine("Wynik dodawania dwóch zmiennych: {0}",result);

            var result1 = calc.multiplication(x, y);

            Console.WriteLine("Wynik mnożenia dwóch zmiennych: {0}", result1);

            var result2 = calc.division(x, y);
            var result3 = calc.reversedivision(x, y);

            Console.WriteLine("Wynik dzielenia zmiennej x / y: {0}" + Environment.NewLine + "Wynik dzielenia zmiennej y / x: {1}", result2, result3);

            var result4 = calc.subtraction(x, y);
            var result5 = calc.reversesubtraction(x, y);

            Console.WriteLine("Wynik odejmowania x - y: {0}" + Environment.NewLine + "Wynik odejmowania y - x: {1}", result4, result5);


        }
    }

    public class ExampleCalculator
    {
        public ExampleCalculator()
        {
        }

        public int Add(int x, int y)
        {
            return x + y;
        }
        public int multiplication(int x, int y)
        {
            return x * y;
        }
        public double division(double x, double y)
        {
            return x / y;
        }
        public double reversedivision(double x, double y)
        {
            return y / x;
        }
        public int subtraction(int x, int y)
        {
            return x - y;
        }
        public int reversesubtraction(int x, int y)
        {
            return y - x;
        }
    }
}
