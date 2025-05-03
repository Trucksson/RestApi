using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RestApi.DTOs.UtbildningDtos
{
    public class UtbildningPatchDTO
    {
        public int? PersonID_FK { get; set; }
        [StringLength(50, ErrorMessage = "Kan inte blir mer än 50 karaktärer")]
        public string? Skola { get; set; }
        [StringLength(50, ErrorMessage = "Kan inte blir mer än 50 karaktärer")]
        public string? UtbildningBeskrivning { get; set; }
        [StringLength(50, ErrorMessage = "Kan inte blir mer än 50 karaktärer")]
        public string? UtbildningExamen { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Måste ha rätt start datum")]
        public DateOnly? UtbildningStart { get; set; }
        [DataType(DataType.Date, ErrorMessage ="Måste ha rätt slut datum")]
        public DateOnly? UtbildningSlut { get; set; }
    }
}
