﻿using MySql.Data.MySqlClient;
using PR37.Data.Common;
using PR37.Data.Interfaces;
using PR37.Data.Models;
using System.Collections.Generic;

namespace PR37.Data.DataBase
{
    public class DBCategories : ICategories
    {
        public IEnumerable<Categories> AllCategories
        {
            get
            {
                List<Categories> categories = new List<Categories>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader CategoriesData = Connection.MySqlQuery("Select * from MyShop.Categories Order By 'Name';", MySqlConnection);
                while (CategoriesData.Read())
                {
                    categories.Add(new Categories()
                    {
                        Id = CategoriesData.IsDBNull(0) ? -1 : CategoriesData.GetInt32(0),
                        Name = CategoriesData.IsDBNull(1) ? null : CategoriesData.GetString(1),
                        Description = CategoriesData.IsDBNull(2) ? null : CategoriesData.GetString(2)
                    });
                }
                return categories;
            }
        }
    }
}
