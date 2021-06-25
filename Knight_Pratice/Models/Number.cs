using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.Models
{
    public class Number
    {
        public class NumberBase
        {
            public int Number { get; set; }
            public string Result { get; set; }
        }
        public class NumberSingleResult:NumberBase
        {

        };
        public class NumberListResult
        {
            public List<NumberSingleResult> NumberList { get; set; }
        }
    }
}
