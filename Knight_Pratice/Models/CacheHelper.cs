using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Knight_Pratice.Models
{
    public class CacheHelper
    {
        private static List<Number.NumberSingleResult> dataList = new List<Number.NumberSingleResult>();

        private static readonly string cachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache", "test.txt");

        private static readonly string SEP_STR = "---";

        public static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        static CacheHelper()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (File.Exists(cachePath))
            {
                string[] lines = File.ReadAllLines(cachePath, Encoding.UTF8);
                foreach (var line in lines)
                {
                    string[] lineArray = line.Split(new string[] { SEP_STR }, StringSplitOptions.None);
                    if (lineArray.Length == 3)
                    {
                        dataList.Add(new Number.NumberSingleResult()
                        {
                            Number = Convert.ToInt32(lineArray[0]),
                            Result = lineArray[0]
                        });
                    }
                }
            }
        }

        public static void AddNumber(Number.NumberSingleResult num)
        {
            lock (dataList)
            {
                var item = dataList.Find(p => p.Number == num.Number);
                if (item == null)
                {
                    dataList.Add(num);
                }
                else
                {
                    item.Number = num.Number;
                    item.Result = num.Result;
                }
                WriteFile();
            }
        }

        public static Number.NumberSingleResult GetInfo(int num)
        {
            lock (dataList)
            {
                return dataList.Find(p => p.Number == num);
            }
        }

        public static List<Number.NumberSingleResult> GetAll()
        {
            lock (dataList)
            {
                return dataList;
            }
        }

        private static void WriteFile()
        {
            StringBuilder content = new StringBuilder();
            foreach (var item in dataList)
            {
                content.AppendLine(item.Number + SEP_STR + item.Number );
            }
            File.WriteAllText(cachePath, content.ToString(), Encoding.UTF8);
        }
    }
}
