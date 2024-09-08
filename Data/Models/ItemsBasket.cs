namespace PR37.Data.Models
{
    public class ItemsBasket : Items
    {
        public int Count { get; set; }
        public ItemsBasket(int count, Items item) : base(item)
        {
            Count = count;
        }
    }
}
