using ADEO.MeetingApp.Controllers;
using ADEO.MeetingApp.DAL.Core;
using ADEO.MeetingApp.DAL.Models;
using ADEO.MeetingApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADEO.MeetingApp.Web.Controllers
{
    public class CallHistoryController(
         IMeetingRepository<MeetingDetails> meetingRepository,
         ICallHistoryRepository<CallHistory> historyRepository,
        ILogger<AttendeesActionController> logger) : Controller
    {
        private readonly IMeetingRepository<MeetingDetails> _meetingRepository = meetingRepository;
        private readonly ICallHistoryRepository<CallHistory> _historyRepository = historyRepository; 
        private readonly ILogger<AttendeesActionController> _logger = logger;

        /// <summary>
        /// Returns all call history logs
        /// </summary> 
        /// <returns><![CDATA[Task<IActionResult>]]></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int meetingID)
        {
            var meeting = await this._meetingRepository.GetAsync(meetingID);

            var history = await this._historyRepository.GetAllAsync(meetingID);

            CallHistoryModel model = new() { MeetingDetails = meeting, CallHistory = history }; 

            return View(model);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
