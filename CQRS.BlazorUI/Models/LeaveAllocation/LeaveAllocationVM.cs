using CQRS.BlazorUI.Models.LeaveType;
using System.ComponentModel.DataAnnotations;

namespace CQRS.BlazorUI.Models.LeaveAllocation
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }
        [Display(Name = "Number Of Days")]

        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public LeaveTypeVM LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}
