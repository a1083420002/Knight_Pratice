using Knight_Pratice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.Interfaces
{
    public interface IDateService
    {
        Task<Number.NumberSingleResult> GetResultAsync(int input);//GetData//GetDataWithProvider()

        public Number.NumberSingleResult GetResult(int input);
        public Number.NumberSingleResult GetResult();

        public Number.NumberSingleResult GetRandom();
    }
}
