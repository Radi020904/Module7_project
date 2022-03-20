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
    public class MenuTests
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
            var data = new List<Menu>
            {
                new Menu {Type="Item1"},
                new Menu {Type="Item2"},
                new Menu {Type="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Menu>>();
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Menus).Returns(mockSet.Object);
            var business = new MenuBusiness(mockContext.Object);
            var menus = business.GetAll();
            Assert.AreEqual(3, menus.Count);
            Assert.AreEqual("Item1", menus[0].Type);
            Assert.AreEqual("Item2", menus[1].Type);
            Assert.AreEqual("Item3", menus[2].Type);

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
            var data = new List<Menu>
            {
                new Menu {Type="Item1"},
                new Menu {Type="Item2"},
                new Menu {Type="Item3"},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Menu>>();
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Menus).Returns(mockSet.Object);
            var Menu = new Menu() { Type = "Item4" };
            var business = new MenuBusiness(mockContext.Object);
            business.Add(Menu);
            mockSet.Verify(m => m.Add(It.IsAny<Menu>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned Menu is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<Menu>
            {
                 new Menu {Id =1, Type="Item1" },
                new Menu {Id =2, Type="Item2" },
                new Menu {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Menu>>();
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Menus).Returns(mockSet.Object);
            var business = new MenuBusiness(mockContext.Object);
            var Menu = business.Get(1);
            Assert.AreEqual(1, Menu.Id);
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
            var data = new List<Menu>
            {
                 new Menu {Id =1, Type="Item1" },
                new Menu {Id =2, Type="Item2" },
                new Menu {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Menu>>();
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.Menus).Returns(mockSet.Object);
            var business = new MenuBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if Menu with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<Menu>
            {
                new Menu {Id =1, Type="Item1" },
                new Menu {Id =2, Type="Item2" },
                new Menu {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Menu>>();
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Menus).Returns(mockSet.Object);
            var business = new MenuBusiness(mockContext.Object);
            var Menus = business.GetAll();
            int deleteId = 1; business.Delete(Menus[0].Id);
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
            var data = new List<Menu>
            {
                new Menu {Id =1, Type="Item1" },
                new Menu {Id =2, Type="Item2" },
                new Menu {Id =3, Type="Item3" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Menu>>();
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Menu>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.Menus).Returns(mockSet.Object);
            var business = new MenuBusiness(mockContext.Object);
            business.Delete(4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<Menu>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}
