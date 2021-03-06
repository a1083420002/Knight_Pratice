using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;

namespace Knight_Pratice.Services
{
    public class FizzBuzzService : IDateService
    {
        private readonly IInputService _inputService;

        public FizzBuzzService(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Number.NumberSingleResult GetResult(int input)
        {
            Number.NumberSingleResult result = new Number.NumberSingleResult();
            result.Number = input;
            string output = "";

            if (input % 3 == 0)
            {
                output += "Fizz";
                result.Result = output;
            }

            if (input % 5 == 0)
            {
                output += "Bizz";
                result.Result = output;
            }

            if (input % 3 != 0 && input % 5 != 0)
            {
                result.Result = input.ToString();
            }
            return result;
        }

        public Number.NumberSingleResult GetRandom()
        {
            var input = _inputService.GetValue();
            Number.NumberSingleResult result = new Number.NumberSingleResult();
            result.Number = input;
            string output = "";

            if (input % 3 == 0)
            {
                output += "Fizz";
                result.Result = output;
            }

            if (input % 5 == 0)
            {
                output += "Bizz";
                result.Result = output;
            }

            if (input % 3 != 0 && input % 5 != 0)
            {
                result.Result = input.ToString();
            }
            return result;
        }

        //private readonly INumberService _numberService;
        //public FizzBuzzService(INumberService numberService)
        //{
        //    _numberService = numberService;
        //}
        public Task<Number.NumberSingleResult> GetResultAsync(int input)
        {
            return Task.Run(() =>
            {
                Number.NumberSingleResult result = new Number.NumberSingleResult();
                result.Number = input;
                string output = "";

                if (input % 3 == 0)
                {
                    output += "Fizz";
                    result.Result = output;
                }

                if (input % 5 == 0)
                {
                    output += "Bizz";
                    result.Result = output;
                }

                if (input % 3 != 0 && input % 5 != 0)
                {
                    result.Result = input.ToString();
                }
                return result;
            });
        }

        public Number.NumberSingleResult GetResult()
        {
            var result = new Number.NumberSingleResult
            {
                Number = 1,Result = "1"
            };
            return result;
        }

        public DataEntity GetDataEntity(int input)
        {
            return new DataEntity() { Id = 1,Input = "1",Result = "1"};
        }
    }
}
