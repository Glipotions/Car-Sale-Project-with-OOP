﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;
		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}
		[ValidationAspect(typeof(ColorValidator))]
		public IResult Add(Color entity)
		{
			_colorDal.Add(entity);
			return new SuccessResult(Messages.Added);
		}

		public IResult Delete(Color entity)
		{
			_colorDal.Delete(entity);
			return new SuccessResult(Messages.Deleted);
		}

		public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
		{
			if (DateTime.Now.Hour == 03)
			{
				return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
		}

		public IDataResult<List<Color>> GetById(int id)
		{
			if (DateTime.Now.Hour == 03)
			{
				return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.Id == id), Messages.Listed);
		}

		public IResult Update(Color entity)
		{
			_colorDal.Update(entity);
			return new SuccessResult(Messages.Updated);
		}
	}
}
