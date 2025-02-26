using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedLINQ
{
    /// <summary>
    /// Represents a person with an ID, name, and birthdate.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the unique ID of the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthdate of the person.
        /// </summary>
        public DateTime Birthday { get; set; }
    }

    /// <summary>
    /// Provides methods to manage and query a collection of people using LINQ.
    /// </summary>
    public class PeopleManager
    {
        /// <summary>
        /// Stores an array of 1,000,000 people.
        /// </summary>
        private Person[] data;

        /// <summary>
        /// Initializes the data field with 1,000,000 unique people.
        /// </summary>
        public void InitializeData()
        {
            Random rand = new Random();
            data = Enumerable.Range(1, 1_000_000)
                .Select(i => new Person
                {
                    Id = i,
                    Name = $"Person{i}",
                    Birthday = new DateTime(rand.Next(1950, 2022), rand.Next(1, 13), rand.Next(1, 28))
                }).ToArray();
        }

        /// <summary>
        /// Retrieves all people born after the specified date.
        /// </summary>
        /// <param name="date">The cutoff date for filtering people.</param>
        /// <returns>A list of people born after the given date.</returns>
        public IEnumerable<Person> GetPeopleBornAfter(DateTime date)
        {
            return data.Where(p => p.Birthday > date);
        }

        /// <summary>
        /// Retrieves all people with the specified name.
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A list of people with the specified name.</returns>
        public IEnumerable<Person> GetPeopleByName(string name)
        {
            return data.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Retrieves a person by their unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the person.</param>
        /// <returns>The person with the matching ID, or null if not found.</returns>
        public Person GetPersonById(int id)
        {
            return data.FirstOrDefault(p => p.Id == id);
        }
    }
}

﻿
