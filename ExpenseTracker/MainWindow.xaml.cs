using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ExpenseTracker
{
    public partial class MainWindow : Window
    {
        private readonly ExpenseRepository _repository;
        private Expense _editedExpense = null;
        public MainWindow()
        {
            InitializeComponent();
            _repository = new ExpenseRepository();

            categoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            categoryComboBox.SelectedIndex = 0;

            ExpensesList.ItemsSource = _repository.Expenses; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountInput.Text, out decimal result))
            {
                Category selectedCategory = (Category)categoryComboBox.SelectedItem;

                if (_editedExpense == null)
                {
                    Expense newExpense = new Expense(result, selectedCategory, DateTime.Now);
                    _repository.Add(newExpense);
                }
                else
                {
                    _editedExpense.Amount = result;
                    _editedExpense.Category = selectedCategory;

                    ExpensesList.Items.Refresh();

                    _editedExpense = null;
                    AddButton.Content = "Додати витрату";
                }
                UpdateExpense();
                AmountInput.Clear();
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddButton.IsEnabled = !string.IsNullOrWhiteSpace(AmountInput.Text);
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            _repository.Clear();
            UpdateExpense();
            categoryComboBox.SelectedIndex = 0;
            AmountInput.Clear();
        }
        private void UpdateExpense()
        {
            decimal result = _repository.Expenses.Sum(x => x.Amount);
            TotalSpentText.Text = $"{result} $";
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ExpensesList.SelectedItem is Expense selectedExpense)
            {
                _editedExpense = selectedExpense;

                AddButton.Content = "Зберегти зміни";
                AmountInput.Text = _editedExpense.Amount.ToString();
                categoryComboBox.SelectedItem = _editedExpense.Category;
            }
            else
            {
                MessageBox.Show("Спочатку треба вибрати рядок зі списку.");
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Expense selectedExpense = ExpensesList.SelectedItem as Expense;

            if (selectedExpense != null)
            {
                _repository.Delete(selectedExpense);
                UpdateExpense();
            }
            else
                MessageBox.Show("Не вибрано жодного об'єкту з списку.");
        }
    }
}
