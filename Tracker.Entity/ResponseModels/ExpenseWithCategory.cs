using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Data.ResponseModels
{
    public class ExpenseWithCategory
    {
        public Guid ExpenseId { get; set; }
        public Guid CategoryId { get; set; }
        public string ExpenseTitle { get; set; }
        public decimal ExpenseAmount { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public string? ExpenseDiscription { get; set; }
        public string? ExpenseImage { get; set; }
        public string? ExpenseTransaction { get; set; }
        public DateTime ExpenseCreatedDate { get; set; }
        public DateTime ExpenseModifiedDate { get; set; }
        public bool? ExpenseHide { get; set; }
        public string? CategoryTitle { get; set; } 
        public string? Color { get; set;}
    }

}