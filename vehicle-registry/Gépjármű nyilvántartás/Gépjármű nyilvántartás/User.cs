using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Text;

namespace Gépjármű_nyilvántartás
{
    internal class User
    {
		public List<Car> Cars { get; private set; } = new List<Car>(); 

        private Guid id;
		public Guid Id
		{
			get => id;
			private set { id = value; }
		}

		private string name;
		public string Name
		{
			get => name;
			private set
			{
				if(value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentNullException(nameof(name), "Name can't be null or empty.");
                }

				TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
				name = ti.ToTitleCase(value.Trim());

            }
		}

		private string email;
		public string Email
		{
			get => email;
			private set
			{
				if(value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(email), "Email can't be null or empty.");
                }
				else if(!value.Contains("@"))
                {
                    throw new ArgumentException("Email must contain '@' and '.' characters.");
                }
                email = value;
            }
		}

		private string department;

		public string Department
		{
			get => department;
			private set
			{
				department = value;
			}
		}

        public User(string name, string email)
		{
            Cars = new List<Car>();
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Department = "N/A";
        }

		public User(string name, string email, string department) : this(name,email)
		{
			Department = department;
		}

        public override string ToString()
        {
			return $"UName: {Name} | Email: {Email} | Department: {Department} | Available Cars: {Cars.Count}";
        }
	}
}
