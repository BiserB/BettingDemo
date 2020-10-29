using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Betting.Data;
using Betting.Entities;
using Betting.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
        public IEnumerable<EventType> Get()
        {  
            return null;
        }
    }
}
