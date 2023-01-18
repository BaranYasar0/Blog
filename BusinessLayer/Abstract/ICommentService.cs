using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
        public void CommentAdd(Comment comment);
        //public void CommentRemove(Category category);
        //public void CommentUpdate(Category category);
        //public Category GetById(int id);

        public List<Comment> GetAll(int id);
    }
}
