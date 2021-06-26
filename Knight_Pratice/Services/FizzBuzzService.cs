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
        //private readonly INumberService _numberService;
        //public FizzBuzzService(INumberService numberService)
        //{
        //    _numberService = numberService;
        //}
        public Task<Number.NumberSingleResult> GetResult(int input)
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
    }
}
