using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{

		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetAll()
		{
			return _blogDal.GetAll();
		}

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetAll().TakeLast(3).ToList();
		}

		public List<Blog> GetListWithCategoryByWriterBM(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetAll(x => x.WriterID == id);
        }

        public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public Blog GetById(int id)
		{
		return _blogDal.GetById(id);
		}
		public List<Blog> GetListByID(int id)
		{
            return _blogDal.GetAll(x => x.BlogId == id);

        }

		public void TAdd(Blog t)
		{
			_blogDal.Insert(t);
		}

		public void TRemove(Blog t)
		{
			_blogDal.Delete(t);
		}

		public void TUpdate(Blog t)
		{
			_blogDal.Update(t);
		}
	}
}
