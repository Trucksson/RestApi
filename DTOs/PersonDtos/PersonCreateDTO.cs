using System.ComponentModel.DataAnnotations;

namespace RestApi.DTOs.PersonDtos
{
    public class PersonCreateDTO
    {
        [Required(ErrorMessage = "Saknar namn, det behövs")]
        public string namn { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Mobilnummer måste vara mellan 5 och 50 tecken.")]
        public string Mobilnummer { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "E-post måste vara mellan 5 och 50 tecken.")]
        [EmailAddress(ErrorMessage = "Ogiltig e-postadress.")]
        public string Epost { get; set; }

        [StringLength(250, MinimumLength = 5, ErrorMessage = "Beskrivning måste vara mellan 5 och 250 tecken.")]
        public string Beskrivning { get; set; }
    }
}