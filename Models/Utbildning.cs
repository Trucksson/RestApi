using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Utbildning
    {
        [Key]
        public int UtbildningID { get; set; }
        [Required, StringLength(50)]

        public string Skola { get; set; }
        [Required, StringLength(50)]
        public string UtbildningBeskrivning{ get; set; }

        public string UtbildningExamen { get; set; }

        public DateOnly UtbildningStart { get; set; }

        public DateOnly UtbildningSlut { get; set; }

        [ForeignKey("Person")]
        public int PersonId_FK { get; set; }

        public virtual Person Person { get; set; } // FK relation till Person
    }
}
