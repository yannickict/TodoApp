namespace TodoApp;

public class ClubTodo : Todo
{
    private readonly string _club;
    public ClubTodo(string content, string club) : base(content)
    {
        _club = club;
    }
}