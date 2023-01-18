using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
        public void BlogAdd(Blog blog);
        public void BlogRemove(Blog blog);
        public void BlogUpdate(Blog blog);
        public Blog GetById(int id);
        public List<Blog> GetAll();
        public List<Blog> GetListByID(int id);
        public List<Blog> GetBlogListWithCategory();
    }
}
