namespace FakerTest
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using Faker;

    public class Program
    {
        public static void Main(String[] args)
        {
            using (var db = new PeopleContext())
            {

                db.People.RemoveRange(db.People.Where(p => p.PersonId < 100));
                db.Locations.RemoveRange(db.Locations.Where(l => l.LocationId < 100));

                var personId = GetPeople(db);
                var locationId = GetLocation(db);

                InsertLocation(db, personId, locationId);

                ShowResults(db);
            }
        }

        private static void InsertLocation(PeopleContext db, int personId, int locationId)
        {
            var person = db.People.SingleOrDefault(p => p.PersonId == personId);

            if (person != null)
            {
                var location = db.Locations.SingleOrDefault(l => l.LocationId == locationId);

                if (location != null)
                {
                    location.Person = person;
                    db.SaveChanges();
                }
            }
        }

        private static int GetLocation(PeopleContext db)
        {
            var country = Address.Country();
            ShowGeneratedValue("Country: ", country);

            var state = Address.UsState();
            ShowGeneratedValue("State: ", state);

            var city = Address.City();
            ShowGeneratedValue("City :", city);

            var address = Address.StreetAddress();
            ShowGeneratedValue("Address: ", address);

            var location = new Location
            {
                Country = country,
                State = state,
                City = city,
                Address = address
            };

            db.Locations.Add(location);
            db.SaveChanges();

            return location.LocationId;
        }

        private static void ShowResults(PeopleContext db)
        {
            var query = from b in db.People
                orderby b.LastName
                select b;
            
            Console.WriteLine(String.Concat(Environment.NewLine, "All people in database:"));

            foreach (var item in query)
            {
                Console.WriteLine(String.Concat(item.LastName, " ", item.FirstName));

                var locations = from l in db.Locations
                               where l.Person.PersonId == item.PersonId
                               select l;

                foreach (var location in locations)
                {
                    Console.WriteLine(String.Concat(location.Country, ", ", location.State, ", ",
                        location.City, ", ", location.Address));        
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static int GetPeople(PeopleContext db)
        {
            var firstName = Name.First();
            ShowGeneratedValue("First name: ", firstName);

            var lastName = Name.Last();
            ShowGeneratedValue("Last name: ", lastName);

            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            db.People.Add(person);
            db.SaveChanges();

            return person.PersonId;
        }

        public static void ShowGeneratedValue(String message, String value)
        {
            Console.WriteLine(String.Concat(message, value));
        }
    }
}