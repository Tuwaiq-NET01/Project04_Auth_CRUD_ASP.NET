#pragma checksum "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c64343461f829ca7aef6e54e15dd5a64a6931c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Roasteries_Index), @"mvc.1.0.view", @"/Views/Roasteries/Index.cshtml")]
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
#line 1 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\_ViewImports.cshtml"
using Coffee;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\_ViewImports.cshtml"
using Coffee.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c64343461f829ca7aef6e54e15dd5a64a6931c1", @"/Views/Roasteries/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"339c788173a40e9bec207f55d81c92e5443ef456", @"/Views/_ViewImports.cshtml")]
    public class Views_Roasteries_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
  
    var Roasteries = (List<Roastery>)ViewData["Roasteries"];


#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 style=\"color:gray;margin-top:200px; margin-left:400px\">Coffee Roasteries</h1>\r\n\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
 foreach (var roaster in Roasteries)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"list-inline-item mr-3 ml-5 mb-5 mt-2\" style=\"margin-top:80px\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 349, "\"", 369, 1);
#nullable restore
#line 14 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
WriteAttributeValue("", 355, roaster.Image, 355, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" height=\"150\" width=\"30\" alt=\"...\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">\r\n                    ");
#nullable restore
#line 17 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
               Write(roaster.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h5>\r\n                <h5 class=\"card-title\">\r\n                    ");
#nullable restore
#line 20 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
               Write(roaster.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h5>\r\n                <h5 class=\"card-title\">\r\n\r\n                    ");
#nullable restore
#line 24 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
               Write(roaster.Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </h5>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 29 "C:\Users\Alban\source\repos\Coffee\Coffee\Views\Roasteries\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
