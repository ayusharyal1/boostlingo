using BoostlingoApp.Domain.Models;

namespace BoostlingoApp.Application.Commands
{
    public interface IInsertUsersCommand
    {
        /// <summary>
        /// Method to insert users list into database.
        /// </summary>
        /// <param name="users">List of users to insert.</param>
        /// <returns>True/False</returns>
        bool Execute(IEnumerable<User> users);
    }
}
