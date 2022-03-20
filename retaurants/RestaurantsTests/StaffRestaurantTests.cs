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
    public class StaffRestaurantTests
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
            var data = new List<StaffRestaurant>
            {
                new StaffRestaurant {StaffId = 1},
                new StaffRestaurant {StaffId = 2},
                new StaffRestaurant {StaffId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<StaffRestaurant>>();
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.StaffRestaurants).Returns(mockSet.Object);
            var business = new StaffRestaurantBusiness(mockContext.Object);
            var StaffRestaurants = business.GetAll();
            Assert.AreEqual(3, StaffRestaurants.Count);
            Assert.AreEqual(1, StaffRestaurants[0].StaffId);
            Assert.AreEqual(2, StaffRestaurants[1].StaffId);
            Assert.AreEqual(3, StaffRestaurants[2].StaffId);

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
            var data = new List<StaffRestaurant>
            {
                new StaffRestaurant {StaffId = 1},
                new StaffRestaurant {StaffId = 2},
                new StaffRestaurant {StaffId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<StaffRestaurant>>();
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.StaffRestaurants).Returns(mockSet.Object);
            var StaffRestaurant = new StaffRestaurant() { StaffId = 4 };
            var business = new StaffRestaurantBusiness(mockContext.Object);
            business.Add(StaffRestaurant);
            mockSet.Verify(m => m.Add(It.IsAny<StaffRestaurant>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned StaffRestaurant is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<StaffRestaurant>
            {
                 new StaffRestaurant {StaffId = 1, RestaurantId = 1},
                new StaffRestaurant {StaffId = 2},
                new StaffRestaurant {StaffId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<StaffRestaurant>>();
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.StaffRestaurants).Returns(mockSet.Object);
            var business = new StaffRestaurantBusiness(mockContext.Object);
            var StaffRestaurant = business.Get(1, 1);
            Assert.AreEqual(1, StaffRestaurant.StaffId);
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
            var data = new List<StaffRestaurant>
            {
                 new StaffRestaurant {StaffId = 1},
                new StaffRestaurant {StaffId = 2},
                new StaffRestaurant {StaffId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<StaffRestaurant>>();
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.StaffRestaurants).Returns(mockSet.Object);
            var business = new StaffRestaurantBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4, 4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if StaffRestaurant with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<StaffRestaurant>
            {
                new StaffRestaurant {StaffId = 1, RestaurantId = 1},
                new StaffRestaurant {StaffId = 2},
                new StaffRestaurant {StaffId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<StaffRestaurant>>();
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.StaffRestaurants).Returns(mockSet.Object);
            var business = new StaffRestaurantBusiness(mockContext.Object);
            var StaffRestaurants = business.GetAll();
            int deleteId = 1; business.Delete(StaffRestaurants[0].StaffId, StaffRestaurants[0].RestaurantId);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.StaffId == deleteId));
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
            var data = new List<StaffRestaurant>
            {
                new StaffRestaurant {StaffId = 1},
                new StaffRestaurant {StaffId = 2},
                new StaffRestaurant {StaffId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<StaffRestaurant>>();
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<StaffRestaurant>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.StaffRestaurants).Returns(mockSet.Object);
            var business = new StaffRestaurantBusiness(mockContext.Object);
            business.Delete(4, 4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<StaffRestaurant>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}

