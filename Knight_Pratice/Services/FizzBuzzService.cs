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
        public Task<Number.NumberSingleResult> GetNumber(int num)
        {
            return Task.Run(() =>
            {
                Number.NumberSingleResult result = new Number.NumberSingleResult();
                result.Number = num;
                string output = "";

                if (num % 3 == 0)
                {
                    output += "Fizz";
                    result.Result = output;
                }

                if (num % 5 == 0)
                {
                    output += "Bizz";
                    result.Result = output;
                }

                if (num % 3 != 0 && num % 5 != 0)
                {
                    result.Result = num.ToString();
                }
                return result;
            });
        }
    }
}
