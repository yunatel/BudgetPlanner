using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetPlanner.ViewModels
{
    class DelegateCommand : ICommand
    {
        private SimpleEventHandler handler;
        private bool isEnabled = true;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();
        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }
        public bool IsEnabled { get { return isEnabled; } }

        void ICommand.Execute(object org)
        {
            handler();
        }

        bool ICommand.CanExecute(object org)
        {
            return isEnabled;
        }

        private void OnCanExecuteChanged()
        {
           if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
