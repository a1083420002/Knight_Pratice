using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Knight_Pratice.Services;
using Moq;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace Knight_Pratice_Tests
{
    public class NumberTests
    {
        
        private readonly FizzBuzzService _fizzBuzzService;
        private readonly FooBarQixService _fooBarQixService;
        private readonly ITestOutputHelper _output;
        public NumberTests( ITestOutputHelper output)
        {
            //_dateService = new FizzBuzzService();
            _fizzBuzzService = new FizzBuzzService();
            _fooBarQixService = new FooBarQixService();
            _output = output;
        }
        
        [Theory]

        [MemberData(nameof(NumberTestData.FizzBuzzTestData), MemberType = typeof(NumberTestData))]
        
        public async void FizzBuzzShould(int num, string expected)
        {
            //// Arrange
            
            
            //// Act
            var actual = await _fizzBuzzService.GetResult(num);
            //// Assert
            Assert.Equal(expected, actual.Result);

            _output.WriteLine($"The result is {actual.Result}");
        }

        [Theory]
        
        [MemberData(nameof(NumberTestData.FooBarQixTestDataList), MemberType = typeof(NumberTestData))]
        public async void FooBarQixShould(int num, string expected)
        {
            //// Arrange


            //// Act
            var actual = await _fooBarQixService.GetResult(num);
            //// Assert
            Assert.Equal(expected, actual.Result);

            _output.WriteLine($"The result is {actual.Result}");
        }
    }
}
