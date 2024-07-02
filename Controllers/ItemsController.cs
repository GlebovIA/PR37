using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PR37.Data.Interfaces;
using PR37.Data.Models;
using PR37.Data.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PR37.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategories IAllCategories;
        VMItems VMItems = new VMItems();
        public ItemsController(IItems IAllItems, ICategories IAllCategories, IHostingEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
            this.hostingEnvironment = environment;
        }
        public ViewResult List(int id = 0, int price = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            VMItems.SelectPriceOrientation = price;
            return View(VMItems);
        }
        public ViewResult FindItems(string name = "")
        {
            ViewBag.Title = $"Поиск по запросу: \"{name}\"";
            VMItems.Items = IAllItems.FindItems(name);
            VMItems.Categories = IAllCategories.AllCategories;
            if (VMItems.Items.Count() > 0)
                return View(VMItems);
            else return null;
        }
        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> categories = IAllCategories.AllCategories;
            return View(Categories);
        }
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int category)
        {
            if(files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items item = new Items();
            item.Name = name;
            item.Description = description;
            item.Img = files.FileName;
            item.Price = Convert.ToInt32(price);
            item.Category = new Categories() { Id = category };
            int id = IAllItems.Add(item);
            return Redirect("/Items/Update?id=" + id);
        }
    }
}
