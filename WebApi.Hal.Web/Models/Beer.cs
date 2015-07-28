namespace WebApi.Hal.Web.Models
{
    public class Beer
    {
        internal Beer()
        {
        }

        public Beer(string name)
        {
            Name = name;
        }

        public int Id { get; protected set; }
        public string Name { get; set; }
        public double Abv { get; set; }
        public virtual BeerStyle Style { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}