using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount {  get;  set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }

        public Expense()
        {
            
        }
        public Expense(decimal value, Category category, DateTime date)
        {
            Amount = value;
            Category = category;
            Date = date;
        }
    }
    public enum Category
    {
        Food,
        Transport,
        Entertainment,
        Utilities
    }
}
