namespace FakerTest
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public String UserName { get; set; }

        public String DisplayName { get; set; }
    }
}
