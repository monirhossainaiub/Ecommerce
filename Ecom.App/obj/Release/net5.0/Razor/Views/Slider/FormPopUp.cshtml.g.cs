#pragma checksum "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Slider\FormPopUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcb4f733290fbeb4b9f325a680a6139132f8b339"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Slider_FormPopUp), @"mvc.1.0.view", @"/Views/Slider/FormPopUp.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcb4f733290fbeb4b9f325a680a6139132f8b339", @"/Views/Slider/FormPopUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"404d8e866f71427d3308fb77e70630b138676721", @"/Views/_ViewImports.cshtml")]
    public class Views_Slider_FormPopUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade"" id=""FormPopUp"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">{{formTitle}}</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""form-elements form-horizontal"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bcb4f733290fbeb4b9f325a680a6139132f8b3394526", async() => {
                WriteLiteral(@"
                        <input type=""hidden"" ng-model=""model.id"">
                        <h3>Photos</h3>
                        <div class=""row"">
                            <div ng-show=""model.id"" class=""col-sm-6"">
                                <img src=""{{imageRootDirectory + model.photo}}"" class=""Thumbnail"" height=""50"" width=""50"">
                            </div>
                            <div class=""col-sm-6"">
                                <input type=""file"" select-ng-files ng-model=""fileList"" multiple ng-change=""uploadPhoto()"">
                            </div>
                        </div>

                        <hr />

                        <div class=""row"">
                            <div class=""col-sm-6"">
                                <div class=""form-group"">
                                    <label for=""edition"">Display Order</label>
                                    <input type=""number""
                                           class=""form-control""
     ");
                WriteLiteral(@"                                      id=""displayOrder""
                                           name=""displayOrder""
                                           ng-model=""model.displayOrder""
                                           autocomplete=""off"">
                                </div>
                            </div>
                            <div class=""col-sm-6"">
                                <div class=""form-group"">
                                    <label for=""controllerName"">Controller Name</label>
                                    <input type=""text""
                                           class=""form-control""
                                           id=""controllerName""
                                           name=""controllerName""
                                           ng-model=""model.controllerName""
                                           autocomplete=""off"">
                                </div>
                            </div>
                       ");
                WriteLiteral(@" </div>

                        <div class=""row"">
                            <div class=""col-sm-6"">
                                <div class=""form-group"">
                                    <label for=""actionName"">Action Name</label>
                                    <input type=""text""
                                           class=""form-control""
                                           id=""actionName""
                                           name=""actionName""
                                           ng-model=""model.actionName""
                                           autocomplete=""off"">
                                </div>
                            </div>
                            <div class=""col-sm-6"">
                                <div class=""form-check"">
                                    <input type=""checkbox""
                                           class=""form-check-input""
                                           id=""isActive""
                           ");
                WriteLiteral(@"                name=""isActive""
                                           ng-model=""model.isActive"">
                                    <label class=""form-check-label"" for=""isActive"">Active</label>
                                </div>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>

            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">
                    <i class=""fa fa-times-circle fa-lg""></i> Close
                </button>
                
                <button ng-click=""formSubmit()"" ng-disabled=""form.$invalid || isExist"" type=""button"" class=""btn btn-primary"">
                    <i class=""fa fa-save fa-lg"" fa-save""></i>
                    Save Changes
                </button>
            </div>
        </div>
    </div>
</div>");
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
