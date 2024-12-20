namespace TodoApp;

public class Todo
{
    public readonly int _id;
    protected static int idCount = 0;
    private string _content;
    internal string _type;
    
    public bool IsCompleted { get; private set; } = false;
    public Todo(string content)
    {
        _id = Interlocked.Increment(ref idCount);
        _content = content;
        _type = "General";
    }

    public override string ToString()
    {
        return "Id: 00" + _id + " | Type: General\n" + "Content: " + _content + "\n";
    }
}