using DAL.AMenistop.DTO;
using DAL.AMenistop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.AMenistop.Common
{
    internal interface IRepository<T> where T : Entity
    {
        public T Add(T model);
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public void Delete(int id);
        public void Update(T model);
    }
}
