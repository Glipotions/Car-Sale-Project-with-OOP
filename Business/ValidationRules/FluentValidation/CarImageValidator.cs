﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class CarImageValidator : AbstractValidator<CarImage>
	{
		public CarImageValidator()
		{
			//RuleFor(c => c.CarId).NotEmpty();
			//RuleFor(c => c.Id).NotEmpty();
			//RuleFor(c => c.ImagePath)
		}
	}
}
