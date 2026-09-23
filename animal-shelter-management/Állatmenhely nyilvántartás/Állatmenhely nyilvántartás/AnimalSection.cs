using System;
using System.Collections.Generic;
using System.Text;

namespace Állatmenhely_nyilvántartás
{
    internal class AnimalSection
    {
        private Guid id;
        public Guid Id
        {
            get { return id; }
            private set { id = value; }
        }

        private string sectionName;
        public string SectionName
        {
            get { return sectionName; }
            private set
            {
                if (value == null || value.Trim().Length == 0)
                {
                    throw new ArgumentOutOfRangeException("Az érték nem lehet null vagy üres.");
                }
                else if (value.Trim().Length < 4)
                {
                    throw new Exception("Az érték nem lehet rövidebb 4 karakternél.");

                }
                sectionName = value;
            }
        }

        private int maxCapacity;
        public int MaxCapacity
        {
            get { return maxCapacity; }
            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Az értéknek 1 és 100 között kell lennie.");
                }
                maxCapacity = value;
            }
        }

        private bool indoorSection;
        public bool IndoorSection
        {
            get { return indoorSection; }
            private set { indoorSection = value; }
        }

        public AnimalSection(string name, int maxCapacity)
        {
            Id = Guid.NewGuid();
            SectionName = name;
            MaxCapacity = maxCapacity;
            IndoorSection = false;
        }
        public AnimalSection(string name, int maxCapacity, bool indoorSection) : this(name, maxCapacity)
        {
            IndoorSection = indoorSection;
        }

        public override string ToString()
        {
            return $"Részleg: {SectionName} | Maximális férőhely: {MaxCapacity}, Beltéri: {(IndoorSection ? "igen" : "nem")}";
        }
    }
}
