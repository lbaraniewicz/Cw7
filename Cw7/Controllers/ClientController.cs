using Cw7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new Cw7Context();
            if (id < 0) return BadRequest("Wprowadzono błędne id");
            bool ifTripsConnected = context.ClientTrips.Any(x => x.IdClient == id);
            if (ifTripsConnected)
            {
                return BadRequest("Ten klient ma już powiązane wycieczki!");
            }
            else
            {
                var client = context.Clients.First(x => x.IdClient == id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
            }
            return Ok("Usunięto " + id);
        }
    }
}
