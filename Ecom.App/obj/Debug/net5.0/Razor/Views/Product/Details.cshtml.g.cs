#pragma checksum "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86e19dc899faeef6e8e94545f410d668131be8b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
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
#line 1 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\_ViewImports.cshtml"
using Ecom.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\_ViewImports.cshtml"
using Ecom.App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86e19dc899faeef6e8e94545f410d668131be8b6", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"404d8e866f71427d3308fb77e70630b138676721", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ecom.App.Controllers.Resources.DTOs.ProductDetailDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app/Controllers/productController.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/Public/_PublicLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div ng-controller=\"productController\">\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 325, "\"", 389, 2);
            WriteAttributeValue("", 331, "{{imageRootDirectory}}", 331, 22, true);
#nullable restore
#line 15 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue("", 353, Model.Photos[0].FileName.ToString(), 353, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"250\" width=\"180\" />\r\n            </div>\r\n            <div class=\"col-sm-6\">\r\n                <h2>");
#nullable restore
#line 18 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
               Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                <div>\r\n                    by\r\n                    <a>");
#nullable restore
#line 21 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                  Write(Model.Writer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n                <div>\r\n                    Category:\r\n                    <a>");
#nullable restore
#line 25 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                  Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("ng-show", " ng-show=\"", 770, "\"", 814, 5);
            WriteAttributeValue("", 780, "{{", 780, 2, true);
#nullable restore
#line 27 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue("", 782, Model.OldPrice, 782, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 797, ">", 798, 2, true);
#nullable restore
#line 27 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue(" ", 799, Model.Price, 800, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 812, "}}", 812, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    TK. ");
#nullable restore
#line 28 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                   Write(Model.OldPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    TK. ");
#nullable restore
#line 31 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                   Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span");
            BeginWriteAttribute("ng-show", " ng-show=\"", 948, "\"", 992, 5);
            WriteAttributeValue("", 958, "{{", 958, 2, true);
#nullable restore
#line 31 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue("", 960, Model.OldPrice, 960, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 975, ">", 976, 2, true);
#nullable restore
#line 31 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue(" ", 977, Model.Price, 978, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 990, "}}", 990, 2, true);
            EndWriteAttribute();
            WriteLiteral(">You save (TK. {{");
#nullable restore
#line 31 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                                                                                                   Write(Model.OldPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 31 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                                                                                                                     Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("}})</span>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("ng-show", " ng-show=\"", 1096, "\"", 1130, 3);
            WriteAttributeValue("", 1106, "{{", 1106, 2, true);
#nullable restore
#line 33 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue("", 1108, Model.StockQuantity, 1108, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1128, "}}", 1128, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    In Stock (only ");
#nullable restore
#line 34 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
                              Write(Model.StockQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" copy is left)\r\n                </div>\r\n                <div");
            BeginWriteAttribute("ng-hide", " ng-hide=\"", 1249, "\"", 1283, 3);
            WriteAttributeValue("", 1259, "{{", 1259, 2, true);
#nullable restore
#line 36 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\Details.cshtml"
WriteAttributeValue("", 1261, Model.StockQuantity, 1261, 20, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1281, "}}", 1281, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    Stock out\r\n                </div>\r\n            </div>\r\n            <div class=\"col-sm-3\"></div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div >\r\n                <h2");
            BeginWriteAttribute("class", " class=\"", 1486, "\"", 1494, 0);
            EndWriteAttribute();
            WriteLiteral(@">Product Specification & Summary</h2>
            </div>
            <div >
                <nav>
                    <div class=""nav nav-tabs"" id=""nav-tab"" role=""tablist"">
                        <a class=""nav-link active"" id=""nav-home-tab"" data-bs-toggle=""tab"" href=""#nav-home"" role=""tab"" aria-controls=""nav-home"" aria-selected=""true"">Home</a>
                        <a class=""nav-link"" id=""nav-profile-tab"" data-bs-toggle=""tab"" href=""#nav-profile"" role=""tab"" aria-controls=""nav-profile"" aria-selected=""false"">Profile</a>
                        <a class=""nav-link"" id=""nav-contact-tab"" data-bs-toggle=""tab"" href=""#nav-contact"" role=""tab"" aria-controls=""nav-contact"" aria-selected=""false"">Contact</a>
                    </div>
                </nav>
                <div class=""tab-content"" id=""nav-tabContent"">
                    <div class=""tab-pane fade show active"" id=""nav-home"" role=""tabpanel"" aria-labelledby=""nav-home-tab"">..y.</div>
                    <div class=""tab-pane fade"" id=""nav-profile"" r");
            WriteLiteral(@"ole=""tabpanel"" aria-labelledby=""nav-profile-tab"">..g.</div>
                    <div class=""tab-pane fade"" id=""nav-contact"" role=""tabpanel"" aria-labelledby=""nav-contact-tab"">.b..</div>
                </div>
            </div>
        </div>
    </div>
</div>




");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86e19dc899faeef6e8e94545f410d668131be8b611581", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ecom.App.Controllers.Resources.DTOs.ProductDetailDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
