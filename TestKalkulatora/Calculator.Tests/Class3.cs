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
    public class Calculator_dtests
    {
        [Fact]
        public void division_two_positive_integers()
        {
            // arange
            var x = 10;
            var y = 5;
            var calc = new ExampleCalculator();
            // act
            var result = calc.division(x, y);
            // assert
            Assert.Equal(2, result);
        }
    }
}
