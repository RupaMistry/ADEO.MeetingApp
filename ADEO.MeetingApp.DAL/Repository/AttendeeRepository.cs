using ADEO.MeetingApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ADEO.MeetingApp.DAL.Core
{
    /// <summary>
    /// IRepository for Attendees entity
    /// </summary>
    public class AttendeeRepository(MeetingAppDBContext dbContext) : IAttendeeRepository<Attendees>
    {
        private readonly MeetingAppDBContext _meetingAppContext = dbContext;

        /// <summary>
        /// Returns list of attendees for given meetingID.
        /// </summary>
        /// <param name="meetingID"></param>
        /// <returns>List of attendees</returns>
        public async Task<IReadOnlyList<Attendees>> GetAllAsync(int meetingID)
        {
            try
            {
                var attendees = await this._meetingAppContext.Attendees
                .Where(m => m.MeetingID == meetingID)
                .OrderBy(n => n.FullName)
                .ToListAsync();

                return attendees;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns Attendee details by ID.
        /// </summary>
        /// <param name="attendeeID"></param> 
        /// <returns>Attendee</returns>
        public async Task<Attendees> GetAsync(int attendeeID)
        {
            try
            {
                // Query and return all messages that are still not delivered to recipient by sender
                var attendee = await this._meetingAppContext.Attendees
                     .Where(m => m.ID == attendeeID).FirstOrDefaultAsync(); 

                return attendee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates attendee status when called.
        /// </summary>
        /// <param name="attendeeID"></param> 
        /// <returns>Rows affected count</returns>
        public async Task<int> UpdateStatus(int attendeeID)
        {
            try
            {
                // Query and return all messages that are still not delivered to recipient by sender
                var attendee = await this.GetAsync(attendeeID);
                attendee.IsCalled = true;

                int rowsAffected = await this._meetingAppContext.SaveChangesAsync();

                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}