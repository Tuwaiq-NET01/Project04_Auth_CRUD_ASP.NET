#pragma checksum "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b82f024a849b3112f6ae40b7b40b18bbdeb09d8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Organizations_Details), @"mvc.1.0.view", @"/Views/Organizations/Details.cshtml")]
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
#line 1 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\_ViewImports.cshtml"
using HjtProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\_ViewImports.cshtml"
using HjtProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b82f024a849b3112f6ae40b7b40b18bbdeb09d8a", @"/Views/Organizations/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"87b48c50175f9e0ee6dd35ec44739706d60a3151", @"/Views/_ViewImports.cshtml")]
    public class Views_Organizations_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
  
    var org = (OrganizationModel)ViewData["organization"];
    var insts = org.Instructors.ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 style=\"color: #30475e\"> Organization : ");
#nullable restore
#line 4 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
                                          Write(org.name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b82f024a849b3112f6ae40b7b40b18bbdeb09d8a3699", async() => {
                WriteLiteral("\r\n\r\n        <div class=\" d-flex flex-wrap\">\r\n\r\n            <div class=\"card .text-black \" style=\"width: 30rem; margin-inline:auto\">\r\n                <img");
                BeginWriteAttribute("src", " src=\"", 334, "\"", 348, 1);
#nullable restore
#line 10 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
WriteAttributeValue("", 340, org.pic, 340, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"card-img-top\" alt=\"Tea Coal\" width=\"300\" height=\"300 \">\r\n                <div class=\"card-body\" style=\"color: #30475e ;background-color:#e7e7de \">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 12 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
                                      Write(org.name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                    <p class=\"text\"> <b>INFO : ");
#nullable restore
#line 13 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
                                          Write(org.summary);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </b></p>\r\n                    <p>\r\n                        The instructors which are under this Organization are :\r\n");
#nullable restore
#line 16 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
                         foreach (var inst in insts)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <br />\r\n");
#nullable restore
#line 19 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"
                       Write(inst.name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <br/>\r\n");
#nullable restore
#line 20 "C:\Users\aashq\source\repos\HjtProject\HjtProject\Views\Organizations\Details.cshtml"

                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </p>\r\n\r\n                    </div>\r\n            </div>\r\n\r\n        </div>\r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
