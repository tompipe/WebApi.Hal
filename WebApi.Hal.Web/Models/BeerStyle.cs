namespace WebApi.Hal.Web.Models
{
    public class BeerStyle
    {
        internal BeerStyle()
        {
        }

        public int Id { get; protected set; }
        public string Name { get; set; }
    }
}