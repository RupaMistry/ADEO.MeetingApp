using ADEO.MeetingApp.Controllers;
using ADEO.MeetingApp.DAL.Core;
using ADEO.MeetingApp.DAL.Models;
using ADEO.MeetingApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ADEO.MeetingApp.Web.Controllers
{
    public class MeetingsController(
        IMeetingRepository<MeetingDetails> meetingRepository,
        ILogger<AttendeesActionController> logger) : Controller
    {
        private static DateOnly _currentDate = DateOnly.FromDateTime(DateTime.Today);
        private readonly IMeetingRepository<MeetingDetails> _meetingRepository = meetingRepository;

        private readonly ILogger<AttendeesActionController> _logger = logger;

        /// <summary>
        /// Returns all meetings
        /// </summary> 
        /// <returns><![CDATA[Task<IActionResult>]]></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var meetings = await this._meetingRepository.GetAllAsync(_currentDate);

            return View(meetings);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
