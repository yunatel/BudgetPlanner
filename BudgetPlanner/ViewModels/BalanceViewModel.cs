using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPlanner.Services;

namespace BudgetPlanner.ViewModels
{
    public class BalanceViewModel
    {
        public static float getBalance()
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
