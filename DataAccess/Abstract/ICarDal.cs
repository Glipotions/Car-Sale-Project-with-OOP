﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
	public interface ICarDal : IEntityRepository<Car>
	{
		List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
		List<CarDetailsDto> GetCarDetailsById(int carId);
	}
}
