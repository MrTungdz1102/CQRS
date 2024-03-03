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
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using Blazored.Toast;
using Blazored.Toast.Services;
using CQRS.BlazorUI.Models.LeaveType;
using CQRS.BlazorUI.InterfaceContracts;

namespace CQRS.BlazorUI.Pages.LeaveType
{
    public partial class Edit
    {
        [Inject]
        ILeaveTypeService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM leaveType = new LeaveTypeVM();
        protected async override Task OnParametersSetAsync()
        {
            leaveType = await _client.GetLeaveTypeDetails(id);
        }

        async Task EditLeaveType()
        {
            var response = await _client.UpdateLeaveType(leaveType);
            if (response.Success)
            {
                _navManager.NavigateTo("/leavetype/");
            }

            Message = response.Message;
        }
    }
}