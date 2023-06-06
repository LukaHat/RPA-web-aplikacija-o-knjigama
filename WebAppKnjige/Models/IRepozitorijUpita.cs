namespace WebAppKnjige.Models
{
    public interface IRepozitorijUpita
    {
        IEnumerable<Knjiga> PopisKnjiga(); 
        void Create(Knjiga knjiga);
        void Delete(Knjiga knjiga); 
        void Update(Knjiga knjiga);
        int SljedeciId();
        int KategorijaSljedeciId();
        Knjiga DohvatiKnjiguSIdom(int id);
        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);
        Kategorija DohvatiKategorijuSIdom(int id);
    }
}
