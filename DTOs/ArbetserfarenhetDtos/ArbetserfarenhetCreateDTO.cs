using System.ComponentModel.DataAnnotations;
namespace RestApi.DTOs.ArbetserfarenhetDtos
{
    public class ArbetserfarenhetCreateDTO
    {
        [Required(ErrorMessage ="Person ID saknas, det behövs")]
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Saknar namn till företaget, det behövs"),StringLength(50, ErrorMessage ="Får inte vara mer än 50 karaktärer")]
        public string Företag { get; set; }
        [Required(ErrorMessage = "Saknar info om vad du jobbar med"), StringLength(50, ErrorMessage = "Får inte vara mer än 50 karaktärer")]
        public string Jobbtitel { get; set; }
        [Required(ErrorMessage = "Saknar info om vad du jobbar med"), StringLength(100, ErrorMessage = "Får inte vara mer än 100 karaktärer")]
        public string Jobbbeskrivning { get; set; }
        [Required(ErrorMessage = "Saknar info om startdatum"), DataType(DataType.Date, ErrorMessage = "Måste ha rätt start datum")]
        public DateOnly Jobbstart { get; set; }
        [DataType(DataType.Date, ErrorMessage ="Saknar slut datum info")]
        public DateOnly? Jobbslut { get; set; }
    }
}
