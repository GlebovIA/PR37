using System;
using System.Collections.Generic;
using System.Linq;
using PR37.Data.Interfaces;
using PR37.Data.Mocks;
using PR37.Data.Models;

public class MockItems : IItems
{
	public MockItems()
    {
		public ICategories category = new MockCategories();
		public IEnumerable<Items> AllItems
		{
            get
            {
            return new List<Items>()
                {
                    new Items()
                    {
                        Id = 0,
                        Name = "DEXP MS-70",
                        Description = "Абра-кадабра и ваша еда из холодильника готова к употреблению",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/300/300/f67706d3e9f41fdc37fbf1d4ea715b35/b1a761fddbd2197e22bdcf5ee0cd1cfd773ce824ab6ef6eba7411b9a626c50a7.jpg.webp"
                        Price = 7900,
                        Category = category.AllCategories.Where(x => x.Id == 0).First()
                    }
                };
            }
		}
	}
}