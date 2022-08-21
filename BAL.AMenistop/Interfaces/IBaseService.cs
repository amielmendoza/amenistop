using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.AMenistop.Common
{
    public interface IBaseService<T> where T : BaseModel
    {
        public ResultObject<T> Add(T model);
        public ResultObjectList<T> GetAll();
        public ResultObject<T> GetById(int id);
        public ResultObject<T> Delete(int id);
        public ResultObject<T> Update(T model);
    }
}
