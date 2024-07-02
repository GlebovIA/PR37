using PR37.Data.Models;
using System.Collections.Generic;

namespace PR37.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public IEnumerable<Items> FindItems(string search_part);
        public int Add(Items item);
        public void Update(int id);
    }
}
