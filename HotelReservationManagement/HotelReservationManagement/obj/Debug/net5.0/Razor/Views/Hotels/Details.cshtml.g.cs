#pragma checksum "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1708c34dd7128974f55a6ae70f1dc79f4199b178"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Hotels_Details), @"mvc.1.0.view", @"/Views/Hotels/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\_ViewImports.cshtml"
using HotelReservationManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\_ViewImports.cshtml"
using HotelReservationManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1708c34dd7128974f55a6ae70f1dc79f4199b178", @"/Views/Hotels/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21f9526e0bad77879ec0857ff1aa901df08b87c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Hotels_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoomModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "_NotFound", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "rooms", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Hotels", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
  
    var hotel = (HotelModel)ViewData["Hotel"];

    var roomList = (List<RoomModel>)ViewData["Rooms"];


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Hotel Details:</h3>\r\n\r\n<div class=\"card mb-3\">\r\n    <h3 class=\"card-title text-center\">");
#nullable restore
#line 12 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                  Write(hotel.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 279, "\"", 302, 1);
#nullable restore
#line 13 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
WriteAttributeValue("", 285, hotel.HotelImage, 285, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n    <div class=\"card-body\">\r\n\r\n        <p class=\"card-text\"><strong>Phone Number :</strong>");
#nullable restore
#line 16 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                       Write(hotel.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\"><strong>City :</strong>");
#nullable restore
#line 17 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                               Write(hotel.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\"><strong>State :</strong>");
#nullable restore
#line 18 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                Write(hotel.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\"><strong>ZipCode :</strong>");
#nullable restore
#line 19 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                  Write(hotel.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n");
#nullable restore
#line 25 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
 foreach (var r in roomList)
{
    if (r.HotelId == hotel.HotelId)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card mb-3\">\r\n\r\n        <h3 class=\"card-title\">Room ");
#nullable restore
#line 31 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                               Write(r.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 865, "\"", 883, 1);
#nullable restore
#line 33 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
WriteAttributeValue("", 871, r.RoomImage, 871, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:200px; height:300px\" />\r\n\r\n        <p class=\"card-text\"><strong>Room Type :</strong>");
#nullable restore
#line 35 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                    Write(r.RoomType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\"><strong>Room Price :</strong>");
#nullable restore
#line 36 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                     Write(r.RoomPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\"><strong>Room Status :</strong>");
#nullable restore
#line 37 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                      Write(r.RoomStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\"><strong>Room Description:</strong>");
#nullable restore
#line 38 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                          Write(r.RoomDescribtion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 40 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"

    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("         ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1708c34dd7128974f55a6ae70f1dc79f4199b17811277", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
    }

 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n      \r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1708c34dd7128974f55a6ae70f1dc79f4199b17812670", async() => {
                WriteLiteral("Add New Room");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                                                                WriteLiteral(hotel.HotelId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1708c34dd7128974f55a6ae70f1dc79f4199b17815258", async() => {
                WriteLiteral(" Back to Hotels ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoomModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
