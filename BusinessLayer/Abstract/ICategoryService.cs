using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        public void CategoryAdd(Category category);
        public void CategoryRemove(Category category);
        public void CategoryUpdate(Category category);

    }
}
