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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
        _messageDal = messageDal;
        }

        public List<Message2> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message2 GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetSendBoxByWriter(int id)
        {
            return _messageDal.GetSendBoxByWriter(id);
        }
        public void TAdd(Message2 t) => _messageDal.Insert(t);

        public void TRemove(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
