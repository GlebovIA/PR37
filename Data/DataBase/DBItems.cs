﻿using MySql.Data.MySqlClient;
using PR37.Data.Common;
using PR37.Data.Interfaces;
using PR37.Data.Models;
using PR37.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PR37.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categories> Categories = new DBCategories().AllCategories;
        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> items = new List<Items>();
                MySqlConnection MySqlConnection = Connection.MySqlOpen();
                MySqlDataReader ItemsData = Connection.MySqlQuery("Select * from MyShop.Items Order By 'Name';", MySqlConnection);
                while (ItemsData.Read())
                {
                    items.Add(new Items()
                    {
                        Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                        Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                        Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                        Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                        Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                        Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                    });
                }
                MySqlConnection.Close();

                return items;
            }
        }
        public IEnumerable<Items> FindItems(string search_part)
        {
            List<Items> items = new List<Items>();
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader ItemsData = Connection.MySqlQuery($"Select * from MyShop.Items WHERE Name LIKE '{search_part}' Order By 'Name';", MySqlConnection);
            while (ItemsData.Read())
            {
                items.Add(new Items()
                {
                    Id = ItemsData.IsDBNull(0) ? -1 : ItemsData.GetInt32(0),
                    Name = ItemsData.IsDBNull(1) ? "" : ItemsData.GetString(1),
                    Description = ItemsData.IsDBNull(2) ? "" : ItemsData.GetString(2),
                    Img = ItemsData.IsDBNull(3) ? "" : ItemsData.GetString(3),
                    Price = ItemsData.IsDBNull(4) ? -1 : ItemsData.GetInt32(4),
                    Category = ItemsData.IsDBNull(5) ? null : Categories.Where(x => x.Id == ItemsData.GetInt32(5)).First()
                });
            }
            MySqlConnection.Close();

            return items;
        }
        public int Add(Items item)
        {
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"insert into `Items`(`Name`, `Description`, `Img`, `Price`, `IdCategory`) values ('{item.Name}', '{item.Description}', '{item.Img}', {item.Price}, {item.Category.Id});", MySqlConnection);
            MySqlConnection.Close();
            int IdItem = -1;
            MySqlConnection = Connection.MySqlOpen();
            MySqlDataReader mySqlDataReader = Connection.MySqlQuery($"select `Id` from `Items` where `Name` = '{item.Name}' and `Description` = '{item.Description}' and `Img` = '{item.Img}' and `Price` = {item.Price} and `IdCategory` = {item.Category.Id};", MySqlConnection);
            if (mySqlDataReader.HasRows)
            {
                mySqlDataReader.Read();
                IdItem = mySqlDataReader.GetInt32(0);
            }
            MySqlConnection.Close();
            return IdItem;
        }
        public void Update(int id)
        {
            Items item = AllItems.Where(x => x.Id == id).First();
            MySqlConnection MySqlConnection = Connection.MySqlOpen();
            Connection.MySqlQuery($"update `Items`(`Name` = '{item.Name}', `Description` = '{item.Description}', `Img` = '{item.Img}', `Price` = {item.Price}, `IdCategory` = {item.Category.Id};) where `Id` = {item.Id});", MySqlConnection);
            MySqlConnection.Close();
        }
    }
}