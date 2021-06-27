using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knight_Pratice.Models;

namespace Knight_Pratice_Tests
{
    public class NumberTestData
    {
        public static IEnumerable<object[]> FizzBuzzTestData { get; } = new List<object[]>
        {
            new object[]{ 3, "Fizz"},
            new object[]{ 5, "Bizz"},
            new object[]{15,"FizzBizz"},
            new object[]{100,"Bizz"},
            new object[]{1, "1"},
        };

        public static IEnumerable<object[]> FooBarQixTestDataList { get; } = new List<object[]>
        {
            new object[] {1, "1"},
            new object[] {3, "FooFoo"},
            new object[] {4, "4"},
            new object[] {5, "BarBar"},
            new object[] {7, "QixQix"},
            new object[] {33, "FooFooFoo"},
            new object[] {53, "BarFoo"},
        };
    }
}
