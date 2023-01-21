using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        public void TAdd(T t);
        public void TRemove(T t);
        public void TUpdate(T t);
        public T GetById(int id);

        public List<T> GetAll();
    }
}
