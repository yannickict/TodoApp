using TodoApp;

namespace TodoAppUT
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeFirstNameAndLastName()
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
            var person = new Person("Hegi", "Marvin");
            
        }
    }
}
