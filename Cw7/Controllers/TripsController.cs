using Cw7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Cw7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        public IActionResult Get()
        {
            var context = new Cw7Context();
            var lista = context.Trips
                .Include(t => t.ClientTrips)
                .ThenInclude(x => x.IdClientNavigation)
                .Include(t => t.IdCountries).Select(x =>
                new DtoModels.DtoTripModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Clients = x.ClientTrips.ToList().Select(x => new DtoModels.Client { FirstName = x.IdClientNavigation.FirstName, LastName = x.IdClientNavigation.LastName }).ToList(),
                    Countries=x.IdCountries.ToList().Select(x => new DtoModels.Country { Name=x.Name}).ToList()
                });
            var aa = JsonConvert.SerializeObject(lista);
            return Ok();
        }
    }
}
