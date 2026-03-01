using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class ExpenseManager
    {
        private List<Expense> expenses;

        public ExpenseManager()
        {
            expenses = new List<Expense>();
        }

        public void AddExpense(Expense expense) 
        {
            if (expense != null) { expenses.Add(expense); }
        }

        public string GetTotalBalance()
        {
            decimal totalBalance = 0;
            foreach (var expense in expenses) 
            {
                totalBalance += expense._amount;
            }
            return totalBalance.ToString();
        }

        public void ClearAll()
        {
            expenses.Clear();
        }
    }
}
