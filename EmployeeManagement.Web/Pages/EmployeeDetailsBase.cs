using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {

        public Employee Employee { get; set; } = new Employee();

        protected string Coordinates { get; set; }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }

        // Button Hide footer
        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "ShowFooter";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }

        //// Cordinat Alternavie solution
        //protected void Mouse_Move(MouseEventArgs e)
        //{
        //    Coordinates = $"X ={e.ClientX} Y = {e.ClientY}";
        //}
    }
}
