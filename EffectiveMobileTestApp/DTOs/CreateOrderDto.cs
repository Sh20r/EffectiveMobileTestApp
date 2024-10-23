using System.ComponentModel.DataAnnotations;

namespace EffectiveMobileTestApp.DTOs
{
    public class CreateOrderDto : BaseDTO
    {
        [Required]
        public double Weight { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryTime { get; set; }
    }
}
