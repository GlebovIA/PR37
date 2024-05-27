using PR37.Data.Models;
using System.Collections.Generic;

namespace PR37.Data.Interfaces
{
    public interface ICategories
    {
        public IEnumerable<Categories> AllCategories { get; }
    }
}
