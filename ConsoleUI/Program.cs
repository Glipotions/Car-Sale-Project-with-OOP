﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//BrandAddToDb();

			//ColorAddToDb();

			CarAddToDb();

			//carGetByBrandId(2);

			//CarGetAll();

			//CarDetailsList();

		}

		private static void CarDetailsList()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetCarDetails();
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine("{0}--{1}--{2}--{3}--{4}", car.Id, car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
				}
			}
		}

		private static void CarGetAll()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetAll();
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine("{0}--{1}--{2}", car.CarName, car.DailyPrice, car.ModelYear);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}

		}

		private static void carGetByBrandId(int id)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetAllByBrandId(id);
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					//Console.WriteLine();
					Console.WriteLine("{0}--{1}--{2}", car.CarName, car.DailyPrice, car.ModelYear);
				}
			}

		}

		private static void BrandAddToDb()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			brandManager.Add(new Brand { BrandId = 1, BrandName = "Mercedes" });
			brandManager.Add(new Brand { BrandId = 2, BrandName = "Bmw" });
			brandManager.Add(new Brand { BrandId = 3, BrandName = "Volkswagen" });
			brandManager.Add(new Brand { BrandId = 4, BrandName = "Ford" });
			brandManager.Add(new Brand { BrandId = 5, BrandName = "Skoda" });
		}

		private static void ColorAddToDb()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			colorManager.Add(new Color { ColorId = 1, ColorName = "Siyah" });
			colorManager.Add(new Color { ColorId = 2, ColorName = "Kırmızı" });
			colorManager.Add(new Color { ColorId = 3, ColorName = "Gri" });
			colorManager.Add(new Color { ColorId = 4, ColorName = "Beyaz" });
		}

		private static void CarAddToDb()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			//carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, CarName = "Benz", DailyPrice = 220000, Description = "Sport Car", ModelYear = 2019 });
			//carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 4, CarName = "4-matic", DailyPrice = 250000, Description = "Sport Car", ModelYear = 2020 });
			//carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 2, CarName = "M3", DailyPrice = 200000, Description = "Hatchback", ModelYear = 2015 });
			//carManager.Add(new Car { Id = 4, BrandId = 3, ColorId = 1, CarName = "Passat", DailyPrice = 130000, Description = "Sedan", ModelYear = 2016 });
			//carManager.Add(new Car { Id = 5, BrandId = 5, ColorId = 3, CarName = "Süper-B", DailyPrice = 120000, Description = "Hatchback", ModelYear = 2015 });
			
			carManager.Add(new Car { Id = 6, BrandId = 5, ColorId = 3, CarName = "B", DailyPrice = 120000, Description = "Hatchback", ModelYear = 2015 });
			carManager.Add(new Car { Id = 7, BrandId = 5, ColorId = 3, CarName = "3", Description = "Hatchback", ModelYear = 2015 });
		}
	}
}
