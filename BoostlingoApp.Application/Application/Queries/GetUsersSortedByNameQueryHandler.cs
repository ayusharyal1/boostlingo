using AutoMapper;
using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;

namespace BoostlingoApp.Application.Queries
{
    public class GetUsersSortedByNameQueryHandler(IUserRepository userRepository, ILogger<GetUsersSortedByNameQueryHandler> logger, IMapper mapper) : IGetUsersSortedByNameQuery
    {
        public async Task<IEnumerable<User>> Execute()
        {
            logger.LogInformation("GetUsersSortedByNameQuery started.");
            try
            {
                var result = await userRepository.GetAllAsync();
                var sortedResult = result
                    .Select(u => new
                    {
                        User = u,
                        Usernames = u.Name.Split()
                    })
                    .OrderBy(x => x.Usernames[1])
                    .ThenBy(x => x.Usernames[0])
                    .Select(x => mapper.Map<UserEntity, User>(x.User));

                return sortedResult;
           }
            catch (Exception ex)
            {
                logger.LogError($"Could not fetch user data. Message:{ex.Message}");
                throw new Exception($"Could not fetch user data. Message:{ex.Message}");
            }
        }
    }
}
