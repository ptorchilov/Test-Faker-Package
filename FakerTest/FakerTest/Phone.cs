namespace FakerTest
{
    using System;
    
    public class Phone
    {
        public int PhoneId { get; set; }

        public String HomePhone { get; set; }

        public String WorkPhone { get; set; }

        public String MobilePhone { get; set; }

        public virtual Person Person { get; set; }
    }
}
