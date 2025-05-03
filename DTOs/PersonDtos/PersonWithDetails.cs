namespace RestApi.DTOs.PersonDtos
{
    public class PersonWithDetails
    {
        public string namn { get; set; }
        public string Mobilnummer { get; set; }
        public string Epost { get; set; }
        public string Beskrivning { get; set; }
        public List<UtbildningDTO> Utbildningar { get; set; }
        public List<ArbetserfarenhetDTO> Arbetserfarenhets { get; set; }
    }
}
