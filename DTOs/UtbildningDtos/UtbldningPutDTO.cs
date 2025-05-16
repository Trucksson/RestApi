using System.ComponentModel.DataAnnotations;

namespace RestApi.DTOs.UtbildningDtos
{
    public class UtbildningPutDTO
    {
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Saknar namn till skolan, det behövs")]
        [StringLength(50, ErrorMessage = "Kan inte bli mer än 50 karaktärer")]
        public string Skola { get; set; }
        [Required(ErrorMessage = "Saknar info om vad du studerar"), StringLength(50)]
        public string UtbildningBeskrivning { get; set; }
        [Required(ErrorMessage = "Saknar info om examen"), StringLength(50)]
        public string UtbildningExamen { get; set; }
        [Required(ErrorMessage = "Saknar info om startdatum"), DataType(DataType.Date)]
        public DateOnly UtbildningStart { get; set; }
        [Required(ErrorMessage = "Saknar info om slutdatum"), DataType(DataType.Date)]
        public DateOnly UtbildningSlut { get; set; }
    }
}
