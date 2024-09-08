using PR37.Data.Interfaces;
using PR37.Data.Mocks;
using PR37.Data.Models;
using System.Collections.Generic;
using System.Linq;

public class MockItems : IItems
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
                    Description = "Благодаря черному корпусу с лаконичным дизайном микроволновая печь DEXP MS-70 отлично впишется в кухню с любым интерьером. ",
                    Img = "https://c.dns-shop.ru/thumb/st1/fit/300/300/f67706d3e9f41fdc37fbf1d4ea715b35/b1a761fddbd2197e22bdcf5ee0cd1cfd773ce824ab6ef6eba7411b9a626c50a7.jpg.webp",
                    Price = 7900,
                    Category = category.AllCategories.Where(x => x.Id == 0).First()
                },
                new Items()
                {
                    Id = 0,
                    Name = "DEXP 40FKN1",
                    Description = "Телевизор LED DEXP 40FKN1 диагональю 40 дюймов обеспечивает комфортный и увлекательный просмотр телевизионных каналов.",
                    Img = "https://c.dns-shop.ru/thumb/st1/fit/0/0/e180192b4b83045a9c3da6d9abe503fe/36d47d37d5574e214438e92cd7f7efa2f632862d6dd74405371d0a86439af723.jpg.webp",
                    Price = 15200,
                    Category = category.AllCategories.Where(x => x.Id == 1).First()
                }
            };
        }
    }
    public IEnumerable<Items> FindItems(string search_part) { return null; }
    public int Add(Items item) { return 0; }
    public void Update(Items item) { }
    public void Delete(Items item) { }
}