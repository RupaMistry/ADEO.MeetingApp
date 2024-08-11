using ADEO.MeetingApp.DAL.Models;

namespace ADEO.MeetingApp.DAL.Core
{
    /// <summary>
    /// IRepository for Attendees entity
    /// </summary>
    public interface ICallHistoryRepository<T> where T : Entity
    {
        /// <summary>
        /// Returns list of call history.
        /// </summary> 
        /// <returns>CallHistory</returns>
        Task<IReadOnlyList<T>> GetAllAsync(int meetingID);

        /// <summary>
        /// Inserts a start call history record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Rows affected count</returns>
        Task<int> InsertStartCallHistory(int meetingID, int attendeeID);

        /// <summary>
        /// Inserts a end call history record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Rows affected count</returns>
        Task<int> InsertEndCallHistory(int meetingID, int attendeeID);
    }
}