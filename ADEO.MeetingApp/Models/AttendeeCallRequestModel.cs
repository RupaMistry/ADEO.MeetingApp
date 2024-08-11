using ADEO.MeetingApp.DAL.Models;

namespace ADEO.MeetingApp.Web.Models
{
    public class AttendeeCallRequestModel
    {
        public MeetingDetails MeetingDetails { get; set; }

        public IReadOnlyList<Attendees> Attendees { get; set; }
    }
}