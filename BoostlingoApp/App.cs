using BoostlingoApp.Application.Commands;
using BoostlingoApp.Application.Queries;
using BoostlingoApp.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp
{
    public static class App
    {
        public static async Task Run(ServiceProvider serviceProvider)
        {
            // Testing the data fetch from API.
            var jsonDataQuery = serviceProvider.GetService<IGetJsonDataQuery>();
            IEnumerable<User> userData = await jsonDataQuery.Execute();
            Console.WriteLine("Data fetched. Records Count {0}", userData.Count());

            // Data Cleanup before data insertion.
            Console.WriteLine("Cleaning data.");
            var dataCleanupCommand = serviceProvider.GetService<ITruncateUserCommand>();
            dataCleanupCommand.Execute();
            Console.WriteLine("Data cleaned.");

            // Testing data insertion.
            Console.WriteLine("Inserting data.");
            var dataInsertionCommand = serviceProvider.GetService<IInsertUsersCommand>();
            var result = dataInsertionCommand.Execute(userData);
            Console.WriteLine("Data inserted.");

            // Fetching data
            Console.WriteLine("Fetching and displaying data.");
            var dataFetchQuery = serviceProvider.GetService<IGetUsersSortedByNameQuery>();
            var sortedResults = await dataFetchQuery.Execute();

            foreach (var user in sortedResults)
            {
                Console.WriteLine($"{user.Id}\n{user.Name}\n{user.Language}\n{user.Version}\n{user.Bio}\n\n");
            }

            Console.WriteLine("Fetching data completed.");

        }
    }
}
