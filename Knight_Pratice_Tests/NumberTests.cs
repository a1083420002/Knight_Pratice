using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using Knight_Pratice.Services;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

namespace Knight_Pratice_Tests
{
    public class NumberTests
    {
        
        private readonly FizzBuzzService _fizzBuzzService;
        private readonly IDateService _sut;
        private readonly ITestOutputHelper _testOutput;
        private readonly IInputService _inputService = Substitute.For<IInputService>();
        public NumberTests( ITestOutputHelper testOutput)
        {
            
            _fizzBuzzService = new FizzBuzzService();
            _testOutput = testOutput;
            _sut = new FooBarQixService(_inputService);
        }
        
        [Theory]

        [MemberData(nameof(NumberTestData.FizzBuzzTestData), MemberType = typeof(NumberTestData))]
        
        public async Task FizzBuzzShould(int num, string expected)
        {
            //// Arrange
            
            
            //// Act
            var actual = await _fizzBuzzService.GetResult(num);
            //// Assert
            Assert.Equal(expected, actual.Result);

            _testOutput.WriteLine($"The result is {actual.Result}");
        }

        [Theory]

        [MemberData(nameof(NumberTestData.FooBarQixTestDataList), MemberType = typeof(NumberTestData))]
        
        public async Task FooBarQixShould(int num, string expected)
        {
            //// Arrange
            _inputService.GetValue(num).Returns(num);
            //// Act
            var actual = await _sut.GetResult(num);
            //// Assert
            Assert.Equal(expected, actual.Result);


            _testOutput.WriteLine($"The result is {actual.Result}");
        }
    }
}
