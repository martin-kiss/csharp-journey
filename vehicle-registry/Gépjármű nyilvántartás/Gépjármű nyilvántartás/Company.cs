using System;
using System.Collections.Generic;
using System.Text;

namespace Gépjármű_nyilvántartás
{
	internal class Company
	{
		private Guid id;
		public Guid Id
		{
			get => id;
			set
			{
				id = value;
			}
		}

		private string name;
		public string Name
		{
			get => name;
			private set
			{
				if (value == null || value.Trim().Length == 0)
				{
					throw new ArgumentOutOfRangeException(nameof(name), "Name can't be null or empty.");
				}
				name = value;
			}
		}

		private string taxNumber;
		public string TaxNumber
		{
			get => taxNumber;
			private set
			{
				if (value == null || value.Trim().Length == 0)
				{
					throw new ArgumentNullException(nameof(taxNumber), "Tax number can't be null or empty.");
				}
				taxNumber = value;
			}
		}

		private string address;

		public string Address
		{
			get => address;
			private set { address = value; }
		}

		private List<Car> cars;
		public List<Car> Cars
		{
			get => cars;
			private set
			{
				cars = value;
			}
		}

		public Company(string name, string taxNumber)
		{
			Id = Guid.NewGuid();
			Name = name;
			TaxNumber = taxNumber;
			Address = "-";
			List<Car> cars = new List<Car>();
			Cars = cars;
		}

		public Company(string name, string taxNumber, string address) : this(name, taxNumber)
		{
			Address = address;
		}

		public void AddCar(Car car)
		{
			Cars.Add(car);
		}

        public override string ToString()
        {
				return $"Name: {Name} | Tax Number: {TaxNumber} | Address: {Address}| Cars amount: {Cars.Count}";
        }
	}
}
