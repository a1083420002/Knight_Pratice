using Knight_Pratice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.Interfaces
{
    public interface IDateService
    {
        Task<Number.NumberSingleResult> GetNumber(int num);//GetData//GetDataWithProvider()
    }
}
