using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;
using OnlineShop.Db.Models;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Carts");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("CartId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("OrderId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ProductId")
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("CartId");

                b.HasIndex("OrderId");

                b.HasIndex("ProductId");

                b.ToTable("CartItem");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.FavoriteProduct", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("ProductId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("ProductId");

                b.ToTable("FavoriteProducts");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("ProductId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Url")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("ProductId");

                b.ToTable("Images");

                b.HasData(
                    new
                    {
                        Id = new Guid("615aa542-835d-477e-944f-c7e52379a831"),
                        ProductId = new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"),
                        Url = "/images/Products/ShadowAndBone_Book1.jpg"
                    },
                    new
                    {
                        Id = new Guid("f1a36166-5459-4e4e-9c12-38286acc7201"),
                        ProductId = new Guid("b19eba8a-9fe4-4e17-9329-3b8c370eaccd"),
                        Url = "/images/Products/TheRavenBoys_Book1.jpg"
                    });
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreateDateTime")
                    .HasColumnType("datetime2");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.Property<Guid?>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("Orders");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<int>("Categories")
                    .HasColumnType("int");

                b.Property<decimal>("Cost")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Author")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Publisher")
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("PublicationYear")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Products");

                b.HasData(
                    new
                    {
                        Id = new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"),
                        Name = "Тінь та кістка. Книга 1",
                        Cost = 300m,
                        Description = "Просимо до Равки. Колись це була велика та могутня країна. Тепер вона на межі зникнення. Равку розділила Тіньова Зморшка: лінія абсолютної темряви, що кишить небезпечними чудовиськами. Непримітна Аліна й уявити не могла, що порятунок Равки ляже на її худенькі плечі. Рятуючи друга Мала, дівчина розбудила свою приспану силу. Саме вона здатна знищити Тіньову Зморшку і возз’єднати спустошену війною країну. Часу обмаль. Аліна вирушає на навчання до величних магів-гриш на чолі з таємничим Дарклінґом. Однак могутня та ще не приборкана сила дівчини може обернутися неабиякою загрозою. І не тільки для монстрів з тіні, а й для всієї Равки, для Мала та самої Аліни.",
                        Categories = 7,
                        Author = "Лі Бардуґо",
                        Publisher = "КСД",
                        PublicationYear = 2021
                    },
                    new
                    {
                        Id = new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"),
                        Name = "Ворони. Книга 1",
                        Cost = 570m,
                        Description = "Щороку Блу Сарджент стоїть поруч зі своєю матір’ю-провидицею, поки повз неї проходять майбутні мерці. Сама Блу ніколи їх не бачить — аж до цього року, коли з темряви з’являється хлопчик і заговорює до неї. Його звуть Ґензі, і незабаром Блу дізнається, що він — багатий учень місцевої приватної академії Аґліонбі. Блу дотримується правила триматися якомога далі від хлопців з Аґліонбі. Відомі як 'ворони', вони можуть принести лише неприємності. Але Блу тягне до Ґензі. У нього є все — гроші родини, гарна зовнішність, віддані друзі, але шукає він набагато більшого. Увесь час Блу попереджали, що вона стане причиною смерті її справжнього кохання. Вона ніколи не думала, що це стане реальною проблемою. Але тепер, коли її життя опинилося у дивному і зловісному світі Воронів, вона вже не так у цьому впевнена.",
                        Categories = 7,
                        Author = "Меґґі Стівотер",
                        Publisher = "КСД",
                        PublicationYear = 2023
                    });
            });

            modelBuilder.Entity("OnlineShop.Db.Models.UserDeliveryInfo", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("FirstName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Patronymic")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Phone")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("DeliveryAddress")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PaymentMethod")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("UserDeliveryInfo");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
            {
                b.HasOne("OnlineShop.Db.Models.Cart", null)
                    .WithMany("Items")
                    .HasForeignKey("CartId");

                b.HasOne("OnlineShop.Db.Models.Order", null)
                    .WithMany("Items")
                    .HasForeignKey("OrderId");

                b.HasOne("OnlineShop.Db.Models.Product", "Product")
                    .WithMany("CartItems")
                    .HasForeignKey("ProductId");

                b.Navigation("Product");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.FavoriteProduct", b =>
            {
                b.HasOne("OnlineShop.Db.Models.Product", "Product")
                    .WithMany()
                    .HasForeignKey("ProductId");

                b.Navigation("Product");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
            {
                b.HasOne("OnlineShop.Db.Models.Product", "Product")
                    .WithMany("Images")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Product");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
            {
                b.HasOne("OnlineShop.Db.Models.UserDeliveryInfo", "User")
                    .WithMany()
                    .HasForeignKey("UserId");

                b.Navigation("User");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
            {
                b.Navigation("Items");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
            {
                b.Navigation("Items");
            });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
            {
                b.Navigation("CartItems");

                b.Navigation("Images");
            });
#pragma warning restore 612, 618
        }
    }
}
