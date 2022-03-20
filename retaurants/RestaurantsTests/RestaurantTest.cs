using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using restaurants.Business;
using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsTests
{
    public class RestaurantTest
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
            var data = new List<Restaurant>
            {
                new Restaurant {Name="Item1"},
                new Restaurant {Name="Item2"},
                new Restaurant {Name="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Restaurants).Returns(mockSet.Object);
            var business = new RestaurantBusiness(mockContext.Object);
            var Restaurants = business.GetAll();
            Assert.AreEqual(3, Restaurants.Count);
            Assert.AreEqual("Item1", Restaurants[0].Name);
            Assert.AreEqual("Item2", Restaurants[1].Name);
            Assert.AreEqual("Item3", Restaurants[2].Name);

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
            var data = new List<Restaurant>
            {
                new Restaurant {Name="Item1"},
                new Restaurant {Name="Item2"},
                new Restaurant {Name="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Restaurants).Returns(mockSet.Object);
            var Restaurant = new Restaurant() { Name = "Item4" };
            var business = new RestaurantBusiness(mockContext.Object);
            business.Add(Restaurant);
            mockSet.Verify(m => m.Add(It.IsAny<Restaurant>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned Restaurant is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Restaurant>
            {
                 new Restaurant {Id =1, Name="Item1" },
                new Restaurant {Id =2, Name="Item2" },
                new Restaurant {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Restaurants).Returns(mockSet.Object);
            var business = new RestaurantBusiness(mockContext.Object);
            var Restaurant = business.Get(1);
            Assert.AreEqual(1, Restaurant.Id);
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
            var data = new List<Restaurant>
            {
                 new Restaurant {Id =1, Name="Item1" },
                new Restaurant {Id =2, Name="Item2" },
                new Restaurant {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Restaurants).Returns(mockSet.Object);
            var business = new RestaurantBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if Restaurant with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Restaurant>
            {
                new Restaurant {Id =1, Name="Item1" },
                new Restaurant {Id =2, Name="Item2" },
                new Restaurant {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Restaurants).Returns(mockSet.Object);
            var business = new RestaurantBusiness(mockContext.Object);
            var Restaurants = business.GetAll();
            int deleteId = 1; business.Delete(Restaurants[0].Id);
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
            var data = new List<Restaurant>
            {
                new Restaurant {Id =1, Name="Item1" },
                new Restaurant {Id =2, Name="Item2" },
                new Restaurant {Id =3, Name="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Restaurant>>();
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Restaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Restaurants).Returns(mockSet.Object);
            var business = new RestaurantBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Restaurant>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
