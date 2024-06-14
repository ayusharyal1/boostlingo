using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Application.Commands
{
    public interface ITruncateUserCommand
    {
       /// <summary>
       /// Method to truncate the User table.
       /// </summary>
       void Execute();
    }
}
