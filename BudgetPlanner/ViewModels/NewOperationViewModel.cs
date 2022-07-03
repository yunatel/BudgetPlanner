using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetPlanner.Models;
using Windows.UI.Xaml.Controls;

namespace BudgetPlanner.ViewModels
{
    public class NewOperationViewModel : ViewModelBase
    {
        private string opSum = string.Empty;
        private ComboBoxItem opType = null;
        private ComboBoxItem opCategory = null;
        private string opComment = string.Empty;
        private bool addButtonEnabled = false;

        public string OpSum {
            get { return opSum; }
            set { if (opSum != value) { opSum = value; OnPropertyChanged(nameof(OpSum)); } }
        }
        public ComboBoxItem OpType
        {
            get { return opType; }
            set { if (opType != value) { opType = value; OnPropertyChanged(nameof(OpType)); } }
        }
        public ComboBoxItem OpCategory
        {
            get { return opCategory; }
            set { if (opCategory != value) { opCategory = value; OnPropertyChanged(nameof(OpCategory)); } }
        }
        public string OpComment
        {
            get { return opComment; }
            set { if (opComment != value) { opComment = value; OnPropertyChanged(nameof(OpComment)); } }
        }
        public bool AddButtonEnabled
        {
            get { return addButtonEnabled; }
            set { if (addButtonEnabled != value) { addButtonEnabled = value; OnPropertyChanged(nameof(AddButtonEnabled)); } }
        }

        public ICommand AddButtonClicked
        {
            get { return new DelegateCommand(AddRecord); }
        }

        public void AddRecord()
        {
            Services.DBService.addRecord(float.Parse(opSum), opType.Content.ToString(), opCategory.Content.ToString(), opComment);
            Clear();
        }
        public ICommand ClearButtonClicked
        {
            get { return new DelegateCommand(Clear); }
        }

        public void Clear()
        {
            OpSum = String.Empty;
            OpType = null;
            OpCategory = null;
            OpComment = String.Empty;
        }
    } 

}