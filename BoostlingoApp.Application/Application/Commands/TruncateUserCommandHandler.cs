using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BoostlingoApp.Application.Commands
{
    public class TruncateUserCommandHandler(IUserRepository repo, ILogger<TruncateUserCommandHandler> logger) : ITruncateUserCommand
    {
        public void Execute()
        {
            try 
            {
                logger.LogInformation("Truncate Started");
                repo.Truncate<UserEntity>();
            }
            catch (Exception ex)
            {
                logger.LogError($"Could not truncate table User. Message:{JsonSerializer.Serialize(ex)}");
                throw new Exception($"Could not truncate table User. Message:{ JsonSerializer.Serialize(ex)}");
            }
        }
    }
}
