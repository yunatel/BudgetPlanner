using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Models
{
    public class SampleOperation 
    {
        public string opDate { get; set; }
        public float opSum { get; set; }
        public string opType { get; set; }
        public string opCategory { get; set; }
        public string opComment { get; set; }

        public SampleOperation(string opDate, float opSum, string opType, string opCategory, string opComment)
        {
            this.opDate = opDate;
            this.opSum = opSum;
            this.opType = opType;
            this.opCategory = opCategory;
            this.opComment = opComment;
        }

    }
}
