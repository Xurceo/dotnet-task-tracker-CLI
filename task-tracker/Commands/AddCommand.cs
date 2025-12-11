using System.CommandLine;

namespace task_tracker.Commands;

public static class AddCommand
{
    public static Command Build()
    {
        var taskArg = new Argument<string>("task")
        {
            Description = "Description of the task"
        };

        var cmd = new Command("add", "Add a new task");
        cmd.Arguments.Add(taskArg);

        cmd.SetAction(pr =>
        {
            var stringTask = pr.GetValue(taskArg);
            if (string.IsNullOrEmpty(stringTask))
            {
                Console.WriteLine("Argument 'task' is empty");
            }
            else
            {
                var lastTaskId = FileUtilities.ReadTaskFromFile(id: -1).ID;
                var task = new TrackedTask
                {
                    ID = lastTaskId + 1,
                    Description = stringTask,
                    CreatedAt = DateTime.Now,
                    Status = TaskStatus.Todo
                };
                FileUtilities.WriteTaskToFile(task);
                Console.WriteLine($"Task added successfully (ID: {task.ID})");
            }
        });

        return cmd;
    }
}
