using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseTracker;
using System;

namespace ExpenseTracker.Tests
{
    [TestClass]
    public class ExpenseTests
    {
        [TestMethod]
        public void ExpenseConstructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange (Підготовка даних)
            decimal expectedAmount = 150.5m;
            Category expectedCategory = Category.Food;
            DateTime expectedDate = DateTime.Now;

            // Act (Виконання дії)
            var expense = new Expense(expectedAmount, expectedCategory, expectedDate);

            // Assert (Перевірка результату)
            Assert.AreEqual(expectedAmount, expense.Amount);
            Assert.AreEqual(expectedCategory, expense.Category);
        }
    }
}