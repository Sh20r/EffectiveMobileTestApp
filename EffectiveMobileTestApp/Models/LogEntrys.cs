namespace EffectiveMobileTestApp.Models
{
    public class LogEntrys : BaseModel
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}
