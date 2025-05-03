using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        [Required, StringLength(50)]
        public string Namn { get; set; }
        
        [StringLength(50),Required]//ass
        
        public string Mobilnummer { get; set; }

        public string Epost { get; set; }
        public string Beskrivning { get; set; }

        public List <Utbildning> Utbildningar { get; set; }
        public List<Arbetserfarenhet> Arbetserfarenhets { get; set; }

    }
}
