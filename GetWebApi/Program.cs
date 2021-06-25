using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetWebApi
{
    internal class Program
    {
        private static readonly string url="http://localhost:5000/api/Employees" ;
        private static readonly string url2= "http://localhost:5000/api/Numbers/";
        private static readonly string url3= "http://localhost:5000/api/FooBarQix/";

        private static void Main(string[] args)
        {
            //Run(url);
            Console.WriteLine("以Http Get 的方式呼叫API");
            Console.WriteLine("請輸入任意數字");
            
            //string input = Console.ReadLine();
            //string urlParams = url2 + input;
            //Run(urlParams);
            InputNumber();
            Console.ReadKey();
        }
        /// <summary>
        /// 非同步的方式呼叫Controller API
        /// </summary>
        /// <param name="url">NumberController API Url</param>
        private static async void RunNumber(string url)
        {
            
            using (HttpClient client=new HttpClient())
            {
                try
                {
                    client.Timeout = TimeSpan.FromSeconds(50);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var resultObj = JsonConvert.DeserializeObject<NumberObj>(responseBody);
                    if (resultObj != null) 
                        Console.WriteLine(resultObj.Result);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine($"Message :{e.Message} ");
                }
            }
        }
        /// <summary>
        /// 非同步的方式呼叫EmployeeController API
        /// </summary>
        /// <param name="url">EmployeeController API Url</param>
        //private static async void Run(string url)
        //{

        //    using (HttpClient client = new HttpClient())
        //    {
        //        try
        //        {
        //            client.Timeout = TimeSpan.FromSeconds(50);
        //            HttpResponseMessage response = await client.GetAsync(url);
        //            response.EnsureSuccessStatusCode();
        //            var responseBody = await response.Content.ReadAsStringAsync();
        //            var resultObj = JsonConvert.DeserializeObject<NumberObj>(responseBody);
        //            if (resultObj != null) 
        //                Console.WriteLine(resultObj.Result);
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine("\nException Caught!");
        //            Console.WriteLine($"Message :{e.Message} ");
        //        }
        //    }
        //}
        /// <summary>
        /// 輸入某一數字，先判斷是否為數字，再呼叫API
        /// </summary>
        private static void InputNumber()
        {
            while(true)
            {

                string input = Console.ReadLine();
                try
                {
                    
                    Int32.Parse(input);
                    //string urlParams = url2 + input;
                    string urlParams = url3 + input;
                    RunNumber(urlParams);
                }
                catch
                {
                    Console.WriteLine("請重新輸入一個數字");
                    
                }
                

            }
            // ReSharper disable once FunctionNeverReturns
        }

        public class NumberObj
        {
            public int Number { get; set; }
            public string Result { get; set; }
        }
    }
}
