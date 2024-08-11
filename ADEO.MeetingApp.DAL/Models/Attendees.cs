using System.ComponentModel.DataAnnotations.Schema;

namespace ADEO.MeetingApp.DAL.Models
{
    public class Attendees : Entity
    {
        public string FullName { get; set; }

        public int MeetingID { get; set; }

        [ForeignKey("MeetingID")]
        public virtual MeetingDetails MeetingDetails { get; set; }

        public bool DidAttend { get; set; }

        public bool IsCalled { get; set; } 

        public string PhoneNumber { get; set; }
    }
}