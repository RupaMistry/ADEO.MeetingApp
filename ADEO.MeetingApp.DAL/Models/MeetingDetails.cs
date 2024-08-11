namespace ADEO.MeetingApp.DAL.Models
{
    public class MeetingDetails : Entity
    {
        public string Name { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly FromTime { get; set; }

        public TimeOnly ToTime { get; set; }

        public string CompanyName { get; set; }

        public string RoomName { get; set; }

        public string HostFullName { get; set; }

        public string HostContact { get; set; }

        public string ComapnyLogoFileName { get; set; } 
    }
}