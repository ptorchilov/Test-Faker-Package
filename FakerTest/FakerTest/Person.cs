namespace FakerTest
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        public int PersonId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String CompanyName { get; set; }

        public virtual List<Location> Locations { get; set; }

        public virtual List<Phone> Phones { get; set; }
    }
}
