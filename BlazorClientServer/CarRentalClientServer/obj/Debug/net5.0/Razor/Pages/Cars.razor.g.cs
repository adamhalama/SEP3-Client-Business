#pragma checksum "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f7d22a8e60706f060a4dea6d07b650cd8e155848"
// <auto-generated/>
#pragma warning disable 1591
namespace CarRentalClientServer.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using CarRentalClientServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\_Imports.razor"
using CarRentalClientServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
using CarRentalClientServer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
using CarRentalClientServer.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Cars")]
    public partial class Cars : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Car list</h3>\r\n\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.OpenElement(2, "button");
            __builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
                         () => OpenAddCar()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(4, "\r\n            Send default\r\n        ");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 17 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
 if (CarsToShow == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(5, "<p><em>Loading...</em></p>");
#nullable restore
#line 22 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
}
else if (!CarsToShow.Any())
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "<p><em>No adults are in this list. Please add some.</em></p>");
#nullable restore
#line 28 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "table");
            __builder.AddAttribute(8, "class", "table");
            __builder.AddMarkupContent(9, "<thead><tr><td>ID</td>\r\n            <td>Name</td>\r\n            <td>Model</td></tr></thead>\r\n        ");
            __builder.OpenElement(10, "tbody");
#nullable restore
#line 40 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
         foreach (var item in CarsToShow)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "tr");
            __builder.OpenElement(12, "td");
#nullable restore
#line 43 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
__builder.AddContent(13, item.Id);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n                ");
            __builder.OpenElement(15, "td");
#nullable restore
#line 44 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
__builder.AddContent(16, item.Name);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                ");
            __builder.OpenElement(18, "td");
#nullable restore
#line 45 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
__builder.AddContent(19, item.Model);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 47 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 50 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Pages\Cars.razor"
       

    private IList<Car> cars;
    private IList<Car> CarsToShow;

    protected override async Task OnInitializedAsync()
    {
        var getCarsTask = carService.GetCarsAsync();
        cars = await getCarsTask;
        CarsToShow = cars;
    }

    private void OpenAddCar()
    {
        NavigationManager.NavigateTo("/AddCar");
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ICarService carService { get; set; }
    }
}
#pragma warning restore 1591
