using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knight_Pratice.Models;

namespace Knight_Pratice.Interfaces
{
    public interface ICacheService
    {
        public Number.NumberSingleResult InsertData();

        public Number.NumberSingleResult GetData();

    }
}
