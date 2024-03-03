using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using CQRS.BlazorUI;
using CQRS.BlazorUI.Shared;
using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Models.LeaveType;
using Blazored.Toast.Services;

namespace CQRS.BlazorUI.Pages.LeaveType
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; }
        [Inject]
        public ILeaveAllocationService LeaveAllocationService { get; set; }
        [Inject]
        IToastService toastService { get; set; }
        public List<LeaveTypeVM> LeaveTypes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/leavetype/create/");
        }

        protected void AllocateLeaveType(int id)
        {
            // Use Leave Allocation Service here
            LeaveAllocationService.CreateLeaveAllocations(id);
        }

        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetype/edit/{id}");
        }

        protected void DetailsLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetype/details/{id}");
        }

        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.Success)
            {
                toastService.ShowSuccess("Leave Type deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetLeaveTypes();
        }
    }
}