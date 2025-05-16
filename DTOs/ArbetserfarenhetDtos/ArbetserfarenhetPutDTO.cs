namespace RestApi.DTOs.ArbetserfarenhetDtos
{
    public class ArbetserfarenhetPutDTO
    {
        public string Företag { get; set; }
        public string Jobbtitel { get; set; }
        public string Jobbbeskrivning { get; set; }
        public DateOnly Jobbstart { get; set; }
        public DateOnly Jobbslut { get; set; }
    }
}
