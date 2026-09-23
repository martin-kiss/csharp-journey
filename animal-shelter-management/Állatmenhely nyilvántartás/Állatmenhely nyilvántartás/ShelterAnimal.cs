using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Állatmenhely_nyilvántartás
{
	internal class ShelterAnimal
	{
        //mezők, propertyk
        private Guid id;
		public Guid Id
		{
			get { return id; }
			private set { id = value; }
		}

		private string name;
		public string Name
		{
			get { return name; }
			private set
			{
				if (value == null || value.Trim().Length == 0)
				{
					throw new ArgumentOutOfRangeException("Az érték nem lehet null vagy üres.");
				}
				else if (value.Trim().Length < 2)
				{
					throw new ArgumentOutOfRangeException("Az érték nem lehet rövidebb 2 karakternél.");
				}
				name = value;
			}
		}

		private string species;
		public string Species
		{
			get { return species; }
			private set
			{
				if (value == null || value.Trim().Length == 0)
				{
					throw new ArgumentOutOfRangeException("Az érték nem lehet null vagy üres.");
				}
				else if (value.Trim().Length < 3)
				{
					throw new ArgumentOutOfRangeException("Az érték nem lehet rövidebb 3 karakternél/nem tartalmaz számokat.");

				}
				foreach(var c in value)
				{
					if ("1234567890".Contains(c.ToString()))
					{
						throw new ArgumentException("Az érték nem tartalmaz számokat.");
					}
				}
				species = value;

			}
		}

		private int ageInYears;
		public int AgeInYears
		{
			get { return ageInYears; }
			private set
			{
				if(value < 0 || value > 25)
                {
                    throw new ArgumentOutOfRangeException("Az értéknek 0 és 25 között kell lennie.");
                }
                ageInYears = value;
            }
		}

		private double weightKg;
		public double WeightKg
		{
			get { return weightKg; }
			private set
			{
				if (value > 0 && value <= 150)
				{
					weightKg = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Az értéknek 0 és 100 között kell lennie.");
				}
			}
		}

		private DateTime arrivalDate;
		public DateTime ArrivalDate
		{
			get { return arrivalDate; }
			private set
			{
				if (value > DateTime.Now || value < new DateTime(2010, 1, 1))
				{
					throw new ArgumentOutOfRangeException("Az érték nem lehet a jövőben vagy korábbi, mint 2010-01-01.");
				}
				arrivalDate = value;
			}
		}

		private bool isNeutered;
		public bool IsNeutered
		{
			get { return isNeutered; }
			private set { isNeutered = value; }
		}

		private AnimalSection section;
		public AnimalSection Section
		{
			get { return section; }
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Az érték nem lehet null.");
				}
				section = value;
			}
		}


        //konstruktorok láncolással
        public ShelterAnimal(string name, string species, AnimalSection section)
		{
			Id = Guid.NewGuid();
			Name = name;
			Species = species;
			Section = section;
			AgeInYears = 0;
			WeightKg = 1;
			ArrivalDate = DateTime.Today;
			IsNeutered = false;
		}
		public ShelterAnimal(string name, string species, AnimalSection section, int ageInYears, double weightKg, DateTime arrivalDate, bool isNeutered) : this(name, species, section)
		{
			AgeInYears = ageInYears;
			WeightKg = weightKg;
			ArrivalDate = arrivalDate;
			IsNeutered = isNeutered;
		}


		//publikus metódusok 
		public void ChangeWeight(double newWeightKg)
		{
            WeightKg = newWeightKg;
        }

		public void MoveToSection(AnimalSection newSection)
		{
			Section = newSection;
        }

		public bool IsLongTermResident => (DateTime.Today - ArrivalDate).Days >= 180;

        public override string ToString()
        {
            return $"Állat: {Name} | Faj: {Species} | Kor: {AgeInYears} | Súly: {WeightKg} kg | Részleg: {Section.SectionName}";
        }
	}
}
