using System.ComponentModel.DataAnnotations;

namespace RestApi.DTOs.ArbetserfarenhetDtos
{
    public class ArbetserfarenhetPatchDTO
    {
        [Required(ErrorMessage = "Person ID saknas")]
        public int PersonID { get; set; }
        [StringLength(50, ErrorMessage = "Får inte vara mer än 50 karaktärer")]
        public string Företag { get; set; }
        [StringLength(50, ErrorMessage = "Får inte vara mer än 50 karaktärer")]
        public string Jobbtitel { get; set; }
        [StringLength(300, ErrorMessage = "Får inte vara mer än 50 karaktärer")]
        public string Jobbbeskrivning { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Måste ha rätt start datum")]
        public DateOnly Jobbstart { get; set; }
        [DataType(DataType.Date, ErrorMessage ="Måste ha rätt slut datum")]
        public DateOnly Jobbslut { get; set; }
    }
}
