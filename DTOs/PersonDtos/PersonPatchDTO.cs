using System.ComponentModel.DataAnnotations;
namespace RestApi.DTOs.PersonDtos
{
    public class PersonPatchDTO
    {
        [StringLength(55, MinimumLength =3, ErrorMessage ="Du måste skriva mellan 3 till 55 karaktärer")]
        public string? namn { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "Du måste skriva mellan 5 till 20 karaktärer")]
        public string? Mobilnummer { get; set; }
        public string? Epost { get; set; }
        public string? Beskrivning { get; set; }
    }
}
