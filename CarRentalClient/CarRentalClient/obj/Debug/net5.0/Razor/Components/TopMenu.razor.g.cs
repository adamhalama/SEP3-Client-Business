#pragma checksum "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\Components\TopMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ea68126f3d7e4713f0b0ca866c03c8443167ccf"
// <auto-generated/>
#pragma warning disable 1591
namespace CarRentalClient.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using CarRentalClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
    public partial class TopMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Blazorise.Bar>(0);
            __builder.AddAttribute(1, "Breakpoint", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Breakpoint>(
#nullable restore
#line 1 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\Components\TopMenu.razor"
                 Breakpoint.Desktop

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "Background", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Background>(
#nullable restore
#line 2 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\Components\TopMenu.razor"
                 Background.Light

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "ThemeContrast", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.ThemeContrast>(
#nullable restore
#line 3 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\Components\TopMenu.razor"
                    ThemeContrast.Light

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazorise.BarBrand>(5);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<Blazorise.BarToggler>(7);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(8, "\r\n    ");
                __builder2.OpenComponent<Blazorise.BarMenu>(9);
                __builder2.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Blazorise.BarEnd>(11);
                    __builder3.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Blazorise.BarItem>(13);
                        __builder4.AddAttribute(14, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<Blazorise.BarLink>(15);
                            __builder5.AddAttribute(16, "To", "/");
                            __builder5.AddAttribute(17, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(18, "Home");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(19, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.BarItem>(20);
                        __builder4.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<Blazorise.BarLink>(22);
                            __builder5.AddAttribute(23, "To", "/AvailCars");
                            __builder5.AddAttribute(24, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(25, "Rent now !");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(26, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.BarItem>(27);
                        __builder4.AddAttribute(28, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<Blazorise.BarDropdown>(29);
                            __builder5.AddAttribute(30, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.OpenComponent<Blazorise.BarDropdownToggle>(31);
                                __builder6.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder7) => {
                                    __builder7.AddContent(33, "Support");
                                }
                                ));
                                __builder6.CloseComponent();
                                __builder6.AddMarkupContent(34, "\r\n                    ");
                                __builder6.OpenComponent<Blazorise.BarDropdownMenu>(35);
                                __builder6.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder7) => {
                                    __builder7.OpenComponent<Blazorise.BarDropdownItem>(37);
                                    __builder7.AddAttribute(38, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder8) => {
                                        __builder8.AddContent(39, "Contact us");
                                    }
                                    ));
                                    __builder7.CloseComponent();
                                    __builder7.AddMarkupContent(40, "\r\n                        ");
                                    __builder7.OpenComponent<Blazorise.BarDropdownDivider>(41);
                                    __builder7.CloseComponent();
                                    __builder7.AddMarkupContent(42, "\r\n                        ");
                                    __builder7.OpenComponent<Blazorise.BarDropdownItem>(43);
                                    __builder7.AddAttribute(44, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder8) => {
                                        __builder8.AddContent(45, "About us");
                                    }
                                    ));
                                    __builder7.CloseComponent();
                                }
                                ));
                                __builder6.CloseComponent();
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(46, "\r\n            ");
                        __builder4.OpenComponent<Blazorise.BarItem>(47);
                        __builder4.AddAttribute(48, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<Blazorise.Button>(49);
                            __builder5.AddAttribute(50, "Color", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 27 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\Components\TopMenu.razor"
                               Color.Primary

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(52, "Sign up");
                            }
                            ));
                            __builder5.CloseComponent();
                            __builder5.AddMarkupContent(53, "\r\n                ");
                            __builder5.OpenComponent<Blazorise.Button>(54);
                            __builder5.AddAttribute(55, "Color", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 28 "C:\Users\fhuur\OneDrive\DNPSolutions\CarRentalClient\CarRentalClient\Components\TopMenu.razor"
                               Color.Secondary

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(56, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddContent(57, "Log in");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
