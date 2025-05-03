using System.ComponentModel.DataAnnotations;

namespace RestApi.DTOs.PersonDtos
{
    public class PersonCreateDTO
    {
        [Required (ErrorMessage = "Saknar namn, det behövs"), ]
        public string name { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string MobileNumber { get; set; }
        [StringLength(50, MinimumLength = 5)]
        public string epost { get; set; }

        [StringLength(50, MinimumLength =5)]
        public string description { get; set; }
    }
}
