using System.CommandLine;

namespace task_tracker.Commands;

public static class ListCommand
{
    public static Command Build()
    {
        var statusArg = new Argument<string?>("status")
        {
            DefaultValueFactory = (x) => null,
            Description = "Optional status filter: todo, in-progress, done",
        };

        var cmd = new Command("list", "List all tasks");
        cmd.Arguments.Add(statusArg);

        cmd.SetAction(pr =>
        {
            var givenStatusArg = pr.GetValue(statusArg);
            var map = new Dictionary<string, TaskStatus>(StringComparer.OrdinalIgnoreCase)
            {
                { "todo", TaskStatus.Todo },
                { "in-progress", TaskStatus.InProgress },
                { "done", TaskStatus.Done }
            };

            var allTasks = FileUtilities.ReadAllTasksFromFile();

            if (string.IsNullOrEmpty(givenStatusArg))
            {
                foreach (var task in allTasks)
                {
                    Console.WriteLine(task.ToString());
                }
            }
            else
            {
                foreach (var task in allTasks)
                {
                    if (map.TryGetValue(givenStatusArg, out TaskStatus value))
                    {
                        if (task.Status == value)
                        {
                            Console.WriteLine(task.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Status {givenStatusArg} is not a status");
                    }
                }
            }
        });

        return cmd;
    }
}
