using System.CommandLine;

namespace task_tracker.Commands;

public static class MarkCommand
{
    public static Command Build()
    {
        var idArg = new Argument<string>("id")
        {
            Description = "ID of the task"
        };
        var updatedStatusArg = new Argument<string>("status")
        {
            Description = "Updated status of the task"
        };

        var cmd = new Command("mark", "Marks task with a new status");
        cmd.Arguments.Add(idArg);
        cmd.Arguments.Add(updatedStatusArg);

        cmd.SetAction(pr =>
        {
            var map = new Dictionary<string, TaskStatus>(StringComparer.OrdinalIgnoreCase)
            {
                { "todo", TaskStatus.Todo },
                { "in-progress", TaskStatus.InProgress },
                { "done", TaskStatus.Done }
            };

            if (!int.TryParse(pr.GetValue(idArg), out int taskID))
            {
                Console.WriteLine("ID is not a number");
            }
            else
            {
                var givenStatusArg = pr.GetValue(updatedStatusArg);
                ArgumentException.ThrowIfNullOrEmpty(givenStatusArg);

                try
                {
                    var task = FileUtilities.ReadTaskFromFile(taskID);
                    if (map.TryGetValue(givenStatusArg, out TaskStatus value))
                    {
                        task.Status = value;
                        task.UpdatedAt = DateTime.Now;
                        FileUtilities.WriteTaskToFile(task);
                        Console.WriteLine($"Task updated successfully (ID: {task.ID})");
                    }
                    else
                    {
                        Console.WriteLine($"Status {givenStatusArg} is not a status");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not read task: {ex.Message}");
                }
            }
        });

        return cmd;
    }
}
