using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppKnjige.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Knjiga> Knjiga { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Knjiga>().Property(f => f.Cijena).HasPrecision(10, 2);

            builder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Horor" },
                new Kategorija() { Id = 2, Naziv = "Putopis" },
                new Kategorija() { Id = 3, Naziv = "Kriminalistika" },
                new Kategorija() { Id = 4, Naziv = "SF" },
                new Kategorija() { Id = 5, Naziv = "Realizam" }
                );

            builder.Entity<Knjiga>().HasData(
                new Knjiga() { Id = 1, ImeAutora = "Stephen King", NazivKnjige = "Uljez", Cijena = 3.99m, GodinaIzlaska = 2020, SlikaUrl = "https://upload.wikimedia.org/wikipedia/en/e/e4/The_Outsider_by_Stephen_King.jpg", KategorijaId = 1 },
                new Knjiga() { Id = 2, ImeAutora = "Davor Rostuhar", NazivKnjige = "Na putu u skrivenu dolinu", Cijena = 3.99m, GodinaIzlaska = 2012, SlikaUrl = "https://www.kek.hr/wp-content/uploads/2016/11/na-putu-u-skrivenu-dolinu-rostuhar.jpg", KategorijaId = 2 },
                new Knjiga() { Id = 3, ImeAutora = "Julie Clark", NazivKnjige = "U bijegu", Cijena = 3.99m, GodinaIzlaska = 2023, SlikaUrl = "https://mozaik-knjiga.hr/wp-content/uploads/2023/03/U-bijegu-500pix-213x300.jpg", KategorijaId = 3 },
                new Knjiga() { Id = 4, ImeAutora = "Tess Gerritsen", NazivKnjige = "Znam tajnu", Cijena = 3.99m, GodinaIzlaska = 2023, SlikaUrl = "https://mozaik-knjiga.hr/wp-content/uploads/2023/02/Znam_tajnu_500pix-208x300.jpg", KategorijaId = 3 },
                new Knjiga() { Id = 5, ImeAutora = "Andy Weir", NazivKnjige = "Marsovac", Cijena = 3.99m, GodinaIzlaska = 2015, SlikaUrl = "https://www.vbz.hr/wp-content/uploads/2019/01/marsovac_radno-768x1188.jpg", KategorijaId = 4 }
                );
        }
    }
}
