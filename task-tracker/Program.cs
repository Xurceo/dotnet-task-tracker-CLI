using System.CommandLine;
using System.CommandLine.Parsing;
using task_tracker.Commands;

namespace task_tracker;

class Program
{
    static int Main(string[] args)
    {
        var root = new RootCommand("Task Tracker CLI");
        root.Subcommands.Add(AddCommand.Build());
        root.Subcommands.Add(ListCommand.Build());
        root.Subcommands.Add(UpdateCommand.Build());
        root.Subcommands.Add(DeleteCommand.Build());
        root.Subcommands.Add(MarkCommand.Build());

        ParseResult parseResult = root.Parse(args);
        return parseResult.Invoke();
    }
}