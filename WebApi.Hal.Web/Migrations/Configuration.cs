using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebApi.Hal.Web.Models;

namespace WebApi.Hal.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class BeerDbContextConfiguration : DbMigrationsConfiguration<WebApi.Hal.Web.Data.BeerDbContext>
    {
        public BeerDbContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApi.Hal.Web.Data.BeerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            var breweries = new[]
            {
                new Brewery
                {
                    Name = "Little Creatures",
                    City = "Fremantle",
                    Country = "Australia",
                    Website = "https://littlecreatures.com.au/",
                },
                new Brewery
                {
                    Name = "BrewDog",
                    City = "Fraserburgh",
                    Country = "Scotland",
                    Website = "http://www.brewdog.com/"
                },
                new Brewery
                {
                    Name = "Nøgne Ø",
                    City = "Grimstad",
                    Country = "Norway",
                    Website = "http://www.nogne-o.com/"
                },
                new Brewery
                {
                    Name = "8 Wired Brewing Co.",
                    City = "Blenheim",
                    Country = "New Zealand",
                    Website = "http://www.8wired.co.nz/"
                },
                new Brewery
                {
                    Name = "Sierra Nevada Brewing Co.",
                    City = "Chico",
                    Country = "USA",
                    Website = "http://www.sierra-nevada.com/"
                },
                new Brewery
                {
                    Name = "Rogue Ales",
                    City = "Newport",
                    Country = "United States",
                    Website = "http://www.rogue.com/"
                }
            };

            context.Breweries.AddOrUpdate(
                b => b.Name,
                breweries
            );

            var beerStyles = new[]
            {
                new BeerStyle
                {
                    Name = "American Double / Imperial IPA"
                },
                new BeerStyle
                {
                    Name = "American Amber / Red Ale"
                },
                new BeerStyle
                {
                    Name = "Winter Warmer"
                },
                new BeerStyle
                {
                    Name = "American Pale Ale"
                },
                new BeerStyle
                {
                    Name = "English Pale Ale"
                },
                new BeerStyle
                {
                    Name = "English Porter"
                },
                new BeerStyle
                {
                    Name = "Tripel"
                },
                new BeerStyle
                {
                    Name = "American IPA"
                },
                new BeerStyle
                {
                    Name = "Maibock / Helles Bock"
                }
            };

            context.Styles.AddOrUpdate(s => s.Name,
                beerStyles
            );

            context.SaveChanges();

            var beers = new[]
            {
                new Beer
                {
                    Name = "Hopwired IPA", 
                    Style = beerStyles[0], 
                    Brewery = breweries[3], 
                    Abv = 7.3
                },
                new Beer
                {
                    Name = "Tall Poppy", 
                    Style = beerStyles[1], 
                    Brewery = breweries[3], 
                    Abv = 7.0
                },
                new Beer
                {
                    Name = "Day Of The Long Shadow", 
                    Style = beerStyles[2], 
                    Brewery = breweries[0], 
                    Abv = 8.9
                },
                new Beer
                {
                    Name = "Little Creatures Pale Ale", 
                    Style = beerStyles[3], 
                    Brewery = breweries[0], 
                    Abv = 5.2
                },
                new Beer
                {
                    Name = "Rogers", 
                    Style = beerStyles[4],
                    Brewery = breweries[0], 
                    Abv = 3.80
                },
                new Beer
                {
                    Name = "Hardcore IPA", 
                    Style = beerStyles[0], 
                    Brewery = breweries[1], 
                    Abv = 9
                },
                new Beer
                {
                    Name = "God Jul", 
                    Style = beerStyles[5], 
                    Brewery = breweries[2], 
                    Abv = 8.5
                },
                new Beer
                {
                    Name = "Tiger Tripel", 
                    Style = beerStyles[6], 
                    Brewery = breweries[2], 
                    Abv = 9.0
                },
                new Beer
                {
                    Name = "Nøgne Ø India Pale Ale", 
                    Style = beerStyles[7], 
                    Brewery = breweries[2], 
                    Abv = 7.5
                },
                new Beer
                {
                    Name = "Sierra Nevada Celebration Ale",
                    Style = beerStyles[7], 
                    Brewery = breweries[4], 
                    Abv = 6.8
                },
                new Beer
                {
                    Name = "Sierra Nevada Pale Ale", 
                    Style = beerStyles[3], 
                    Brewery = breweries[4], 
                    Abv = 5.6
                },
                new Beer
                {
                    Name = "Red Fox Amber Ale",
                    Style = beerStyles[1], 
                    Brewery = breweries[5], 
                    Abv = 5.1
                },
                new Beer
                {
                    Name = "Dead Guy Ale",
                    Style = beerStyles[8], 
                    Brewery = breweries[5], 
                    Abv = 6.5
                },
                new Beer
                {
                    Name = "5 A.M. Saint", 
                    Style = beerStyles[1], 
                    Brewery = breweries[1], 
                    Abv = 5.0
                }
            };

            context.Beers.AddOrUpdate(b => b.Name,
                beers
            );

            context.SaveChanges();
        }
    }
}
