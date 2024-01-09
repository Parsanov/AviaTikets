using AviaTikets.Interfaces;
using AviaTikets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Net.Sockets;

namespace AviaTikets.Controllers
{
    public class AirTicketsController : Controller
    {
        private readonly ILogger<AirTicketsController> _logger;

        private readonly ITickets _tickets;

        public AirTicketsController(ILogger<AirTicketsController> logger, ITickets tickets)
        {
            _logger = logger;
            _tickets = tickets;
        }

        public async Task<IActionResult> FindTickets(Tickets tickets)
        {
            var availableTickets = await _tickets.GetAll();

            var find = availableTickets.Where(t => t.StartAirport == tickets.StartAirport && t.EndAirport == tickets.EndAirport);

            return View(find);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> GetAll()
        {
            var ticketsList = await _tickets.GetAll();

            return Ok(ticketsList);
        }


        public async Task<IActionResult> GetTiket(int id)
        {
            var ticketsId = await _tickets.GetTiketsById(id);

            return Ok(ticketsId);
        }


        [HttpPost]
        public async Task<IActionResult> Set(Tickets tickets)
        {
            _tickets.Add(tickets);

            return Ok(tickets);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tikets = await _tickets.GetTiketsById(id);
            if (tikets is null)
            {
                return Ok("Він пустий (");
            }

            _tickets.Delete(tikets);

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, Tickets ticketsProp)
        {
            var tikets = await _tickets.GetTiketsById(id);
            if (tikets is null)
            {
                return Ok("Не знайдено (");
            }

            var newTikes = new Tickets
            {
                StartAirport = ticketsProp.StartAirport,
                EndAirport = ticketsProp.EndAirport,
                DepartureDate = ticketsProp.DepartureDate,
                ArrivalDate = ticketsProp.ArrivalDate,
                ClassSeat = ticketsProp.ClassSeat,
            };


            _tickets.Update(newTikes);
            return Ok();
        }



    }
}
