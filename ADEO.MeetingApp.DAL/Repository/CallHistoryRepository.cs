using ADEO.MeetingApp.DAL.Core;
using ADEO.MeetingApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ADEO.MeetingApp.DAL.Repository
{
    public class CallHistoryRepository(MeetingAppDBContext dbContext) : ICallHistoryRepository<CallHistory>
    {
        private readonly MeetingAppDBContext _meetingAppContext = dbContext;


        /// <summary>
        /// Returns list of call history.
        /// </summary> 
        /// <returns>CallHistory</returns>
        public async Task<IReadOnlyList<CallHistory>> GetAllAsync(int meetingID)
        {
            try
            {
                var history = await this._meetingAppContext.CallHistory
                    .Where(c=>c.MeetingID == meetingID)
                    .Include(i => i.Attendees)
                    .ToListAsync();

                return history;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Inserts a new call history record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Rows affected count</returns>
        public async Task<int> InsertStartCallHistory(int meetingID, int attendeeID)
        {
            try
            {
                var history = new CallHistory()
                {
                    MeetingID = meetingID,
                    AttendeeID = attendeeID,
                    CalledOn = DateTime.Now,
                    CallEndedOn = null
                };

                this._meetingAppContext.CallHistory.Add(history);

                int rowsAffected = await this._meetingAppContext.SaveChangesAsync();

                return rowsAffected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserts a new end call history record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Rows affected count</returns>
        public async Task<int> InsertEndCallHistory(int meetingID, int attendeeID)
        {
            try
            {
                var history = await  this._meetingAppContext.CallHistory
                     .Where(m => m.MeetingID == meetingID && m.AttendeeID == attendeeID).FirstOrDefaultAsync();

                if (history == null) return -1;

                history.CallEndedOn = DateTime.Now; 

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
