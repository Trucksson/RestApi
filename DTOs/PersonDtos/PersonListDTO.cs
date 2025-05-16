using RestApi.DTOs.UtbildningDtos;
using RestApi.DTOs.ArbetserfarenhetDtos;

namespace RestApi.DTOs.PersonDtos
{
    public class PersonListDTO
    {
        public int PersonId { get; set; }
        public string namn { get; set; }
        public string Mobilnummer { get; set; }
        public string Epost { get; set; }
        public string Beskrivning { get; set; }

        public List<UtbildningDTO> Utbildningar { get; set; }
        public List<ArbetserfarenhetDTO> Arbetserfarenheter { get; set; }
    }
}
