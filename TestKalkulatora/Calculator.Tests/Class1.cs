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
    public class Calculator_tests
    {
        [Fact]
        public void Adding_two_positive_integers()
        {
            // arange
            var x = 5;
            var y = 10;
            var calc = new ExampleCalculator();
            // act
            var result = calc.Add(x, y);
            // assert
            Assert.Equal(15, result);
        }
        [Fact]
        public void multiplication_two_positive_integers()
        {
            // arange
            var x = 5;
            var y = 10;
            var calc = new ExampleCalculator();
            // act
            var result = calc.multiplication(x, y);
            // assert
            Assert.Equal(50, result);
        }
        [Theory, 
            InlineData(20,2,10),
            InlineData(1.5,2,0.75),
            InlineData(19, 2, 9.5),
            InlineData(20, 0, double.PositiveInfinity),
            InlineData(-20, 0, double.NegativeInfinity),
            InlineData(0,0,double.NaN)
            ]
        public void division_two_positive_integers(double x, double y, double expected)
        {
            // arange
            var calc = new ExampleCalculator();
            // act
            var result = calc.division(x, y);
            // assert
            Assert.Equal(expected, result);
        }
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
