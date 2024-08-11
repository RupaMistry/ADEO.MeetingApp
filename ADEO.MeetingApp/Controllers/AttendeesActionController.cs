using ADEO.MeetingApp.DAL.Core;
using ADEO.MeetingApp.DAL.Models;
using ADEO.MeetingApp.Web.Models; 
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics; 
namespace ADEO.MeetingApp.Controllers
{
    public class AttendeesActionController(
        IMeetingRepository<MeetingDetails> meetingRepository,
        IAttendeeRepository<Attendees> attendeeRepository,
        ICallHistoryRepository<CallHistory> historyRepository,
        ILogger<AttendeesActionController> logger) : Controller
    {
        private readonly IMeetingRepository<MeetingDetails> _meetingRepository = meetingRepository;
        private readonly IAttendeeRepository<Attendees> _attendeeRepository = attendeeRepository;
        private readonly ICallHistoryRepository<CallHistory> _historyRepository = historyRepository;
        private readonly ILogger<AttendeesActionController> _logger = logger;

        /// <summary>
        /// Indices and return a task of type iactionresult.
        /// </summary>
        /// <param name="meetingID">The meeting ID.</param>
        /// <returns><![CDATA[Task<IActionResult>]]></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int meetingID)
        {
            var meeting = await this._meetingRepository.GetAsync(meetingID);

            var attendees = await this._attendeeRepository.GetAllAsync(meetingID);

            AttendeeCallRequestModel model = new() { MeetingDetails = meeting, Attendees = attendees };

            return View(model);
        }

        [HttpPost]
        public async Task<int> StartCallRequest(int meetingID, int attendeeID)
        {
            await this._attendeeRepository.UpdateStatus(attendeeID);

            var rowsAffected = await this._historyRepository.InsertStartCallHistory(meetingID, attendeeID);

            //TODO: Implement notification logic to Android application.

            return rowsAffected;
        }

        [HttpPost]
        public async Task<int> EndCallRequest(int meetingID, int attendeeID)
        {
            var rowsAffected = await this._historyRepository.InsertEndCallHistory(meetingID, attendeeID);

            //TODO: Implement notification logic to Android application.

            return rowsAffected;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
