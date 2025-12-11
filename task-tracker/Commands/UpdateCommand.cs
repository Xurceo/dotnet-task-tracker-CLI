using System.CommandLine;

namespace task_tracker.Commands;

public static class UpdateCommand
{
    public static Command Build()
    {
        var idArg = new Argument<string>("id")
        {
            Description = "ID of the task"
        };
        var updatedDescArg = new Argument<string>("desc")
        {
            Description = "Updated description of the task"
        };

        var cmd = new Command("update", "Update existing task");
        cmd.Arguments.Add(idArg);
        cmd.Arguments.Add(updatedDescArg);


        cmd.SetAction(pr =>
        {
            if (!int.TryParse(pr.GetValue(idArg), out int taskID))
            {
                Console.WriteLine("ID is not a number");
            }
            else
            {
                var stringUpdatedDesc = pr.GetValue(updatedDescArg);
                if (string.IsNullOrEmpty(stringUpdatedDesc))
                {
                    Console.WriteLine("Given description is empty");
                }
                else
                {
                    try
                    {
                        var task = FileUtilities.ReadTaskFromFile(taskID);
                        task.Description = stringUpdatedDesc;
                        task.UpdatedAt = DateTime.Now;
                        FileUtilities.WriteTaskToFile(task);
                        Console.WriteLine($"Task updated successfully (ID: {task.ID})");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not read task: {ex.Message}");
                    }
                }
            }
        });

        return cmd;
    }
}
