using System.CommandLine;

namespace task_tracker.Commands;

public static class DeleteCommand
{
    public static Command Build()
    {
        var idArg = new Argument<string>("id")
        {
            Description = "ID of the task"
        };

        var cmd = new Command("delete", "Delete task from the list");
        cmd.Arguments.Add(idArg);

        cmd.SetAction(pr =>
        {
            if (!int.TryParse(pr.GetValue(idArg), out int taskID))
            {
                Console.WriteLine("Given ID is not a number");
            }
            else
            {
                try
                {
                    FileUtilities.DeleteTaskFromFile(taskID);
                    Console.WriteLine($"Task deleted successfully (ID: {taskID})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not delete task: {ex.Message}");
                }
            }
        });

        return cmd;
    }
}
