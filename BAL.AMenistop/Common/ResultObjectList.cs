using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.AMenistop.Common
{
    public class ResultObjectList<T> where T : class
    {
        public bool HasError { get; set; }
        public string Exception { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
