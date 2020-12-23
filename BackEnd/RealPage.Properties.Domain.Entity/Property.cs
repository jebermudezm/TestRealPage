using System;

namespace RealPage.Properties.Domain.Entity
{
    public class Property : Base.Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Area { get; set; }
        public string Contact { get; set; }
        public string PhoneContact { get; set; }
        public double Price { get; set; }
    }
}
