﻿using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}
		public IResult Add(Brand entity)
		{
			
			if (entity.BrandName.Length < 2)
			{
				return new ErrorResult(Messages.BrandNamedInvalid);
			}

			_brandDal.Add(entity);

			return new SuccessResult(Messages.BrandAdded);

		}

		public IResult Delete(Brand entity)
		{
			
			_brandDal.Delete(entity);
			return new SuccessResult(Messages.Deleted);

		}

		public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
		}

		//public IDataResult<List<Brand>> GetAllByBrandId(int id)
		//{
		//	return _brandDal.GetAll(b => b.BrandId==id);
		//}

		public IDataResult<List<Brand>> GetById(int id)
		{
			return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id));
		}

		public IResult Update(Brand entity)
		{
			_brandDal.Update(entity);
			return new SuccessResult(Messages.Updated);
		}
	}
}
