using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using restaurants.Business;
using restaurants.Data;
using restaurants.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if elements of the test list are equal to elements of the returned list from the business.
        /// </summary>
        [TestCase]
        public void GetAllTest()
        {
            var data = new List<Meal>
            {
                new Meal {Type="Item1"},
                new Meal {Type="Item2"},
                new Meal {Type="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Meal>>();
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Meals).Returns(mockSet.Object);
            var business = new MealBusiness(mockContext.Object);
            var Meals = business.GetAll();
            Assert.AreEqual(3, Meals.Count);
            Assert.AreEqual("Item1", Meals[0].Type);
            Assert.AreEqual("Item2", Meals[1].Type);
            Assert.AreEqual("Item3", Meals[2].Type);

        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Verifies if methods "Add" and "SaveChanges" were performed.
        /// </summary>
        [TestCase]
        public void AddTest()
        {
            var data = new List<Meal>
            {
                new Meal {Type="Item1"},
                new Meal {Type="Item2"},
                new Meal {Type="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Meal>>();
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Meals).Returns(mockSet.Object);
            var Meal = new Meal() { Type = "Item4" };
            var business = new MealBusiness(mockContext.Object);
            business.Add(Meal);
            mockSet.Verify(m => m.Add(It.IsAny<Meal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned Meal is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Meal>
            {
                 new Meal {Id =1, Type="Item1" },
                new Meal {Id =2, Type="Item2" },
                new Meal {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Meal>>();
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Meals).Returns(mockSet.Object);
            var business = new MealBusiness(mockContext.Object);
            var Meal = business.Get(1);
            Assert.AreEqual(1, Meal.Id);
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if method "Get" will return null, if it is given non-existenting id.
        /// </summary>
        [TestCase]
        public void GetTestWithOutExistingId()
        {
            var data = new List<Meal>
            {
                 new Meal {Id =1, Type="Item1" },
                new Meal {Id =2, Type="Item2" },
                new Meal {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Meal>>();
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Meals).Returns(mockSet.Object);
            var business = new MealBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if Meal with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Meal>
            {
                new Meal {Id =1, Type="Item1" },
                new Meal {Id =2, Type="Item2" },
                new Meal {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Meal>>();
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Meals).Returns(mockSet.Object);
            var business = new MealBusiness(mockContext.Object);
            var Meals = business.GetAll();
            int deleteId = 1; business.Delete(Meals[0].Id);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.Id == deleteId));
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if method "Delete" will throw exeption, if it is given non-existenting id.
        /// </summary>
        [TestCase]
        public void DeleteTestWithOutExistingId()
        {
            var data = new List<Meal>
            {
                new Meal {Id =1, Type="Item1" },
                new Meal {Id =2, Type="Item2" },
                new Meal {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Meal>>();
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Meal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Meals).Returns(mockSet.Object);
            var business = new MealBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Meal>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}