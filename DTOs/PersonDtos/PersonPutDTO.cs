using System.ComponentModel.DataAnnotations;

namespace RestApi.DTOs.PersonDtos
{
    public class PersonPutDTO
    {
        [Required(ErrorMessage = "Saknar namn, det behövs")]
        [StringLength(55, MinimumLength = 3, ErrorMessage = "Du måste skriva mellan 3 till 55 karaktärer")]
        public string namn { get; set; }
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Du måste skriva mellan 5 till 20 karaktärer")]
        public string Mobilnummer { get; set; }
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress")]
        public string Epost { get; set; }

        [StringLength(200, MinimumLength = 5, ErrorMessage = "Du måste skriva mellan 5 till 200 karaktärer")]
        public string Beskrivning { get; set; }
    }
}
