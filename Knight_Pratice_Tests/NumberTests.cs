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
        private readonly ICacheService _cacheService = Substitute.For<ICacheService>();
        private readonly IDataRepository _dataRepository = Substitute.For<IDataRepository>();
        public NumberTests( ITestOutputHelper testOutput)
        {
            
            _fizzBuzzService = new FizzBuzzService(_inputService);
            _testOutput = testOutput;
            _sut = new FooBarQixService(_inputService, _dataRepository,_cacheService);
        }
        
        [Theory]

        [MemberData(nameof(NumberTestData.FizzBuzzTestData), MemberType = typeof(NumberTestData))]
        
        public async Task FizzBuzzShould(int num, string expected)
        {
            //// Arrange
            
            
            //// Act
            var actual = await _fizzBuzzService.GetResultAsync(num);
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
            var actual = await _sut.GetResultAsync(num);
            //// Assert
            Assert.Equal(expected, actual.Result);


            _testOutput.WriteLine($"The result is {actual.Result}");
        }
    }
}
