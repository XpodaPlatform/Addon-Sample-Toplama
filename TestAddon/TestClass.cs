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
                var value = Convert.ToInt32(parameters[0]["x"]) + Convert.ToInt32(parameters[1]["y"]);

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
