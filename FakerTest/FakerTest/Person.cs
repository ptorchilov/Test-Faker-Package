namespace FakerTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private IList<Location> locations;

        public int PersonId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String CompanyName { get; set; }

        public virtual List<Location> Locations
        {
            get
            {
                if (locations == null)
                {
                    locations = new List<Location>();
                }



                return locations.ToList();
            }
            set { locations = value; }
        }

        public virtual List<Phone> Phones { get; set; }

        public static String TableName
        {
            get { return "People"; }
        }
    }
}
