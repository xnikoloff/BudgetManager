using BudgetManage.Services;
using BudgetManager.Domain;
using BudgetManager.Infastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BudgetManager.Tests
{
    public class ExpenseTests
    {

        [Fact]
        public async Task AddExpense_WithCorrectData_ShouldGetAllExpenses()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BudgetManagerDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new BudgetManagerDbContext(options);
            var service = new ExpenseService(context);

            //Act
            SeedDb(context);
            var actualData = await service.GetAll();
            var expectedData = GetTestData();

            //Assert
            Assert.Equal(expectedData.Count, actualData.Count);
        }

        [Fact]
        public async void AddExpense_WithCorrectData_ShouldAddExpense()
        {

            //Arrange
            var options = new DbContextOptionsBuilder<BudgetManagerDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new BudgetManagerDbContext(options);
            var service = new ExpenseService(context);

            //Act
            SeedDb(context);

            Expense expense = new Expense()
            {
                Amount = 800,
                Date = DateTime.Now,
                Description = "Test expense",
                ExpenseType = Domain.Enumerations.ExpenseType.Bill,
                Reason = Domain.Enumerations.Reason.Extra,
            };

            var result = await service.Add(expense);

            //Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task Delete_WithCorrectData_ShouldDeleteExpense()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BudgetManagerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new BudgetManagerDbContext(options);
            SeedDb(context);
            var service = new ExpenseService(context);

            //Act
            var result = await service.Delete(1);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task Update_WithCorrectData_ShouldUpdateExpense()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BudgetManagerDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new BudgetManagerDbContext(options);
            SeedDb(context);
            var service = new ExpenseService(context);

            //Act
            var entity = await context.Expenses.FirstOrDefaultAsync();
            var result = await service.Update(entity);
            
            //Assert
            Assert.Equal(1, result);
        }

        private void SeedDb(BudgetManagerDbContext _context)
        {
            _context.AddRange(GetTestData());
            _context.SaveChanges();
        }

        private List<Expense> GetTestData()
        {
            return new List<Expense>
            {
                new Expense
                {
                    Id = 1,
                    Amount = 800,
                    Description = "Test desc 1"
                },

                new Expense
                {
                    Id = 2,
                    Amount = 200,
                    Description = "Test desc 2"
                },
            };
        }
    }

    
}
