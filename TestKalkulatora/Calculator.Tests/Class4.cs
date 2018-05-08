using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Calculator.Tests;
using Calculator;


namespace Calculator.Tests
{
    public class Calculator_stests
    {
        [Fact]
        public void subtraction_two_positive_integers()
        {
            // arange
            var x = 5;
            var y = 10;
            var calc = new ExampleCalculator();
            // act
            var result = calc.subtraction(x, y);
            // assert
            Assert.Equal(-5, result);
        }
    }
}