namespace TodoApp;

public class Person
{
    public readonly string FirstName;
    public readonly string LastName;
    
    private List<Todo> _todos = new List<Todo>();
    
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void AddTodo(string content)
    {
        var todo = new Todo(content);
        _todos.Add(todo);
    }

    public void AddWorkTodo(string content, DateTime deadline, string client)
    {
        var todo = new WorkTodo(content, deadline, client);
        _todos.Add(todo);
    }
    
    public void AddClubTodo(string content, string club)
    {
        var todo = new ClubTodo(content, club);
        _todos.Add(todo);
    }

    public void AddFreeTimeTodo(string content, string location)
    {
        var todo = new FreeTimeTodo(content, location);
        _todos.Add(todo);
    }

    public void RemoveTodo(Todo todo)
    {
        _todos.Remove(todo);
    }

    public Todo GetTodoById(int id)
    {
        foreach (var todo in _todos)
        {
            if(todo.Id == id)
            {
                return todo;
            }
        }
        return null;
    }

    public List<Todo> GetTodos()
    {
        return _todos;
    }
}