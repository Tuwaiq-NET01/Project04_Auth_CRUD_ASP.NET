#pragma checksum "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de1f3ed24bdb3daecfae9ce42953d2d609d4b187"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Index), @"mvc.1.0.view", @"/Views/Events/Index.cshtml")]
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
#line 1 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\_ViewImports.cshtml"
using Events_Hall;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\_ViewImports.cshtml"
using Events_Hall.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de1f3ed24bdb3daecfae9ce42953d2d609d4b187", @"/Views/Events/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0c5d3b71fab06eba131aaadf6110abdfe6a09c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Events_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
  
    var events = (List<EventModel>)ViewBag.Events;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card-columns\">\r\n");
#nullable restore
#line 6 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
     foreach (var e in events)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 193, "\"", 207, 1);
#nullable restore
#line 9 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
WriteAttributeValue("", 199, e.Image, 199, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Event Picture\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 11 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
                                  Write(e.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <hr />\r\n                <p class=\"card-text\">");
#nullable restore
#line 13 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
                                Write(e.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <hr />\r\n                <p class=\"card-text\"><b>Time:</b> ");
#nullable restore
#line 15 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
                                             Write(e.Time);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <hr />\r\n                <p class=\"card-text\"><b>Duration:</b> ");
#nullable restore
#line 17 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
                                                 Write(e.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <hr />\r\n                <p class=\"card-text\"><b>Presented by:</b> ");
#nullable restore
#line 19 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
                                                     Write(e.PresentorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 23 "C:\Users\Reema\source\repos\Project04_Auth_CRUD_ASP.NET\Events_Hall\Events_Hall\Views\Events\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
