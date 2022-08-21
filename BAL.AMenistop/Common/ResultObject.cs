using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.AMenistop.Common
{
    public class ResultObject<T> where T : class
    {
        public bool HasError { get; set; } = false;
        public string Exception { get; set; }
        public T Data { get; set; }
    }
}
