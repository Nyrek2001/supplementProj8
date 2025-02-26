using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;

namespace AdvancedLINQ.Tests
{
    public class PeopleManagerTests
    {
        private readonly PeopleManager _peopleManager;

        public PeopleManagerTests()
        {
            _peopleManager = new PeopleManager();
            _peopleManager.InitializeData();
        }

        /// <summary>
        /// Tests whether the method correctly retrieves people born after a given date.
        /// </summary>
        [Fact]
        public void GetPeopleBornAfter_ShouldReturnPeopleWithBirthdaysAfterGivenDate()
        {
            // Arrange
            DateTime cutoffDate = new DateTime(2000, 1, 1);

            // Act
            var result = _peopleManager.GetPeopleBornAfter(cutoffDate).ToList();

            // Assert
            Assert.All(result, person => Assert.True(person.Birthday > cutoffDate));
        }

        /// <summary>
        /// Tests whether the method retrieves all people with a specific name.
        /// </summary>
        [Fact]
        public void GetPeopleByName_ShouldReturnPeopleWithGivenName()
        {
            // Arrange
            string testName = "Person500";

            // Act
            var result = _peopleManager.GetPeopleByName(testName).ToList();

            // Assert
            Assert.All(result, person => Assert.Equal(testName, person.Name));
        }

        /// <summary>
        /// Tests whether the method retrieves a person by their unique ID.
        /// </summary>
        [Fact]
        public void GetPersonById_ShouldReturnCorrectPerson()
        {
            // Arrange
            int testId = 250000;

            // Act
            var result = _peopleManager.GetPersonById(testId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testId, result.Id);
        }

        /// <summary>
        /// Tests whether the method returns null when searching for a non-existing ID.
        /// </summary>
        [Fact]
        public void GetPersonById_ShouldReturnNullForInvalidId()
        {
            // Arrange
            int invalidId = 2000000; // Out of range

            // Act
            var result = _peopleManager.GetPersonById(invalidId);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests whether an empty result is returned when searching for a non-existing name.
        /// </summary>
        [Fact]
        public void GetPeopleByName_ShouldReturnEmptyListForNonExistingName()
        {
            // Arrange
            string invalidName = "NonExistingName";

            // Act
            var result = _peopleManager.GetPeopleByName(invalidName);

            // Assert
            Assert.Empty(result);
        }
    }
}

