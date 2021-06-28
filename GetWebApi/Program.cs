using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GetWebApi
{
    internal class Program
    {
        //private static readonly string url="http://localhost:5000/api/Employees" ;
        private static readonly string url2= "http://localhost:5000/api/Numbers/";
        

        private  static void Main(string[] args)
        {
            //Run(url);
            Console.WriteLine("以Http Get 的方式呼叫API");
            Console.WriteLine("請輸入任意數字");
            InputNumber();
            Console.ReadKey();
        }
        /// <summary>
        /// 非同步的方式呼叫Controller API
        /// </summary>
        /// <param name="url">NumberController API Url</param>
        private static async Task RunNumber(string url)
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
                    {
                        Console.WriteLine(resultObj.Result);
                        
                    }
                        
                        
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
        private async static Task InputNumber()
        {
            while(true)
            {

                string input = Console.ReadLine();
                try
                {
                    
                    var num=Int32.Parse(input);

                    //回傳 0 ~ max 整數
                    //for (int i = 0; i <= num; i++)
                    //{
                    //    string urlParams = url2 + i.ToString();

                    //    await RunNumber(urlParams);
                    //    Thread.Sleep(1000);

                    //}

                    string urlParams = url2 + input;

                    await RunNumber(urlParams);

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
