﻿using System;
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
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());

            var calc = new ExampleCalculator();
            var result = calc.Add(x, y);

            Console.WriteLine(result);
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
    }
}