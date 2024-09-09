namespace PR37.Data.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Price { get; set; }
        public Categories Category { get; set; }
        public Items(Items item = null)
        {
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Img = item.Img;
                Price = item.Price;
                Category = item.Category;
            }
        }
    }
}
