#pragma checksum "D:\Tuwaiq\dotNET\projects\Project04_Auth_CRUD_ASP.NET\ChallengeME\ChallengeME\Views\Challenges\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1aa569398ea5a6238e2925890137fff08557b0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Challenges_Details), @"mvc.1.0.view", @"/Views/Challenges/Details.cshtml")]
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
#line 1 "D:\Tuwaiq\dotNET\projects\Project04_Auth_CRUD_ASP.NET\ChallengeME\ChallengeME\Views\_ViewImports.cshtml"
using ChallengeME;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Tuwaiq\dotNET\projects\Project04_Auth_CRUD_ASP.NET\ChallengeME\ChallengeME\Views\_ViewImports.cshtml"
using ChallengeME.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1aa569398ea5a6238e2925890137fff08557b0d", @"/Views/Challenges/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54763cba37704fcebb8d1aa574ef96d8a49f552a", @"/Views/_ViewImports.cshtml")]
    public class Views_Challenges_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Challenge>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CommentsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tuwaiq\dotNET\projects\Project04_Auth_CRUD_ASP.NET\ChallengeME\ChallengeME\Views\Challenges\Details.cshtml"
  

    var challenge = (Challenge)ViewData["challenge"];
    //var comments = (List<Comment>)ViewData["comments"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>INFO ABOUT THE CHALLENGE</h1>\r\n\r\n\r\n<h2>");
#nullable restore
#line 13 "D:\Tuwaiq\dotNET\projects\Project04_Auth_CRUD_ASP.NET\ChallengeME\ChallengeME\Views\Challenges\Details.cshtml"
Write(challenge.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h4>");
#nullable restore
#line 14 "D:\Tuwaiq\dotNET\projects\Project04_Auth_CRUD_ASP.NET\ChallengeME\ChallengeME\Views\Challenges\Details.cshtml"
Write(challenge.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c1aa569398ea5a6238e2925890137fff08557b0d4416", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Challenge> Html { get; private set; }
    }
}
#pragma warning restore 1591
