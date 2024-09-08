using PR37.Data.Models;
using System.Collections.Generic;

namespace PR37.Data.ViewModels
{
    public class VMItems
    {
        public static IEnumerable<Items> Items { get; set; }
        public static IEnumerable<Categories> Categories { get; set; }
        public static int SelectCategory = 0;
        public static int SelectPriceOrientation = 0;
    }
}
