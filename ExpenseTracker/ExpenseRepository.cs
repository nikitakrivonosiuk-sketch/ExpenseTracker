using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ExpenseTracker
{
    public class ExpenseRepository : IRepository<Expense>
    {
        public ObservableCollection<Expense> Expenses { get; } = new ObservableCollection<Expense>();
        private int _nextId = 1;

        private string _filePath = "C:\\Users\\nikit\\source\\repos\\ExpenseTracker\\ExpenseTracker\\expenses";

        public ExpenseRepository()
        {
            LoadData();
        }

        public IEnumerable<Expense> GetAll() => Expenses;

        public void Add(Expense entity)
        {
            if (entity == null) return;
            if (entity.Id == 0) entity.Id = _nextId++;
            Expenses.Add(entity);

            SaveData();
        }

        public IEnumerable<Expense> Find(Func<Expense, bool> predicate) => Expenses.Where(predicate);

        public void Delete(Expense entity)
        {
            Expenses.Remove(entity);
            SaveData();
        }

        public void Clear()
        {
            Expenses.Clear();
            _nextId = 1;
            SaveData();
        }

        public void LoadData()
        {
            if (!File.Exists(_filePath)) return;
         
            string jsonString = File.ReadAllText(_filePath);

            var loadedExpenses = JsonSerializer.Deserialize<List<Expense>>(jsonString);

            if (loadedExpenses != null)
            {
                Expenses.Clear();

                foreach (var expense in loadedExpenses)
                {
                    Expenses.Add(expense);
                }

                if (Expenses.Any())
                {
                    _nextId = Expenses.Max(e =>  e.Id) + 1;
                }
            }
        }

        public void SaveData()
        {
            var options = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Expenses, options);

            File.WriteAllText(_filePath, jsonString);
        }
    }
}