﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;

		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}


		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental entity)
		{
			var result = CheckReturnDate(entity.CarId);

			if (!result.Success)
			{
				return new ErrorResult(result.Message);
			}

			_rentalDal.Add(entity);
			return new SuccessResult(Messages.RentalAdded);
		}

		public IResult CheckReturnDate(int carId)
		{
			var result = _rentalDal.GetCarRentalDetails(r => r.CarId == carId && r.ReturnDate == null);

			if (result.Count > 0)
			{
				return new ErrorResult(Messages.RentalAddedError);
			}
			return new SuccessResult(Messages.RentalAdded);
		}

		public IResult UpdateReturnDate(Rental rental)
		{
			var result = _rentalDal.GetAll(r => r.Id == rental.Id);
			var updateRental = result.LastOrDefault();

			if (updateRental.ReturnDate != null)
			{
				return new ErrorResult(Messages.RentalUpdateReturnDateError);
			}

			updateRental.ReturnDate = rental.ReturnDate;
			_rentalDal.Update(updateRental);
			return new SuccessResult(Messages.RentalUpdateReturnDate);

		}


		public IResult Delete(Rental entity)
		{
			_rentalDal.Delete(entity);

			return new SuccessResult(Messages.RentalDeleted);
		}
		[CacheAspect]
		public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
		}

		public IDataResult<List<Rental>> GetAllByCarId(int id)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == id));
		}

		public IDataResult<List<Rental>> GetAllByCustomerId(int id)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == id));
		}

		public IDataResult<List<Rental>> GetById(int id)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == id));
		}

		public IResult Update(Rental entity)
		{
			_rentalDal.Update(entity);

			return new SuccessResult(Messages.RentalUpdated);
		}
		//Expression<Func<Rental, bool>> filter = null
		public IDataResult<List<CarRentalDetailsDto>> GetCarRentalDetails()
		{

			return new SuccessDataResult<List<CarRentalDetailsDto>>(_rentalDal.GetCarRentalDetails());
		}


		//public IDataResult<List<Rental>> GetAll()
		//{
		//	return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
		//}

	}
}
