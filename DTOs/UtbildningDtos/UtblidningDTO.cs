namespace RestApi.DTOs.UtbildningDtos
{
    public class UtblidningDTO
    {
        public string Skola { get; set; }
        public string UtbildningBeskrivning { get; set; }
        public string UtbildningExamen { get; set; }
        public DateOnly UtbildningStart { get; set; }
        public DateOnly? UtbildningSlut { get; set; }
    }
}
