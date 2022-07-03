using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChangedEventHandler handler = this.PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}


        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
