using Microsoft.EntityFrameworkCore;
using WebAppKnjige.Models;

namespace WebAppKnjige.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Knjiga knjiga)
        {
            _appDbContext.Add(knjiga);
            _appDbContext.SaveChanges();
        }

        public void Delete(Knjiga knjiga)
        {
            _appDbContext.Knjiga.Remove(knjiga);
            _appDbContext.SaveChanges();
        }

        public Knjiga DohvatiKnjiguSIdom(int id)
        {
            return _appDbContext.Knjiga
                .Include(k => k.Kategorija)
                .FirstOrDefault(f => f.Id == id);
        }

        public int KategorijaSljedeciId()
        {
            int zadnjiId = _appDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }
        public IEnumerable<Knjiga> PopisKnjiga()
        {

            return _appDbContext.Knjiga.Include(k => k.Kategorija);
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Knjiga
                .Include(k => k.Kategorija)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
            
        }

        public void Update(Knjiga knjiga)
        {
            _appDbContext.Knjiga.Update(knjiga);
            _appDbContext.SaveChanges();
        }




        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }



        public void Delete(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Remove(kategorija);
            _appDbContext.SaveChanges();
        }




        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorija.Find(id);
        }





        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorija;
        }





        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Update(kategorija);
            _appDbContext.SaveChanges();
        }





    }
}
