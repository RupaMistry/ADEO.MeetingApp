using ADEO.MeetingApp.DAL.Models;

namespace ADEO.MeetingApp.DAL.Core
{
    /// <summary>
    /// IRepository for MeetingDetails entity
    /// </summary>
    public interface IMeetingRepository<T> where T : Entity
    {
        /// <summary>
        /// Returns list of meetings for given date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of Meetings</returns>
        Task<IReadOnlyList<T>> GetAllAsync(DateOnly date);

        /// <summary>
        /// Returns meeting details by ID.
        /// </summary>
        /// <param name="meetingID"></param> 
        /// <returns>Meeting</returns>
        Task<T> GetAsync(int meetingID); 
    }
}
