using BoostlingoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Application.Commands
{
    public interface IInsertUsersCommand
    {
        /// <summary>
        /// Method to insert users list into database.
        /// </summary>
        /// <param name="users">List of users to insert.</param>
        /// <returns>True/False</returns>
        bool Execute(List<User> users);
    }
}
