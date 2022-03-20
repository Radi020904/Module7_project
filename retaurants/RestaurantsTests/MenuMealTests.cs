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
    public class MenuMealTests
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
            var data = new List<MenuMeal>
            {
                new MenuMeal {MealId = 1},
                new MenuMeal {MealId = 2},
                new MenuMeal {MealId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<MenuMeal>>();
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.MenuMeals).Returns(mockSet.Object);
            var business = new MenuMealBusiness(mockContext.Object);
            var MenuMeals = business.GetAll();
            Assert.AreEqual(3, MenuMeals.Count);
            Assert.AreEqual(1, MenuMeals[0].MealId);
            Assert.AreEqual(2, MenuMeals[1].MealId);
            Assert.AreEqual(3, MenuMeals[2].MealId);

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
            var data = new List<MenuMeal>
            {
                new MenuMeal {MealId = 1},
                new MenuMeal {MealId = 2},
                new MenuMeal {MealId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<MenuMeal>>();
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.MenuMeals).Returns(mockSet.Object);
            var MenuMeal = new MenuMeal() { MealId = 4 };
            var business = new MenuMealBusiness(mockContext.Object);
            business.Add(MenuMeal);
            mockSet.Verify(m => m.Add(It.IsAny<MenuMeal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        /// <summary>
        /// Creates Mockset which is connected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if the id of the returned MenuMeal is equal to the given id.
        /// </summary>
        [TestCase]
        public void GetTestWithExistingId()
        {
            var data = new List<MenuMeal>
            {
                 new MenuMeal {MealId = 1, MenuId = 1},
                new MenuMeal {MealId = 2},
                new MenuMeal {MealId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<MenuMeal>>();
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.MenuMeals).Returns(mockSet.Object);
            var business = new MenuMealBusiness(mockContext.Object);
            var MenuMeal = business.Get(1, 1);
            Assert.AreEqual(1, MenuMeal.MealId);
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
            var data = new List<MenuMeal>
            {
                 new MenuMeal {MealId = 1},
                new MenuMeal {MealId = 2},
                new MenuMeal {MealId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<MenuMeal>>();
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(c => c.MenuMeals).Returns(mockSet.Object);
            var business = new MenuMealBusiness(mockContext.Object);
            Assert.IsNull(business.Get(4,4));
        }
        /// <summary>
        /// Creates Mockset which isconnected to test list.
        /// Creates MockContext whose Dbset is substituted with the Mockset.
        /// Creates Business using MockContext.
        /// Checks if MenuMeal with deleted id still exist.
        /// </summary>
        [TestCase]
        public void DeleteTestWithExistingId()
        {
            var data = new List<MenuMeal>
            {
                new MenuMeal {MealId = 1, MenuId = 1},
                new MenuMeal {MealId = 2},
                new MenuMeal {MealId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<MenuMeal>>();
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.MenuMeals).Returns(mockSet.Object);
            var business = new MenuMealBusiness(mockContext.Object);
            var MenuMeals = business.GetAll();
            int deleteId = 1; business.Delete(MenuMeals[0].MealId, MenuMeals[0].MenuId);
            Assert.IsNull(business.GetAll().FirstOrDefault(x => x.MealId == deleteId));
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
            var data = new List<MenuMeal>
            {
                new MenuMeal {MealId = 1},
                new MenuMeal {MealId = 2},
                new MenuMeal {MealId = 3},
            }.AsQueryable();
            var mockSet = new Mock<DbSet<MenuMeal>>();
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuMeal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<RestaurantsContext>();
            mockContext.Setup(x => x.MenuMeals).Returns(mockSet.Object);
            var business = new MenuMealBusiness(mockContext.Object);
            business.Delete(4,4);
            try
            {
                mockSet.Verify(m => m.Remove(It.IsAny<MenuMeal>()), Times.Once());
                Assert.Fail("Exeption not found");
            }
            catch (MockException)
            {
                Assert.Pass();
            }
        }
    }
}

