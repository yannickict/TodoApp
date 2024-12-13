namespace TodoApp;

public class Todo
{
    public readonly int _id;
    protected static int idCount = 1;
    private string _content;
    public bool IsCompleted { get; private set; } = false;
    public Todo(string content)
    {
        _id = Interlocked.Increment(ref idCount);
        _content = content;
    }
}