using ADEO.MeetingApp.DAL.Models;

namespace ADEO.MeetingApp.Web.Models
{
    public class CallHistoryModel
    {
        public MeetingDetails MeetingDetails { get; set; }

        public IReadOnlyList<CallHistory> CallHistory { get; set; }
    }
}