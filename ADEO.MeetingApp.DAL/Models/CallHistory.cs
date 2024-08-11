using System.ComponentModel.DataAnnotations.Schema;

namespace ADEO.MeetingApp.DAL.Models
{
    public class CallHistory : Entity
    {
        public int MeetingID { get; set; }
         
        public int AttendeeID { get; set; }

        [ForeignKey("AttendeeID")]
        public virtual Attendees Attendees { get; set; }

        public DateTime CalledOn { get; set; }

        public DateTime? CallEndedOn { get; set; }
    } 
}