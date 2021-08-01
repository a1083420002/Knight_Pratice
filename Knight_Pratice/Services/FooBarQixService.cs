using Knight_Pratice.Interfaces;
using Knight_Pratice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;

namespace Knight_Pratice.Services
{
    public class FooBarQixService : IDateService
    {
        private readonly IInputService _inputService;
        private readonly ICacheService _cacheService;
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;

        public FooBarQixService(IInputService inputService, IDataRepository dataRepository, ICacheService cacheService, IMapper mapper)
        {
            _inputService = inputService;
            _dataRepository = dataRepository;
            _cacheService = cacheService;
            _mapper = mapper;
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

            var querySingleResult = _dataRepository.GetAll<Data>().FirstOrDefault(n=>n.Data_Input==input.ToString());
            if (querySingleResult != default)
            {
                return new Number.NumberSingleResult { Number =Int32.Parse(querySingleResult.Data_Input),Result = querySingleResult.Data_Result};
            }

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
                
            var createData = new Data { Data_Input = result.Number.ToString(),Data_Result = result.Result.ToString()};
                
            _dataRepository.Create<Data>(createData);
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


            var result = _cacheService.GetData<Number.NumberSingleResult>(key);

            if (result == null)
            {
                var random = GetRandom();

                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5));
                _cacheService.InsertData<Number.NumberSingleResult>(key, random, options);

                result = random;
            }

            


            return result;
        }

        public DataEntity GetDataEntity(int input)
        {
            var querySingleResult = _dataRepository.GetAll<Data>().FirstOrDefault(n => n.Data_Input == input.ToString());
            if (querySingleResult != default)
            {
                var entity = _mapper.Map<DataEntity>(querySingleResult);
                return entity;
            }
            int value = _inputService.GetValue(input);
            var result = new DataEntity
            {
                Input = input.ToString()
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

            var createData = new Data { Data_Input = result.Input, Data_Result = result.Result.ToString() };

            _dataRepository.Create<Data>(createData);
            return result;

        }





    }
}
