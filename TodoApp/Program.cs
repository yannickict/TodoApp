using System;
using System.Collections.Generic;
using TodoApp;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            bool done = false;

            while (!done)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a new person");
                Console.WriteLine("2. Select an existing person");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewPerson(people);
                        break;
                    case "2":
                        ManageSelectedPerson(people);
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine("Exiting application.");
        }

        static void AddNewPerson(List<Person> people)
        {
            Console.Clear();
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Person newPerson = new Person(firstName, lastName);
            people.Add(newPerson);
            Console.WriteLine($"Added person: {firstName} {lastName}");
            Console.ReadLine();
        }

        static void ManageSelectedPerson(List<Person> people)
        {
            Console.Clear();

            if (people.Count == 0)
            {
                Console.WriteLine("No people available. Add a person first.");
                Console.ReadLine();
                return;
            }

            Person selectedPerson = SelectPerson(people);
            if (selectedPerson == null)
                return;

            bool managingTodos = true;
            while (managingTodos)
            {
                Console.Clear();
                Console.WriteLine($"Managing todos for {selectedPerson.FirstName} {selectedPerson.LastName}.");
                Console.WriteLine("1. Create a new todo");
                Console.WriteLine("2. View existing todos");
                Console.WriteLine("3. Remove a todo");
                Console.WriteLine("4. Back to main menu");

                string todoChoice = Console.ReadLine();
                switch (todoChoice)
                {
                    case "1":
                        CreateTodo(selectedPerson);
                        break;
                    case "2":
                        ViewTodos(selectedPerson);
                        break;
                    case "3":
                        RemoveTodo(selectedPerson);
                        break;
                    case "4":
                        managingTodos = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static Person SelectPerson(List<Person> people)
        {
            Console.WriteLine("Select a person:");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {people[i].FirstName} {people[i].LastName}");
            }

            if (int.TryParse(Console.ReadLine(), out int personIndex) && personIndex > 0 && personIndex <= people.Count)
            {
                return people[personIndex - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter a valid number corresponding to a person.");
                Console.ReadLine();
                return null;
            }
        }

        static void CreateTodo(Person person)
        {
            Console.Clear();
            Console.WriteLine("Select type of todo:");
            Console.WriteLine("1. General");
            Console.WriteLine("2. Work");
            Console.WriteLine("3. Club");
            Console.WriteLine("4. Free Time");

            string todoType = Console.ReadLine();
            Console.Write("Enter content: ");
            string content = Console.ReadLine();

            switch (todoType)
            {
                case "1":
                    person.AddTodo(content);
                    Console.WriteLine("Added general todo.");
                    break;
                case "2":
                    Console.Write("Enter deadline (yyyy-mm-dd): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime deadline))
                    {
                        Console.WriteLine("Invalid date format. Please use yyyy-mm-dd.");
                        break;
                    }
                    Console.Write("Enter client name: ");
                    string client = Console.ReadLine();
                    person.AddWorkTodo(content, deadline, client);
                    Console.WriteLine("Added work todo.");
                    break;
                case "3":
                    Console.Write("Enter club name: ");
                    string club = Console.ReadLine();
                    person.AddClubTodo(content, club);
                    Console.WriteLine("Added club todo.");
                    break;
                case "4":
                    Console.Write("Enter location: ");
                    string location = Console.ReadLine();
                    person.AddFreeTimeTodo(content, location);
                    Console.WriteLine("Added free time todo.");
                    break;
                default:
                    Console.WriteLine("Invalid todo type. Please choose 1, 2, 3, or 4.");
                    break;
            }
            Console.ReadLine();
        }

        static void ViewTodos(Person person)
        {
            Console.Clear();
            Console.WriteLine("Existing todos:");
            var todos = person.GetTodos();

            if (todos.Count == 0)
            {
                Console.WriteLine("No todos found.");
            }
            else
            {
                foreach (var todo in todos)
                {
                    Console.WriteLine(todo.ToString());
                }
            }
            Console.ReadLine();
        }

        static void RemoveTodo(Person person)
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the todo to remove:");

            if (int.TryParse(Console.ReadLine(), out int todoId))
            {
                Todo todoById = person.GetTodoById(todoId);
                if (todoById != null)
                {
                    person.RemoveTodo(todoById);
                    Console.WriteLine($"Todo with ID {todoId} removed.");
                }
                else
                {
                    Console.WriteLine($"No todo found with ID {todoId}. Ensure the ID exists and try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric ID.");
            }
            Console.ReadLine();
        }
    }
}
