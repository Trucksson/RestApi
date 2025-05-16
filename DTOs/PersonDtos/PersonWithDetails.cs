using RestApi.DTOs.ArbetserfarenhetDtos;
using RestApi.DTOs.UtbildningDtos;

public class PersonWithDetailsDTO
{
    public string namn { get; set; }
    public string Mobilnummer { get; set; }
    public string Epost { get; set; }
    public string Beskrivning { get; set; }
    public List<UtbildningDTO> Utbildningar { get; set; }
    public List<ArbetserfarenhetDTO> Arbetserfarenheter { get; set; } 
}
