using TodoApp;

namespace TodoAppUT
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void CheckConstructor()
        {
            string firstName = "Hegi";
            string lastName = "Marvin";

            var person = new Person(firstName, lastName);

            Assert.AreEqual(firstName, person.FirstName);
            Assert.AreEqual(lastName, person.LastName);
        }

        [TestMethod]
        public void CheckIfCanAddTodo()
        {
            string content = "Task 1";
            var person = new Person("Hegi", "Marvin");
            person.AddTodo(content);

            var todos = person.GetTodos();
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual(content, todos[0].ToString().Split("Content: ")[1].Trim());
        }

        [TestMethod]
        public void CheckIfCanAddWorkTodo()
        {
            string content = "Work Task";
            DateTime deadline = DateTime.Now.AddDays(7);
            string client = "Client A";

            var person = new Person("Hegi", "Marvin");
            person.AddWorkTodo(content, deadline, client);

            var todos = person.GetTodos();
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual("Work", todos[0].Type);
        }

        [TestMethod]
        public void CheckIfCanAddClubTodo()
        {
            string content = "Club Meeting";
            string club = "Chess Club";

            var person = new Person("Hegi", "Marvin");
            person.AddClubTodo(content, club);

            var todos = person.GetTodos();
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual("Club", todos[0].Type);
        }

        [TestMethod]
        public void CheckIfCanAddFreeTimeTodo()
        {
            string content = "Play Tennis";
            string location = "Local Court";

            var person = new Person("Hegi", "Marvin");
            person.AddFreeTimeTodo(content, location);

            var todos = person.GetTodos();
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual("FreeTime", todos[0].Type);
        }

        [TestMethod]
        public void CheckIfGetTodoByIdReturnsCorrect()
        {
            var person = new Person("Hegi", "Marvin");
            person.AddTodo("Task 1");
            person.AddTodo("Task 2");

            var todos = person.GetTodos();
            int expectedId = todos[1].Id;

            var todo = person.GetTodoById(expectedId);

            Assert.IsNotNull(todo);
            Assert.AreEqual(expectedId, todo.Id);
        }

        [TestMethod]
        public void CheckIfRemoveTodoWorks()
        {
            var person = new Person("Hegi", "Marvin");
            person.AddTodo("Task 1");
            var todoToRemove = person.GetTodos()[0];

            person.RemoveTodo(todoToRemove);

            Assert.AreEqual(0, person.GetTodos().Count);
        }

        [TestMethod]
        public void CheckIfAddingTodoIncreasesCount()
        {
            var person = new Person("Hegi", "Marvin");
            person.AddTodo("Task 1");
            person.AddWorkTodo("Task 2", DateTime.Now.AddDays(7), "Client B");
            person.AddClubTodo("Task 3", "Club A");

            Assert.AreEqual(3, person.GetTodos().Count);
        }
    }
}
