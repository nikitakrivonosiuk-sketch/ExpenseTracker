using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class Expense
    {
        public decimal _amount {  get; private set; }
        public Category _category { get; private set; }
        public DateTime _date { get; private set; }

        public Expense(decimal value, Category category, DateTime date)
        {
            _amount = value;
            _category = category;
            _date = date;
        }
    }
}
