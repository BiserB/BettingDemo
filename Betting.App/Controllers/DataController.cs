using Betting.Common.InputModels;
using Betting.Entities;
using Betting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Betting.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly EventService eventService;

        public DataController(ILogger<DataController> logger, EventService eventService)
        {
            _logger = logger;
            this.eventService = eventService;
        }             

        [HttpGet("GetEvents")]
        public IEnumerable<Event> GetEvents()
        {
            var result = eventService.GetEvents();

            return result;
        }

        [HttpGet("GetEventTypes")]
        public IEnumerable<EventType> GetEventTypes()
        {
            var result = eventService.GetEventTypes();

            return result;
        }

        [HttpPost("DeleteEvent")]
        public bool DeleteEvent([FromBody]int eventId)
        {
            var result = eventService.DeleteEvent(eventId);

            return result;
        }

        [HttpPost("EditEvent")]
        public bool EditEvent(EventModel eventModel)
        {
            var result = eventService.EditEvent(eventModel);

            return result;
        }
    }    
}
