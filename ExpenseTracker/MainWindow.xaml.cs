using System;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseTracker
{
    public partial class MainWindow : Window
    {
        private ExpenseManager _wallet;
        public MainWindow()
        {
            InitializeComponent();

            _wallet = new ExpenseManager();

            categoryComboBox.ItemsSource = Enum.GetValues(typeof(Category));
            categoryComboBox.SelectedIndex = 0; // для дефолтного значення
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(AmountInput.Text, out decimal result))
            {
                Category selectedCategory = (Category)categoryComboBox.SelectedItem;

                Expense newExpense = new Expense(result, selectedCategory, DateTime.Now);

                _wallet.AddExpense(newExpense);

                TotalSpentText.Text = $"{_wallet.GetTotalBalance()} $";
                AmountInput.Clear();
            }
            else return;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddButton.IsEnabled = !string.IsNullOrWhiteSpace(AmountInput.Text);
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            _wallet.ClearAll();
            TotalSpentText.Text = "0 $";
            AmountInput.Clear();
        }
    }
}
