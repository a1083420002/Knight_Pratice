using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Knight_Pratice.Services
{
    public class FooBarQixService : IDateService
    {
        public Task<Number.NumberSingleResult> GetResult(int input)
        {
            return Task.Run(() =>
            {
               
                    var result = new Number.NumberSingleResult
                    {
                        Number = input
                    };
                    string numStr = input.ToString();
                    string output = "";

                    if (input == 0)
                    {
                        result.Result = "0";
                        return result;
                    }
                    if (input % 3 == 0)
                    {
                        output += "Foo";

                    }
                    if (input % 5 == 0)
                    {
                        output += "Bar";

                    }
                    if (input % 7 == 0)
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
    }
}
