namespace TodoApp;

public class Todo
{
    public readonly int Id;
    protected static int IdCount = 0;
    private string _content;
    public string Type;
    
    public bool IsCompleted { get; private set; } = false;
    public Todo(string content)
    {
        Id = Interlocked.Increment(ref IdCount);
        _content = content;
        Type = "General";
    }

    public override string ToString()
    {
        return "Id: 00" + Id + " | Type:" + Type + " \n" + "Content: " + _content + "\n";
    }
}