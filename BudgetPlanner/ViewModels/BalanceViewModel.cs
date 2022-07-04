using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPlanner.Services;

namespace BudgetPlanner.ViewModels
{
    public class BalanceViewModel : ViewModelBase
    {
        private string balanceText = "Баланс: " + GetBalance().ToString();

        public string BalanceText
        {
            get { return balanceText; }
            set { if (balanceText != value) { balanceText = value; OnPropertyChanged(nameof(BalanceText)); } }
        }
        public static float GetBalance()
        {
            float balance = 0f;
            foreach (Models.SampleOperation record in DBService.GetRecords())
            {
                if (record.opType == "Доход") balance += record.opSum;
                else if (record.opType == "Расход") balance-= record.opSum;
            }
            return balance;
        }
    }
}
