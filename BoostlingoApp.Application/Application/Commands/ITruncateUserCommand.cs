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
