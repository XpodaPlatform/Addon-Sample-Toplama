﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var assembly = Assembly.LoadFrom(@"C:\Users\Devran\source\repos\TestAddon\TestAddon\bin\Debug\TestAddon.dll");
            var type = assembly.GetType("TestAddon.TestClass");
            var method = type.GetMethod("SumOfValues");
            var paramss = new object[1];
            var paramlist = new List<Dictionary<string, object>>();
            paramlist.Add(new Dictionary<string, object>
            {
                {"x", "3" },
                {"y", "4" }
            });
            
            paramss[0] = paramlist;

            var obj = Activator.CreateInstance(type);

            var rs = method.Invoke(obj, paramss) as Dictionary<string, object>;

            if (!string.IsNullOrEmpty(rs["Error"].ToString()))
                 Console.WriteLine(rs["Error"].ToString());
            else
            {
                List<Dictionary<string, object>> x = (List<Dictionary<string, object>>)rs["List"];

                Console.WriteLine(x[0]["Result"].ToString());

            }

           

            Console.ReadKey();
        }
    }
}
