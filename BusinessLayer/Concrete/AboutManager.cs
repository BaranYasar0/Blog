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
	public class AboutManager : IAboutService
	{

		IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal = aboutDal;
		}

		public List<About> GetAll()
		{
		return _aboutDal.GetAll();
		}

		public About GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void TAdd(About t)
		{
			throw new NotImplementedException();
		}

		public void TRemove(About t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(About t)
		{
			throw new NotImplementedException();
		}
	}
}
