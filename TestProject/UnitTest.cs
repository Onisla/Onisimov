using NUnit.Framework;
using System;
using Main;

namespace TestProject
{

    [TestFixture]
    public class ReservationManagerTests
    {
        [Test]
        public void AddRestaurant_ValidInput_ShouldAddRestaurant()
        {
            // Arrange
            ReservationManager manager = new ReservationManager();

            // Act
            manager.AddRestaurant("TestRestaurant", 5);

            // Assert
            Assert.AreEqual(1, manager.Restaurants.Count);
            Assert.AreEqual("TestRestaurant", manager.Restaurants[0].Name);
            Assert.AreEqual(5, manager.Restaurants[0].Tables.Length);
        }

        [Test]
        public void AddRestaurant_InvalidTableCount_ShouldThrowException()
        {
            // Arrange
            ReservationManager manager = new ReservationManager();

            // Act & Assert
            Assert.Throws<Exception>(() => manager.AddRestaurant("TestRestaurant", -5));
        }

        [Test]
        public void BookTable_ValidInput_ShouldBookTable()
        {
            // Arrange
            ReservationManager manager = new ReservationManager();
            manager.AddRestaurant("TestRestaurant", 5);

            // Act
            bool result = manager.BookTable("TestRestaurant", DateTime.Now, 2);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(manager.Restaurants[0].Tables[2].IsBooked(DateTime.Now));
        }

        [Test]
        public void BookTable_InvalidTableNumber_ShouldThrowException()
        {
            // Arrange
            ReservationManager manager = new ReservationManager();
            manager.AddRestaurant("TestRestaurant", 3);

            // Act & Assert
            Assert.Throws<Exception>(() => manager.BookTable("TestRestaurant", DateTime.Now, 5));
        }

        [Test]
        public void CountAvailableTables_ValidInput_ShouldReturnCorrectCount()
        {
            // Arrange
            ReservationManager manager = new ReservationManager();
            manager.AddRestaurant("TestRestaurant", 3);
            manager.AddRestaurant("AnotherRestaurant", 2);

            DateTime date = DateTime.Now;

            // Book some tables
            manager.BookTable("TestRestaurant", date, 0);
            manager.BookTable("TestRestaurant", date, 1);
            manager.BookTable("AnotherRestaurant", date, 0);

            // Act
            int count = manager.CountAvailableTables(manager.Restaurants[0], date);

            // Assert
            Assert.AreEqual(1, count);
        }
    }

}