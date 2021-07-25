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
        public int GetValue(int input)
        {
            
            return input;
        }

        public int GetValue()
        {
            Random random = new Random();
            int result = random.Next(100 + 1);
            return result;
        }
    }
}
