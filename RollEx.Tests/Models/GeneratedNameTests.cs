using RollEx.Services;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace RollEx.Tests
{
    public class GeneratedNameTests
    {
        private GeneratedName unitToTest;

        [Theory]
        [ClassData(typeof(TwoWordNames))]
        public void GeneratedName_Valid(string firstName, string lastName)
        {
            // Arrange
            var name = new List<string> { firstName, lastName };

            // Act
            unitToTest = new GeneratedName(name);

            // Assert
            Assert.False(unitToTest.OneWordName);
            Assert.Equal(firstName, unitToTest.FirstName);
            Assert.Equal(lastName, unitToTest.LastName);
        }

        [Theory]
        [ClassData(typeof(OneWordNames))]
        public void GeneratedName_OneWordName(string firstName)
        {
            // Arrange
            var name = new List<string> { firstName };

            // Act
            unitToTest = new GeneratedName(name);

            // Assert
            Assert.True(unitToTest.OneWordName);
            Assert.Equal(firstName, unitToTest.FirstName);
            Assert.True(string.IsNullOrEmpty(unitToTest.LastName));
        }
    }

    public class OneWordNames : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Hello" };
            yield return new object[] { "Cheese" };
            yield return new object[] { "batman" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TwoWordNames : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Boston", "Teaparty" };
            yield return new object[] { "Aston", "Martin" };
            yield return new object[] { "Aston", "Martin" };
            yield return new object[] { "Optimus", "Prime" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
