using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExpenseTracker
{
    internal class ExpenseRepository : IRepository<Expense>
    {
        public ObservableCollection<Expense> Expenses { get; } = new ObservableCollection<Expense>();
        private int _nextId = 1;

        public IEnumerable<Expense> GetAll() => Expenses;

        public void Add(Expense entity)
        {
            if (entity == null) return;
            if (entity.Id == 0) entity.Id = _nextId++;
            Expenses.Add(entity);
        }

        public IEnumerable<Expense> Find(Func<Expense, bool> predicate) => Expenses.Where(predicate);

        public void Delete(Expense entity) => Expenses.Remove(entity);

        public void Clear()
        {
            Expenses.Clear();
            _nextId = 1;
        }
    }
}