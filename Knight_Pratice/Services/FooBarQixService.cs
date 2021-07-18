using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Knight_Pratice.Services
{
    public class FooBarQixService : IDateService
    {
        private readonly IInputService _inputService;


        public FooBarQixService(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Task<Number.NumberSingleResult> GetResultAsync(int input)
        {
            return Task.Run(() =>
            {

                    int value = _inputService.GetValue(input);
                    var result = new Number.NumberSingleResult
                    {
                        Number = value
                    };
                    string numStr = value.ToString();
                    string output = "";

                    if (value == 0)
                    {
                        result.Result = "0";
                        return result;
                    }
                    if (value % 3 == 0)
                    {
                        output += "Foo";

                    }
                    if (value % 5 == 0)
                    {
                        output += "Bar";

                    }
                    if (value % 7 == 0)
                    {
                        output += "Qix";

                    }


                    foreach (var numChar in numStr)
                    {
                        switch (numChar)
                        {
                            case '3':
                                output += "Foo";
                                break;
                            case '5':
                                output += "Bar";
                                break;
                            case '7':
                                output += "Qix";
                                break;
                        }

                    }
                    result.Result = output == "" ? numStr : output;


                    return result;
                
              
            });
        }

        public Number.NumberSingleResult GetResult(int input)
        {
            

                int value = _inputService.GetValue(input);
                var result = new Number.NumberSingleResult
                {
                    Number = value
                };
                string numStr = value.ToString();
                string output = "";

                if (value == 0)
                {
                    result.Result = "0";
                    return result;
                }
                if (value % 3 == 0)
                {
                    output += "Foo";

                }
                if (value % 5 == 0)
                {
                    output += "Bar";

                }
                if (value % 7 == 0)
                {
                    output += "Qix";

                }


                foreach (var numChar in numStr)
                {
                    switch (numChar)
                    {
                        case '3':
                            output += "Foo";
                            break;
                        case '5':
                            output += "Bar";
                            break;
                        case '7':
                            output += "Qix";
                            break;
                    }

                }
                result.Result = output == "" ? numStr : output;


                return result;


           
        }

        public Number.NumberSingleResult GetRandom()
        {


            int value = _inputService.GetValue();
            var result = new Number.NumberSingleResult
            {
                Number = value
            };
            string numStr = value.ToString();
            string output = "";

            if (value == 0)
            {
                result.Result = "0";
                return result;
            }
            if (value % 3 == 0)
            {
                output += "Foo";

            }
            if (value % 5 == 0)
            {
                output += "Bar";

            }
            if (value % 7 == 0)
            {
                output += "Qix";

            }


            foreach (var numChar in numStr)
            {
                switch (numChar)
                {
                    case '3':
                        output += "Foo";
                        break;
                    case '5':
                        output += "Bar";
                        break;
                    case '7':
                        output += "Qix";
                        break;
                }

            }
            result.Result = output == "" ? numStr : output;


            return result;



        }

        public Number.NumberSingleResult GetResult()
        {
            
            var key = "key";
            var result = GetRandom();

            //var result = _cacheService.GetData<Number.NumberSingleResult>(key);

            //if (result == null)
            //{
               
            //    result = _cacheService.InsertData();
            //}


            return result;
        }

         
    }
}
