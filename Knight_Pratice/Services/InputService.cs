using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;

namespace Knight_Pratice.Services
{
    public class InputService : IInputService
    {
        public Task<int> GetValue(int input)
        {
             
           

            return Task.Run(() => input);
        }
    }
}
