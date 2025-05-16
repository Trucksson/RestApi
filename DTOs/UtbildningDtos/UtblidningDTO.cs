namespace RestApi.DTOs.UtbildningDtos
{
    public class UtbildningDTO //Rättstavat gaaaaang 
    {
        public string Skola { get; set; }
        public string UtbildningBeskrivning { get; set; }
        public string UtbildningExamen { get; set; }
        public DateOnly UtbildningStart { get; set; }
        public DateOnly? UtbildningSlut { get; set; }
    }
}
