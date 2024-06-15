using AutoMapper;
using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;

namespace BoostlingoApp.Application.Commands
{
    public class InsertUsersCommandHandler(IUserRepository repo, ILogger<InsertUsersCommandHandler> logger, IMapper mapper) : IInsertUsersCommand
    {
        public bool Execute(IEnumerable<User> users)
        {
            try 
            {
                logger.LogInformation("Start insert");
                repo.AddRange(mapper.Map<IEnumerable<User>, IEnumerable<UserEntity>>(users));
            }
            catch(Exception ex) 
            {
                logger.LogError($"Could not insert data to  table User. Message:{ex.Message}");
                throw new Exception($"Could not insert data to table User. Message:{ex.Message}");
            }
            return true;
        }
    }
}
