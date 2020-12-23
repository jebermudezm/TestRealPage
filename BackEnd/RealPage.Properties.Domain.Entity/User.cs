using System;

namespace RealPage.Properties.Domain.Entity
{
    public class User : Base.Entity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        //public string Token { get; set; }
    }
}
