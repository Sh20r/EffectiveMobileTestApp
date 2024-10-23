using EffectiveMobileTestApp.DTOs;
using EffectiveMobileTestApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EffectiveMobileTestApp.Controllers
{
    public class DeliveryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DeliveryController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DateTime parsedDate;
            if (!DateTime.TryParse(orderDto.DeliveryTime.ToString(), out parsedDate))
            {
                if (!DateTime.TryParseExact(orderDto.DeliveryTime.ToString(), "yyyy-MM-dd HH:mm:ss",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    return BadRequest("Неверный формат. Используйте yyyy-MM-dd HH:mm:ss.");
                }
            }

            var deliveryOrder = new DeliveryOrder
            {
                Weight = orderDto.Weight,
                District = orderDto.District,
                DeliveryTime = parsedDate
            };

            _context.DeliveryOrders.Add(deliveryOrder);
            _context.SaveChanges();

            var result = new
            {
                deliveryOrder.Id,
                deliveryOrder.Weight,
                deliveryOrder.District,
                DeliveryTime = deliveryOrder.DeliveryTime.ToString("yyyy-MM-dd HH:mm:ss")
            };

            return CreatedAtAction(nameof(CreateOrder), new { id = deliveryOrder.Id }, result);
        }


        [HttpGet("Filter")]
        public IActionResult FilterOrders(string district, DateTime firstDeliveryDateTime)
        {
            var endTime = firstDeliveryDateTime.AddMinutes(30);
            var orders = _context.DeliveryOrders
                .Where(o => o.District == district && o.DeliveryTime >= firstDeliveryDateTime && o.DeliveryTime <= endTime)
                .ToList();

            Log($"заказы {district} с {firstDeliveryDateTime} до {endTime}");

            return Ok(orders);
        }

        private void Log(string message)
        {
            _context.Logs.Add(new LogEntrys { Timestamp = DateTime.Now, Message = message });
            _context.SaveChanges();
        }
    }
}
