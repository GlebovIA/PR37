using PR37.Data.Interfaces;
using PR37.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR37.Data.Mocks
{
    public class MockCategories : ICategories
    {
        public IEnumerable<Categories> AllCategories
        {
            get
            {
                return new List<Categories>
                {
                    new Categories()
                    {
                        Id = 0,
                        Name = "Микроволновые печи",
                        Description = "Микроволновки - греют еду."
                    },
                    new Categories()
                    {
                        Id = 1,
                        Name = "Телевизоры",
                        Description = "Телевизоры - смотреть футбольчик."
                    }
                };
            }
        }
    }
}
