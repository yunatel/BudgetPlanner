using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetPlanner.Services;

namespace BudgetPlanner.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private List<Models.SampleOperation> dataGridItemSource = Services.DBService.GetRecords();
        public List<Models.SampleOperation> DataGridItemSource { get => dataGridItemSource; set => dataGridItemSource = value; }   
    }
}
