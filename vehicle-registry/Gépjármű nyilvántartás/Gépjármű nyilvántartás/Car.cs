using System;
using System.Collections.Generic;
using System.Text;

namespace Gépjármű_nyilvántartás
{
    internal class Car
    {
		public const decimal VatRate = 0.27m;

        private Guid id;
		public Guid Id
		{
            get { return id; }
            private set { id = value; }
        }


        private string licensePlate;
		public string LicensePlate
		{
			get { return licensePlate; }
			private set
			{
				if(value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentNullException(nameof(licensePlate), "License plate can't be null or empty.");
                }
				licensePlate = value.Trim().ToUpper();
            }
		}

		private string brand;
		public string Brand
		{
			get { return brand; }
			private set
			{
				if(value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentNullException(nameof(brand), "Brand can't be null or empty.");
                }
                brand = value;
            }
		}


		private string model;
		public string Model
		{
			get { return model; }
			private set
			{
                if (value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentNullException(nameof(model), "Model can't be null or empty.");
                }
                model = value;
            }
		}

		private int manufactureYear;
		public int ManufactureYear
		{
			get { return manufactureYear; }
			private set
			{
				if(value < 1990 || value > DateTime.Now.Year)
				{
                    throw new ArgumentOutOfRangeException(nameof(manufactureYear), "Manufacture year must be between 1990 and the current year.");
                }
                manufactureYear = value;
            }
		}

		private decimal dailyRentalPrice;
		public decimal DailyRentalPrice
		{
			get { return dailyRentalPrice; }
			private set
			{
				if(value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(dailyRentalPrice), "Daily rental price must be a positive value.");
                }
                dailyRentalPrice = value;
			}
		}

		private int mileage;
		public int Mileage
		{
			get { return mileage; }
			private set
			{
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(mileage), "Mileage must be a positive value.");
                }
                mileage = value;
            }
		}

		public List<User> Users { get; private set; } = new List<User>();

		public Car(string brand, string licensePlate,string model)
		{
			Users = new List<User>();
            Id = Guid.NewGuid();
            Brand = brand;
			LicensePlate = licensePlate;
			Model = model;
			ManufactureYear = DateTime.Now.Year;
            DailyRentalPrice = 0;
			Mileage = 0;
        }

		public Car(string brand, string licensePlate, string model, int manufactureYear, int mileage) : this(brand, licensePlate, model)
		{
			ManufactureYear = manufactureYear;
            Mileage = mileage;
        }

		public Car(string brand, string licensePlate, string model, int manufactureYear, int mileage, decimal dailyRentalPrice) : this(brand,licensePlate, model, manufactureYear, mileage)
		{
			DailyRentalPrice = dailyRentalPrice;
		}

		public Car(string brand, string licensePlate, string model, int manufactureYear, int mileage, decimal dailyRentalPrice, Company company) : this(brand, licensePlate, model, manufactureYear, mileage, dailyRentalPrice)
        {
            company.AddCar(this);
        }

		public void AddUser(User user)
		{
			if(user == null || Users.Contains(user))
            {
                throw new ArgumentException("User is null or already added.");
            }
            Users.Add(user);

			user.Cars.Add(this);
        }

		public void RemoveUser(User user)
		{
			Users.Remove(user);
			user.Cars.Remove(this);
		}

		public void AddMileage(int kilometers)
		{
            if (kilometers <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(kilometers), "Kilometers must be a positive value.");
            }
            Mileage += kilometers;
        }
		public bool IsAvailable => Users.Count > 0;
        public int UserCount => Users.Count;
        public decimal VatIncludedDailyRentalPrice => DailyRentalPrice * (1 + VatRate);

        public int Age => DateTime.Now.Year -  ManufactureYear;

        public override string ToString()
        {
			return $"Brand: {Brand} | License Plate: {LicensePlate} |Model: {Model} | Manufacture Year: {ManufactureYear} | Daily Rental Price: {DailyRentalPrice} Ft | Vat Included Daily Rental Price: {VatIncludedDailyRentalPrice} Ft | Mileage: {Mileage} | Authorized Users count: {Users.Count}";
        }
    }
}
