﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
        List<Message2> GetSendBoxByWriter(int id);

    }
}
