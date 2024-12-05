using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Image> Images { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(image => image.Product) 
                .WithMany(product => product.Images) 
                .HasForeignKey(image => image.ProductId) 
                .OnDelete(DeleteBehavior.Cascade); 
            
            var product1Id = Guid.Parse("02ee2bb1-9dc4-4296-8119-ee264d8168f3");
            var product2Id = Guid.Parse("f545d4a3-40b1-4f3b-953a-e2e70275fc27");

            var image1 = new Image
            {
                Id = Guid.Parse("615aa542-835d-477e-944f-c7e52379a831"),
                Url = "/images/Products/ShadowAndBone_Book1.jpg", 
                ProductId = product1Id 
            };

            var image2 = new Image
            {
                Id = Guid.Parse("f1a36166-5459-4e4e-9c12-38286acc7201"),
                Url = "/images/Products/TheRavenBoys_Book1.jpg", 
                ProductId = product2Id 
            };

            modelBuilder.Entity<Image>().HasData(image1, image2);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product(
                    product1Id, 
                    "Тінь та кістка. Книга 1", 
                    300, 
                    "Просимо до Равки. Колись це була велика та могутня країна. Тепер вона на межі зникнення. Равку розділила Тіньова Зморшка: лінія абсолютної темряви, що кишить небезпечними чудовиськами. Непримітна Аліна й уявити не могла, що порятунок Равки ляже на її худенькі плечі. Рятуючи друга Мала, дівчина розбудила свою приспану силу. Саме вона здатна знищити Тіньову Зморшку і возз’єднати спустошену війною країну. Часу обмаль. Аліна вирушає на навчання до величних магів-гриш на чолі з таємничим Дарклінґом. Однак могутня та ще не приборкана сила дівчини може обернутися неабиякою загрозою. І не тільки для монстрів з тіні, а й для всієї Равки, для Мала та самої Аліни.", 
                    Categories.Fantasy, 
                    "Лі Бардуґо",
                    "КСД", 
                    2021 
                ),
                new Product(
                    product2Id, 
                    "Ворони. Книга 1", 
                    570, 
                    "Щороку Блу Сарджент стоїть поруч зі своєю матір’ю-провидицею, поки повз неї проходять майбутні мерці. Сама Блу ніколи їх не бачить — аж до цього року, коли з темряви з’являється хлопчик і заговорює до неї. Його звуть Ґензі, і незабаром Блу дізнається, що він — багатий учень місцевої приватної академії Аґліонбі. Блу дотримується правила триматися якомога далі від хлопців з Аґліонбі. Відомі як 'ворони', вони можуть принести лише неприємності. Але Блу тягне до Ґензі. У нього є все — гроші родини, гарна зовнішність, віддані друзі, але шукає він набагато більшого. Увесь час Блу попереджали, що вона стане причиною смерті її справжнього кохання. Вона ніколи не думала, що це стане реальною проблемою. Але тепер, коли її життя опинилося у дивному і зловісному світі Воронів, вона вже не так у цьому впевнена.", 
                    Categories.Fantasy, 
                    "Меґґі Стівотер",
                    "КСД", 
                    2023 
                )
            });
        }
    }
}
