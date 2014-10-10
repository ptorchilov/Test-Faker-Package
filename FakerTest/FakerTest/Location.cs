namespace FakerTest
{
    using System;
    
    public class Location
    {
        public int LocationId { get; set; }

        public String Country { get; set; }

        public String State { get; set; }

        public String City { get; set; }

        public String Address { get; set; }

        public virtual Person Person { get; set; }

        public static String TableName
        {
            get { return "Locations"; }
        }
    }
}
