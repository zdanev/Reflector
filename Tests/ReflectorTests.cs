using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Reflector.Business;
using Reflector.Tools;

namespace Reflector.Tests
{
    [TestClass]
    public class ReflectorTests
    {
        [TestMethod]
        public void Reflector_ToObject()
        {
            // arrange
            var input = new Dictionary<string, string>
            {
                ["FirstName"] = "John",
                ["LastName"] = "Smith",
                ["Age"] = "50",
                ["BirthDate"] = "2/3/1974"
            };

            // act
            var person = input.ToObject("Reflector.Business.Person") as Person;

            // assert
            Assert.IsNotNull(person);
            Assert.AreEqual("John", person.FirstName);
            Assert.AreEqual("Smith", person.LastName);
            Assert.AreEqual(50, person.Age);
            Assert.AreEqual(new DateTime(1974, 2, 3), person.BirthDate);
        }

        [TestMethod]
        public void Reflector_ToDictionary()
        {
            // arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Smith",
                Age = 50,
                BirthDate = new DateTime(1974, 2, 3)
            };

            // act
            var dic = person.ToDictionary();

            // assert
            Assert.IsNotNull(dic);
            Assert.AreEqual("John", dic["FirstName"]);
            Assert.AreEqual("Smith", dic["LastName"]);
            Assert.AreEqual("50", dic["Age"]);
            Assert.AreEqual("2/3/1974", dic["BirthDate"]);
        }
    }
}