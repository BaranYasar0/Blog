using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        EfCategoryRepository _efCategoryRepository;

        public CategoryManager()
        {
            _efCategoryRepository = new EfCategoryRepository();
        }
        public void CategoryAdd(Category category)
        {
        _efCategoryRepository.Insert(category);
        }

        public void CategoryRemove(Category category)
        {
            throw new NotImplementedException();
        }

        public void CategoryUpdate(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
