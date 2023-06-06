using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppKnjige.Models;

namespace WebAppKnjige.Models
{
    public class Knjiga
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} obavezno.")]
        public string ImeAutora { get; set; }
        [Required(ErrorMessage = "Polje {0} obavezno")]
        public string NazivKnjige { get; set; }
        [Required(ErrorMessage = "Polje {0} obavezno.")]
        public int GodinaIzlaska { get; set; }
        [Required(ErrorMessage = "Polje {0} obavezno.")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }
        [Required(ErrorMessage = "Polje {0} obavezno.")]
        [Display(Name = "Korica")]
        public string SlikaUrl { get; set; }
        [Display(Name = "Kategorija")]
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }

    }
}
