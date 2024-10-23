namespace EffectiveMobileTestApp.Models
{
    public class DeliveryOrder : BaseModel
    {
        public Guid OrderId { get; set; }
        public double Weight { get; set; }
        public string District { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}
