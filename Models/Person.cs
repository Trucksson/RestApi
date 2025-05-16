using System.ComponentModel.DataAnnotations;
namespace RestApi.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required, StringLength(50)]
        public string Namn { get; set; }

        [Required, StringLength(50)]
        public string Mobilnummer { get; set; }

        public string Epost { get; set; }

        public string Beskrivning { get; set; }
        public ICollection<Utbildning> Utbildningar { get; set; }
        public ICollection<Arbetserfarenhet> Arbetserfarenheter { get; set; }
    }
}
