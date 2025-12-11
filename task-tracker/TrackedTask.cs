

public class TrackedTask
{
    public int ID {get; set;}
    public string? Description {get; set;}
    public TaskStatus Status {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}

    public override string ToString()
    {
        var map = new Dictionary<TaskStatus, string>()
        {
            { TaskStatus.Todo, "todo" },
            { TaskStatus.InProgress, "in-progress" },
            { TaskStatus.Done, "done" }
        };
        return $"Task ID: {ID}, " +
        $"Description: {Description}, " +
        $"Status: {map[Status]}, " +
        $"Created At: {CreatedAt}, " +
        $"{(UpdatedAt != DateTime.MinValue ? $"Updated At: {UpdatedAt}": "")}";
    }
}