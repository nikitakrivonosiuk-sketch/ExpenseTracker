using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class Expense
    {
        public int Id { get; set; }
        public decimal Amount {  get;  set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }

        public Expense(decimal value, Category category, DateTime date)
        {
            Amount = value;
            Category = category;
            Date = date;
        }
    }
    enum Category
    {
        Food,
        Transport,
        Entertainment,
        Utilities
    }
}
