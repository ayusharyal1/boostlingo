using AutoMapper;
using BoostlingoApp.Application.Mappers;
using BoostlingoApp.Domain.Entities;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BoostlingoApp.Application.Queries
{
    public class GetUsersSortedByNameQueryHandler(IUserRepository userRepository, ILogger<GetUsersSortedByNameQueryHandler> logger, IMapper mapper) : IGetUsersSortedByNameQuery
    {
        public async Task<List<User>> Execute()
        {
            logger.LogInformation("GetUsersSortedByNameQuery started.");
            try
            {
                var result = await userRepository.GetAllAsync();
                var sortedResult = from u in result
                                   let usernames = u.Name.Split()
                                   orderby usernames[1], usernames[0]
                                   select u;

                return mapper.Map<List<UserEntity>,List<User>>(sortedResult.ToList());
           }
            catch (Exception ex)
            {
                logger.LogError($"Could not fetch user data. Message:{JsonSerializer.Serialize(ex)}");
                throw new Exception($"Could not fetch user data. Message:{JsonSerializer.Serialize(ex)}");

            }

        }
    }
}
