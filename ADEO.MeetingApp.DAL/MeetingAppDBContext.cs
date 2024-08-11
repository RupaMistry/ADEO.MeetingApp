using ADEO.MeetingApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace ADEO.MeetingApp.DAL
{
    public class MeetingAppDBContext(DbContextOptions<MeetingAppDBContext> options) : DbContext(options)
    {
        private static DateOnly _currentDate = DateOnly.FromDateTime(DateTime.Today);
        private static TimeOnly _time = TimeOnly.FromDateTime(DateTime.Today);

        public DbSet<MeetingDetails> MeetingDetails { get; set; }  

        public DbSet<Attendees> Attendees { get; set; } 

        public DbSet<CallHistory> CallHistory { get; set; }  

        /// <summary>
        /// Configures the schema needed for the ChatApp db.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MeetingDetails>().HasData(SeedMeetings); 

            base.OnModelCreating(modelBuilder);
        }

        private static readonly MeetingDetails[] SeedMeetings =
        { 
            new() { ID=1, Name="DU Product Launch", CompanyName="DU", HostFullName="Mohamed Shaikh", HostContact="5051", RoomName="#1 IT Room",
                Date= _currentDate , FromTime= _time.AddHours(9), ToTime=_time.AddHours(10),ComapnyLogoFileName="DU.png" },
            new() { ID=2, Name="Etisalat Product Launch", CompanyName="Etisalat", HostFullName="Yasir Shaikh", HostContact="5150", RoomName="#5 Projector Room ",
                Date= _currentDate , FromTime= _time.AddHours(11), ToTime=_time.AddHours(12),ComapnyLogoFileName="Etisalat.png"  },
            new() { ID=3, Name="ABC Annual Review", CompanyName="ABC", HostFullName="Govinda Siddartha", HostContact="5012", RoomName="#7 Conference",
                Date= _currentDate , FromTime= _time.AddHours(14), ToTime=_time.AddHours(16),ComapnyLogoFileName="ABC.png"  }
        };
    }
}