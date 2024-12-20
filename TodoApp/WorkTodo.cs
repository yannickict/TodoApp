using Microsoft.VisualBasic.CompilerServices;

namespace TodoApp;

public class WorkTodo : Todo
{
    private readonly DateTime _deadline;
    private readonly string _client;
    public WorkTodo(string content, DateTime deadline, string client) : base(content)
    {
        _deadline = deadline;
        _client = client;
        _type = "Work";
    }

    public override string ToString()
    {
        return base.ToString() + "Deadline: " + _deadline + "\n" + "Client: " + _client + "\n";
    }
}