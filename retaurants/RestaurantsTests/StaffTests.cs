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
    public class StaffTests
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
            var data = new List<Staff>
            {
                new Staff {FirstName="Item1"},
                new Staff {FirstName="Item2"},
                new Staff {FirstName="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Staff>>();
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Staffs).Returns(mockSet.Object);
            var business = new StaffBusiness(mockContext.Object);
            var Staffs = business.GetAll();
            Assert.AreEqual(3, Staffs.Count);
            Assert.AreEqual("Item1", Staffs[0].FirstName);
            Assert.AreEqual("Item2", Staffs[1].FirstName);
            Assert.AreEqual("Item3", Staffs[2].FirstName);

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
            var data = new List<Staff>
            {
                new Staff {FirstName="Item1"},
                new Staff {FirstName="Item2"},
                new Staff {FirstName="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Staff>>();
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Staffs).Returns(mockSet.Object);
            var Staff = new Staff() { FirstName = "Item4" };
            var business = new StaffBusiness(mockContext.Object);
            business.Add(Staff);
            mockSet.Verify(m => m.Add(It.IsAny<Staff>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned Staff is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Staff>
            {
                 new Staff {Id =1, FirstName="Item1" },
                new Staff {Id =2, FirstName="Item2" },
                new Staff {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Staff>>();
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Staffs).Returns(mockSet.Object);
            var business = new StaffBusiness(mockContext.Object);
            var Staff = business.Get(1);
            Assert.AreEqual(1, Staff.Id);
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
            var data = new List<Staff>
            {
                 new Staff {Id =1, FirstName="Item1" },
                new Staff {Id =2, FirstName="Item2" },
                new Staff {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Staff>>();
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Staffs).Returns(mockSet.Object);
            var business = new StaffBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if Staff with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Staff>
            {
                new Staff {Id =1, FirstName="Item1" },
                new Staff {Id =2, FirstName="Item2" },
                new Staff {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Staff>>();
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Staffs).Returns(mockSet.Object);
            var business = new StaffBusiness(mockContext.Object);
            var Staffs = business.GetAll();
            int deleteId = 1; business.Delete(Staffs[0].Id);
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
            var data = new List<Staff>
            {
                new Staff {Id =1, FirstName="Item1" },
                new Staff {Id =2, FirstName="Item2" },
                new Staff {Id =3, FirstName="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Staff>>();
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Staff>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Staffs).Returns(mockSet.Object);
            var business = new StaffBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Staff>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
    

