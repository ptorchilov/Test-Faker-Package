namespace FakerTest
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(String[] args)
        {
            using (var db = new PeopleContext())
            {
                Console.WriteLine("Enter a first name for person: ");
                var firstName = Console.ReadLine();

                Console.WriteLine("Enter a last name for person: ");
                var lastName = Console.ReadLine();

                var person = new Person
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                db.People.Add(person);
                db.SaveChanges();

                var query = from b in db.People
                            orderby b.LastName
                            select b;

                Console.WriteLine("All people in database:");

                foreach (var item in query)
                {
                    Console.WriteLine(String.Concat(item.LastName," ", item.FirstName));
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}