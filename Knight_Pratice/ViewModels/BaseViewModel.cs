using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.ViewModels
{
    public class BaseViewModel
    {
        public class BaseResult<T>
        {
            public BaseResult()
            {
                IsSuccess = true;
            }
            public T Body { get; set; }
            public bool IsSuccess { get; set; }
            public string Msg { get; set; }
        }
        
    }
}
