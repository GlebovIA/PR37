using Microsoft.AspNetCore.Mvc;
using PR37.Data.Interfaces;
using PR37.Data.ViewModels;
using System.Linq;

namespace PR37.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategories;
        VMItems VMItems = new VMItems();
        public ItemsController(IItems IAllItems, ICategories IAllCategories)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
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
    }
}
