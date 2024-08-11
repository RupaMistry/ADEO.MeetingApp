using ADEO.MeetingApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ADEO.MeetingApp.DAL.Core
{
    /// <summary>
    /// IRepository for MeetingDetails entity
    /// </summary>
    public class MeetingRepository(MeetingAppDBContext dbContext) : IMeetingRepository<MeetingDetails>
    {
        private readonly MeetingAppDBContext _meetingAppContext = dbContext;

        /// <summary>
        /// Returns list of meetings for given date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of Meetings</returns>
        public async Task<IReadOnlyList<MeetingDetails>> GetAllAsync(DateOnly date)
        {
            try
            {
                var meetings = await this._meetingAppContext.MeetingDetails
                .Where(m => m.Date == date)
                .OrderBy(n => n.Date)
                .ToListAsync();

                return meetings;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns meeting details by ID.
        /// </summary>
        /// <param name="meetingID"></param> 
        /// <returns>Meeting</returns>
        public async Task<MeetingDetails> GetAsync(int meetingID)
        {
            try
            {
                // Query and return all messages that are still not delivered to recipient by sender
                var meeting = await this._meetingAppContext.MeetingDetails
                     .Where(m => m.ID == meetingID).FirstOrDefaultAsync(); 

                return meeting;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}