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
        
        private readonly IDateService _dateService;
        private readonly ITestOutputHelper _output;
        public NumberTests( ITestOutputHelper output)
        {
            //_dateService = new FizzBuzzService();
            _dateService = new FooBarQixService();
            
            _output = output;
        }
        
        [Theory]
        //[MemberData(nameof(NumberTestData.FizzBuzzTestData), MemberType = typeof(NumberTestData))]
        [MemberData(nameof(NumberTestData.FooBarQixTestDataList), MemberType = typeof(NumberTestData))]
        public async void NumberShould(int num, string expected)
        {
            //// Arrange
            
            
            //// Act
            var actual = await _dateService.GetNumber(num);
            //// Assert
            Assert.Equal(expected, actual.Result);

            _output.WriteLine($"The result is {actual.Result}");
        }
    }
}
