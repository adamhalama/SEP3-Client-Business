#pragma checksum "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79c5af03ede195c048b151923d0112f601ffffcf"
// <auto-generated/>
#pragma warning disable 1591
namespace CarRentalClientServer.Shared
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
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-ejb1mwg5f4");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "sidebar");
            __builder.AddAttribute(5, "b-ejb1mwg5f4");
            __builder.OpenComponent<CarRentalClientServer.Shared.NavMenu>(6);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n\r\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "main");
            __builder.AddAttribute(10, "b-ejb1mwg5f4");
            __builder.AddMarkupContent(11, "<div class=\"top-row px-4\" b-ejb1mwg5f4><a href=\"https://docs.microsoft.com/aspnet/\" target=\"_blank\" b-ejb1mwg5f4>About</a></div>\r\n\r\n        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "content px-4");
            __builder.AddAttribute(14, "b-ejb1mwg5f4");
#nullable restore
#line 14 "C:\Users\fhuur\OneDrive\JavaClasses\SEP3v2\BlazorClientServer\CarRentalClientServer\Shared\MainLayout.razor"
__builder.AddContent(15, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
