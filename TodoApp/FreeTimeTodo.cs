namespace TodoApp;

public class FreeTimeTodo : Todo
{
    private readonly string _location;
    public FreeTimeTodo(string content, string location) : base(content)
    {
        _location = location;
    }
}