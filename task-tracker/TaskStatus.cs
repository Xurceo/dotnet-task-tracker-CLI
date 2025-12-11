using System.Text.Json.Serialization;
using System.Runtime.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskStatus
{
    [EnumMember(Value = "todo")]
    Todo,
    
    [EnumMember(Value = "in-progress")]
    InProgress,
    
    [EnumMember(Value = "done")]
    Done
}