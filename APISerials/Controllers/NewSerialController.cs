using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISerials.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewSerialController : ControllerBase
    {
        private readonly ILogger<NewSerialController> _logger;

        public NewSerialController(ILogger<NewSerialController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var newSerial = new NewSerialData();
            var serial1 = new NewSerialDataDetail();
            var serial2 = new NewSerialDataDetail();
            var serial3 = new NewSerialDataDetail();
            var serial4 = new NewSerialDataDetail();
            var serial5 = new NewSerialDataDetail();
            #region 1serial
            serial1.Id = "1";
            serial1.SerialTitle = "The Witcher Season 2";
            serial1.EpisodeTitle = "A Grain of Truth";
            serial1.EpisodeNumber = "1";
            serial1.Year = "2021";
            serial1.ReleaseState = "16 December";
            newSerial.Items.Add(serial1);
            #endregion
            #region 2serial
            serial2.Id = "2";
            serial2.SerialTitle = "Money Heist Season 5";
            serial2.EpisodeTitle = "Episode #5.6";
            serial2.EpisodeNumber = "6";
            serial2.Year = "2021";
            serial2.ReleaseState = "3 December";
            newSerial.Items.Add(serial2);
            #endregion
            #region 3serial
            serial3.Id = "3";
            serial3.SerialTitle = "Hawkeye";
            serial3.EpisodeTitle = "Episode 5";
            serial3.EpisodeNumber = "5";
            serial3.Year = "2021";
            serial3.ReleaseState = "15 December";
            newSerial.Items.Add(serial3);
            #endregion
            #region 4serial
            serial4.Id = "4";
            serial4.SerialTitle = "Doctor Who";
            serial4.EpisodeTitle = "The Vanquishers";
            serial4.EpisodeNumber = "6";
            serial4.Year = "2021";
            serial4.ReleaseState = "5 December";
            newSerial.Items.Add(serial4);
            #endregion
            #region 5serial
            serial5.Id = "5";
            serial5.SerialTitle = "The Walking Dead Season 11";
            serial5.EpisodeTitle = "Episode 9";
            serial5.EpisodeNumber = "9";
            serial5.Year = "2021";
            serial5.ReleaseState = "13 February";
            newSerial.Items.Add(serial5);
            #endregion
            return new JsonResult(newSerial);
        }
    }
}
