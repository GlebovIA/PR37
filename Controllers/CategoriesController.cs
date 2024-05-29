using Microsoft.AspNetCore.Mvc;
using PR37.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PR37.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategories IAllCategories;
        public CategoriesController(ICategories IAllCategories)
        {
            this.IAllCategories = IAllCategories;
        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с категорями";
            var cars = IAllCategories.AllCategories;
            return View(cars);
        }
    }
}
