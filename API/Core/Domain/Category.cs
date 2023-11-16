namespace API.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Definition { get; set; } = null!;
        public ICollection<Product>? Products { get; set; }
    }
}
