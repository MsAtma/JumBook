namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public List<CartItem> CartItems { get; set; }

        public string? Name { get; set; }

        public decimal Cost { get; set; }

        public string? Description { get; set; }

        public List<Image> Images { get; set; }

        public Categories Categories { get; set; }

        public string? Author { get; set; }

        public string? Publisher { get; set; }

        public int PublicationYear { get; set; }

        public Product(Guid id, string Name, decimal Cost, string Description, Categories Categories, string Author, string Publisher, int PublicationYear) : this()
        {
            Id = id;
            this.Name = Name;
            this.Cost = Cost;
            this.Description = Description;
            this.Categories = Categories;
            this.Author = Author;
            this.Publisher = Publisher;
            this.PublicationYear = PublicationYear;
        }

        public Product()
        {
            CartItems = new List<CartItem>();
            Images = new List<Image>();
        }
    }
}
