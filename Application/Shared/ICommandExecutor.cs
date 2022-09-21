using Utility;

namespace Application.Shared
{
    public interface ICommandExecutor
    {
        Task<CommandExecutionResult> Execute(Command command);

    }
}
