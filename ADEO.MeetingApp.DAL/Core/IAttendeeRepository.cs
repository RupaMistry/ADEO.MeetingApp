using ADEO.MeetingApp.DAL.Models;

namespace ADEO.MeetingApp.DAL.Core
{
    /// <summary>
    /// IRepository for Attendees entity
    /// </summary>
    public interface IAttendeeRepository<T> where T : Entity
    {
        /// <summary>
        /// Returns list of attendees for given meetingID.
        /// </summary>
        /// <param name="meetingID"></param>
        /// <returns>List of attendees</returns>
        Task<IReadOnlyList<T>> GetAllAsync(int meetingID);

        /// <summary>
        /// Returns Attendee details by ID.
        /// </summary>
        /// <param name="attendeeID"></param> 
        /// <returns>Attendee</returns>
        Task<T> GetAsync(int attendeeID);

        /// <summary>
        /// Updates attendee status when called.
        /// </summary>
        /// <param name="attendeeID"></param> 
        /// <returns>Rows affected count</returns>
        Task<int> UpdateStatus(int attendeeID);
    }
}