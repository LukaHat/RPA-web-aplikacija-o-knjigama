using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppKnjige.Models;

namespace WebAppKnjige.Controllers
{
    public class KnjigaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public KnjigaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisKnjiga());
        }


        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Knjiga knjiga = new Knjiga() { Id = sljedeciId };
            return View(knjiga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ImeAutora,NazivKnjige,GodinaIzlaska,Cijena,SlikaUrl,KategorijaId")] Knjiga knjiga)
        {
            ModelState.Remove("Kategorija");//uklanjanje veze

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(knjiga);
                return RedirectToAction("Index"); // ako je sve ok, tu završava metoda 
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", knjiga.KategorijaId);
            return View(knjiga);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Knjiga knjiga = _repozitorijUpita.DohvatiKnjiguSIdom(id);

            if (knjiga == null) { return NotFound(); }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", knjiga.KategorijaId);
            return View(knjiga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,ImeAutora,NazivKnjige,GodinaIzlaska,Cijena,SlikaUrl,KategorijaId")] Knjiga knjiga)
        {
            if (id != knjiga.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(knjiga);
                return RedirectToAction("Index");
            }
            //ako je doslo do greške sljedeci dio se izvrsava
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", knjiga.KategorijaId);
            return View(knjiga);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var knjiga = _repozitorijUpita.DohvatiKnjiguSIdom(Convert.ToInt16(id));

            if (knjiga == null)
            {
                return NotFound();
            }

            return View(knjiga);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var knjiga = _repozitorijUpita.DohvatiKnjiguSIdom(id);
            _repozitorijUpita.Delete(knjiga);
            return RedirectToAction("Index");

        }

        //Trazilica
        public ActionResult SearchIndex(string knjigaZanr, string searchString)
        {
            var zanr = new List<string>();

            var zanrUpit = _repozitorijUpita.PopisKategorija();

            ViewData["knjigaZanr"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "NazivKnjige", zanrUpit);

            var knjigee = _repozitorijUpita.PopisKnjiga();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                knjigee = knjigee.Where(s => s.NazivKnjige.Contains(searchString, StringComparison.OrdinalIgnoreCase)); // StringComparison.OrdinalIgnoreCase ignorira velika-mala slova 
            }

            if (string.IsNullOrWhiteSpace(knjigaZanr))
                return View(knjigee);
            else
            {
                return View(knjigee.Where(x => x.Kategorija.Naziv == knjigaZanr));
            }

        }


    }
}