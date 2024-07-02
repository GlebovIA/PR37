using PR37.Data.Models;
using System.Collections.Generic;

namespace PR37.Data.ViewModels
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public int SelectedItem { get; set; }
        public int SelectCategory = 0;
        public int SelectPriceOrientation = 0;
    }
}
