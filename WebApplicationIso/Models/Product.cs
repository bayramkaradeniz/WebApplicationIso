namespace WebApplicationIso.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsPublished { get; set; }
        public int? Expire { get; set; }
        public string? Description { get; set; }
    }

}