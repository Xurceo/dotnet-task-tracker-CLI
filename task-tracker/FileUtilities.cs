using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace task_tracker;

public static class FileUtilities
{
    public static string DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    public static string DefaultList = "DefaultList.json";
    public static JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() },
        PropertyNameCaseInsensitive = true,
    };

    public static void CreateFile(string fileName)
    {
        File.WriteAllText(Path.Combine(DefaultPath, fileName), "[]");
    }

    public static void WriteTaskToFile(TrackedTask task, string fileName = "DefaultList.json")
    {
        List<TrackedTask> tasks = new List<TrackedTask>();
        var filePath = Path.Combine(DefaultPath, fileName);

        if (File.Exists(filePath))
        {
            string existingJson = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(existingJson))
            {
                tasks = JsonSerializer.Deserialize<List<TrackedTask>>(existingJson, options) ?? new List<TrackedTask>();
            }
        }

        int index = tasks.FindIndex(x => x.ID == task.ID);

        if (index != -1)
        {
            tasks[index] = task;
        }
        else
        {
            tasks.Add(task);
        }

        string newJson = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(filePath, newJson);
    }

    public static TrackedTask ReadTaskFromFile(int id, string fileName = "DefaultList.json")
    {
        var filePath = Path.Combine(DefaultPath, fileName);
        TrackedTask task = new();
        
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var tasks = JsonSerializer.Deserialize<List<TrackedTask>>(json, options);

            if (tasks != null && tasks.Count > 0)
            {
                if (id >= 0)
                {
                    task = tasks.Find(x => x.ID == id) ?? throw new Exception($"Task with ID: {id} not found");
                }
                else
                {
                    task = tasks.Last();
                }
                return task;
            }
        }

        return task;
    }

    public static List<TrackedTask> ReadAllTasksFromFile(string fileName = "DefaultList.json")
    {
        var filePath = Path.Combine(DefaultPath, fileName);
        TrackedTask task = new();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var tasks = JsonSerializer.Deserialize<List<TrackedTask>>(json, options);

            if (tasks != null && tasks.Count > 0)
            {
                return tasks;
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }
        return [];
    }

    public static void DeleteTaskFromFile(int id, string fileName = "DefaultList.json")
    {
        var filePath = Path.Combine(DefaultPath, fileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var tasks = JsonSerializer.Deserialize<List<TrackedTask>>(json, options);

            if (tasks != null && tasks.Count > 0)
            {
                if (id >= 0)
                {
                    var task = tasks.Find(x => x.ID == id) ?? throw new Exception($"Task with ID: {id} not found");
                    tasks.Remove(task);
                }
                else
                {
                    tasks.Remove(tasks.Last());
                }
            }

            string tasksJSON;

            if(tasks != null)
            {
                tasksJSON = JsonSerializer.Serialize(tasks, options);
            }
            else
            {
                tasksJSON = JsonSerializer.Serialize<List<TrackedTask>>([], options);
            }

            File.WriteAllText(filePath, tasksJSON);
        }
    }
}