#pragma checksum "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c72acfc8e99082210ddf093692d3649047cbab18"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c72acfc8e99082210ddf093692d3649047cbab18", @"/Views/Hotels/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21f9526e0bad77879ec0857ff1aa901df08b87c7", @"/Views/_ViewImports.cshtml")]
    public class Views_Hotels_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Hotels", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
  
    var hotel = (HotelModel)ViewData["Hotel"];


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Hotel Details:</h3>>\r\n\r\n<div class=\"card mb-3\">\r\n    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 141, "\"", 164, 1);
#nullable restore
#line 9 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
WriteAttributeValue("", 147, hotel.HotelImage, 147, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\">");
#nullable restore
#line 11 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                          Write(hotel.HotelName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <p class=\"card-text\">Phone Number :");
#nullable restore
#line 12 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                      Write(hotel.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\">City :");
#nullable restore
#line 13 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                              Write(hotel.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\">State :");
#nullable restore
#line 14 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                               Write(hotel.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p class=\"card-text\">ZipCode :");
#nullable restore
#line 15 "C:\Users\arwaw\MVC\Project04_Auth_CRUD_ASP.NET\HotelReservationManagement\HotelReservationManagement\Views\Hotels\Details.cshtml"
                                 Write(hotel.ZipCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n      \r\n    </div>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c72acfc8e99082210ddf093692d3649047cbab186440", async() => {
                WriteLiteral(" Back to Hotels ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
