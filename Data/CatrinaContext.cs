namespace Data
{
    using Entities;
    using Entities.Account;
    using Entities.Deals;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class CatrinaContext : IdentityDbContext<User>
    {
        public CatrinaContext(DbContextOptions<CatrinaContext> options)
       : base(options)
        { }

        public  DbSet<Buyer> Buyers { get; set; }

        public  DbSet<Consignee> Consignees { get; set; }

        public  DbSet<Country> Countries { get; set; }

        public  DbSet<Deal> Deals { get; set; }

        public  DbSet<Formulation> Formulations { get; set; }

        public  DbSet<Package> Packages { get; set; }

        public  DbSet<Port> Ports { get; set; }

        public  DbSet<Product> Products { get; set; }

        public  DbSet<TransportCompany> TransportCompanies { get; set; }

        //---------------------System Base -------------------------------/

        public DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Deal>()
                .HasOne<Buyer>(b => b.Buyer)
                .WithMany(d => d.Deals);

            modelBuilder.Entity<Deal>()
               .HasOne<Consignee>(c => c.Consignee)
               .WithMany(d => d.Deals);

            modelBuilder.Entity<Deal>()
               .HasOne<Country>(b => b.Country)
               .WithMany(d => d.Deals);

            modelBuilder.Entity<Deal>()
               .HasOne<Formulation>(b => b.Formulation)
               .WithMany(d => d.Deals);

            modelBuilder.Entity<Deal>()
             .HasOne<Package>(b => b.Package)
             .WithMany(d => d.Deals);


           modelBuilder.Entity<Deal>()
            .HasOne<Port>(b => b.Port)
            .WithMany(d => d.Deals);

           modelBuilder.Entity<Deal>()
            .HasOne<Product>(b => b.Product)
            .WithMany(d => d.Deals);

           modelBuilder.Entity<Deal>()
             .HasOne<TransportCompany>(b => b.TransportCompany)
             .WithMany(d => d.Deals);

            modelBuilder.Entity<Log>()
                .HasOne<User>(u => u.User)
                .WithMany(l => l.MyLogs);
            }
        }
    }
