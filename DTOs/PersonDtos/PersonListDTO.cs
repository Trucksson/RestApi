using RestApi.DTOs.ArbetserfarenhetDtos;
using RestApi.DTOs.UtbildningDtos;

namespace RestApi.DTOs.PersonDtos
{
    public class PersonListDTO
    {
        public string namn { get; set; }
        public string Mobilnummer { get; set; }
        public string Epost { get; set; }
        public string Beskrivning { get; set; }
        public List<UtblidningDTO> Utbildningar { get; set; }
        public List<ArbetserfarenhetDTO> Arbetserfarenhets { get; set; }
    }
}
