#pragma checksum "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e72b570cb5f0b25edec57f1b10dfc0eb184ff34d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Details), @"mvc.1.0.view", @"/Views/Orders/Details.cshtml")]
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
#line 1 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\_ViewImports.cshtml"
using EzzRestaurant;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\_ViewImports.cshtml"
using EzzRestaurant.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e72b570cb5f0b25edec57f1b10dfc0eb184ff34d", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c6aa953201e15c20aee30c746aafda07a79ad64", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: white;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
  

    string bgImage = "/pexels-lumn.jpg";
    var order = (OrderModel) ViewBag.Order;
    var products = (List<ProductModel>) ViewBag.Products;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div");
            BeginWriteAttribute("class", " class=\"", 161, "\"", 169, 0);
            EndWriteAttribute();
            BeginWriteAttribute("style", " style=\"", 170, "\"", 266, 11);
            WriteAttributeValue("", 178, "background:", 178, 11, true);
            WriteAttributeValue(" ", 189, "url(", 190, 5, true);
#nullable restore
#line 8 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
WriteAttributeValue("", 194, bgImage, 194, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 202, ")", 202, 1, true);
            WriteAttributeValue(" ", 203, "no-repeat", 204, 10, true);
            WriteAttributeValue(" ", 213, "center", 214, 7, true);
            WriteAttributeValue(" ", 220, "center;", 221, 8, true);
            WriteAttributeValue(" ", 228, "background-size:", 229, 17, true);
            WriteAttributeValue(" ", 245, "cover;", 246, 7, true);
            WriteAttributeValue(" ", 252, "height:", 253, 8, true);
            WriteAttributeValue(" ", 260, "800px", 261, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"text-center\" style=\"height: 800px; background-color: rgba(0,0,0,0.5); \">\r\n        ");
#nullable restore
#line 10 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
   Write(await Html.PartialAsync("_PartialNavbar"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <div style="" height:100%; display:flex; flex-direction:column;justify-content: center"">
            <h1 class=""display-4"" style=""color: white; font-size: 120px; font-weight: bold; font-family: Pattaya,serif;"">Orders</h1>
            
        </div>
    </div>
</div>

<div class=""Homebody container text-center"">
    
    <h1 style=""font-family: Pattaya,serif;"">Order #");
#nullable restore
#line 20 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
                                              Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <h3 style=\"font-family: Pattaya,serif;\">Total price : ");
#nullable restore
#line 21 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
                                                     Write(order.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</h3>\r\n    <div class=\"row order-body\">\r\n");
#nullable restore
#line 23 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
         foreach (var product in products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4 \">\r\n           \r\n                <div class=\"category-card box-shadow\"");
            BeginWriteAttribute("style", " style=\"", 1086, "\"", 1130, 4);
            WriteAttributeValue("", 1094, "background-image:", 1094, 17, true);
            WriteAttributeValue(" ", 1111, "url(", 1112, 5, true);
#nullable restore
#line 27 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
WriteAttributeValue("", 1116, product.img, 1116, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1128, ");", 1128, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"category-body\" style=\"display: flex ; flex-direction: column\">\r\n                    \r\n                        <h4 style=\"color: white; font-weight: bold\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e72b570cb5f0b25edec57f1b10dfc0eb184ff34d8600", async() => {
#nullable restore
#line 30 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
                                                                                                                                                                  Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
                                                                                                                                              WriteLiteral(product.Id);

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
            WriteLiteral("</h4>\r\n                        <h5 style=\"color: white; font-weight: bold\">");
#nullable restore
#line 31 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
                                                               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("$</h5>\r\n                    \r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 36 "D:\Developing\Tuwaiq\dotNet\Projects\Final Project\Project04_Auth_CRUD_ASP.NET\EzzRestaurant\EzzRestaurant\Views\Orders\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
