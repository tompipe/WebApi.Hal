using System.Collections.Generic;

namespace WebApi.Hal.Web.Models
{
    public class Brewery
    {
        internal Brewery()
        {
        }

        public int Id { get; protected set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
    }
}