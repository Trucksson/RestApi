using RestApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RestApi.DTOs.UtbildningDtos
{
    public class UtbildningCreateDTO
    {
        public int PersonId { get; set; }


        [Required(ErrorMessage = "Saknar namn till skolan, det behövs")]
        public string Skola { get; set; }

        [Required(ErrorMessage ="Saknar info om vad du studerar"),StringLength(50)]
        public string UtbildningBeskrivning { get; set; }
        [Required(ErrorMessage = "Saknar info om examen"), StringLength(50)]
        public string UtbildningExamen { get; set; }
        [Required(ErrorMessage = "Saknar info om startdatum"), DataType(DataType.Date)]
        public DateOnly UtbildningStart { get; set; }
        [Required(ErrorMessage = "Saknar info om slutdatum"), DataType(DataType.Date)]
        public DateOnly UtbildningSlut { get; set; }



    }
}
