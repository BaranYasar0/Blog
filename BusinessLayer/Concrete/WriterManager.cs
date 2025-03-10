﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public List<Writer> GetAll()
		{
			throw new NotImplementedException();
		}

		public Writer GetById(int id)
		{
		return _writerDal.GetById(id);
		}

		public List<Writer> GetWriterByID(int id)
		{
		return _writerDal.GetAll(x=>x.WriterID==id);
		}

		public void TAdd(Writer t)
		{
            _writerDal.Insert(t);

        }

        public void TRemove(Writer t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Writer t)
		{
		_writerDal.Update(t);
		}

	}
}
