using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Tsc_Constancia.Util
{
    public class CustomJsonResult
    {
        public int TypeResult { set; get; }
        public int CodeResult { set; get; }
        public object Result { set; get; }
        public string Message { set; get; }
        public CustomJsonResult()
        {

        }
    }
}
