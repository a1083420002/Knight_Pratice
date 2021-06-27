using Knight_Pratice.Interfaces;
using System;
using Knight_Pratice.Services;
using Xunit;
using NSubstitute;
using System.Threading.Tasks;
using Knight_Pratice.Models;
using Xunit.Abstractions;
using static Knight_Pratice.Models.Number;

namespace FooBarQixServiceTestNSub
{
    public class FooBarQixServiceTest
    {
        private readonly IDateService _sut;
        private readonly ITestOutputHelper _testOutput;
        private readonly IInputService _inputService = Substitute.For<IInputService>();
        
        public  FooBarQixServiceTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
            _sut = new FooBarQixService(_inputService);
        }

        [Fact]
        public async Task GetByInput_ShouldReturnResult()
        {
            ////Arrange
            int input = 0;
            string output = "0";
            _inputService.GetValue(input).Returns(input);
            ////Act
            var result = await _sut.GetResult(input);
            ////Assert
            Assert.Equal(output, result.Result);

            _testOutput.WriteLine($"The Result is {output}");
            
        }
    }
}
