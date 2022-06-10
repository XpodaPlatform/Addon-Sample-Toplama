using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAddon
{
    public class TestClass
    {


        public TestClass()
        {
        }
        public static Dictionary<string, object> SumOfValues(List<Dictionary<string, object>> parameters)
        {

            var result = new Dictionary<string, object>();
            var List = new List<Dictionary<string, object>>();

            result["Error"] = "";

            try

            {
                // Bu parametreler XPODA Client tarafından gönderilecektir.
                var value = Convert.ToInt32(parameters[0]["x"]) + Convert.ToInt32(parameters[0]["y"]);


                // Harici kütüphane kullanma örneği.
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                Log.Information("Ah, there you are!");

                List.Add(new Dictionary<string, object> { { "Result", value } });

                result["List"] = List;

            }

            catch (Exception ex)

            {

                result["Error"] = ex.Message;

            }

            return result;


        }
    }
}
