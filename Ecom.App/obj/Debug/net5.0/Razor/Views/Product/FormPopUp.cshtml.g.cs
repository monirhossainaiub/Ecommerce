#pragma checksum "E:\Projects\Book\Ecommerce\Ecom.App\Views\Product\FormPopUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7e5a564f498ad96d441cd216a878fa12a6f7604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_FormPopUp), @"mvc.1.0.view", @"/Views/Product/FormPopUp.cshtml")]
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
#line 1 "E:\Projects\Book\Ecommerce\Ecom.App\Views\_ViewImports.cshtml"
using Ecom.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projects\Book\Ecommerce\Ecom.App\Views\_ViewImports.cshtml"
using Ecom.App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7e5a564f498ad96d441cd216a878fa12a6f7604", @"/Views/Product/FormPopUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"404d8e866f71427d3308fb77e70630b138676721", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_FormPopUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-repeat", new global::Microsoft.AspNetCore.Html.HtmlString("option in languages"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-value", new global::Microsoft.AspNetCore.Html.HtmlString("{{option.id}}"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-repeat", new global::Microsoft.AspNetCore.Html.HtmlString("option in categories"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ng-repeat", new global::Microsoft.AspNetCore.Html.HtmlString("option in writers"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
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
                <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
                    <li class=""nav-item"">
                        <a class=""nav-link active"" id=""product-tab"" data-toggle=""tab"" href=""#product"" role=""tab"" aria-controls=""product"" aria-selected=""true"">Product</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""publisher-tab"" data-toggle=""tab"" href=""#publisher"" role=""tab"" ari");
            WriteLiteral(@"a-controls=""publisher"" aria-selected=""false"">Publisher</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""photo-tab"" data-toggle=""tab"" href=""#photo"" role=""tab"" aria-controls=""photo"" aria-selected=""false"">Photos</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link"" id=""note-tab"" data-toggle=""tab"" href=""#note"" role=""tab"" aria-controls=""note"" aria-selected=""false"">Notes</a>
                    </li>
                </ul>
                <div class=""tab-content"" id=""myTabContent"">
                    <div class=""tab-pane fade show active"" id=""product"" role=""tabpanel"" aria-labelledby=""product-tab"">
                        <div class=""form-elements form-horizontal"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f76047704", async() => {
                WriteLiteral(@"
                                <input type=""hidden"" ng-model=""model.id"">
                                <div class=""row"">
                                    <div class=""col-sm-6"">
                                        <div class=""form-group"">
                                            <label for=""name"">Name<sup>*</sup></label>
                                            <input ng-change=""isExistName()""
                                                   type=""text""
                                                   class=""form-control""
                                                   id=""name""
                                                   name=""name""
                                                   ng-model=""model.name""
                                                   required
                                                   autocomplete=""off""
                                                   maxlength=""150""
                                                   autofocus>
    ");
                WriteLiteral(@"                                    </div>
                                        <span class=""text-danger"" ng-show=""(form.name.$touched || form.name.$dirty) && form.name.$invalid"">Name is required.</span>
                                        <span class=""text-danger"" ng-show=""form.name.$dirty && isExist"">This name is already exits.</span>
                                    </div>
                                    <div class=""col-sm-6"">
                                        <label for=""language"">Select a language <sup>*</sup></label>
                                        <select required class=""form-control"" name=""languageId"" id=""language"" ng-model=""model.languageId"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f76049806", async() => {
                    WriteLiteral("--Select language--");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f760411086", async() => {
                    WriteLiteral("{{option.name}}");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        </select>
                                        <span class=""text-danger"" ng-show=""(form.languageId.$dirty || form.languageId.$touched)  && form.languageId.$invalid"">Language is required.</span>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-6"">
                                        <div class=""form-group"">
                                            <label for=""edition"">Display Order</label>
                                            <input type=""text""
                                                   class=""form-control""
                                                   id=""displayOrder""
                                                   name=""displayOrder""
                                                   ng-model=""model.displayOrder""
                                                   autocomplete=""off"">
 ");
                WriteLiteral(@"                                       </div>
                                    </div>
                                    <div class=""col-sm-6"">
                                        <label for=""category"">Select a category <sup>*</sup></label>
                                        <select required class=""form-control"" name=""categoryId"" id=""category"" ng-model=""model.categoryId"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f760413814", async() => {
                    WriteLiteral("--Select category--");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f760415095", async() => {
                    WriteLiteral("{{option.name}}");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        </select>
                                        <span class=""text-danger"" ng-show=""form.categoryId.$dirty  && form.categoryId.$invalid"">Category is required.</span>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-6"">
                                        <label for=""writer"">Select a writer <sup>*</sup></label>
                                        <select required class=""form-control"" name=""writerId"" id=""writer"" ng-model=""model.writerId"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f760416990", async() => {
                    WriteLiteral("Select writer");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e5a564f498ad96d441cd216a878fa12a6f760418265", async() => {
                    WriteLiteral("{{option.name}}");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        </select>
                                        <span class=""text-danger"" ng-show=""(form.writerId.$dirty || form.writerId.$touched)  && form.writerId.$invalid"">Writer is required.</span>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-12 form-group"">
                                        <label for=""description"">Title / Short description<sup>*</sup></label>
                                        <textarea class=""form-control""
                                                  id=""title""
                                                  rows=""2""
                                                  name=""title""
                                                  required
                                                  ng-model=""model.title""></textarea>
                                        <span class=""text-danger"" ng");
                WriteLiteral(@"-show=""form.title.$touched && form.title.$invalid"">Titel name is required.</span>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-12 form-group"">
                                        <label for=""description"">Description</label>
                                        <textarea class=""form-control""
                                                  id=""description""
                                                  rows=""3""
                                                  name=""description""
                                                  ng-model=""model.description""></textarea>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-sm-12 d-block d-flex justify-content-end"">
                                        <button type=""b");
                WriteLiteral(@"utton"" class=""btn btn-secondary"" data-dismiss=""modal"">
                                            <i class=""fa fa-times-circle fa-lg""></i> Close
                                        </button>
                                        <button ng-click=""reset()"" type=""button"" class=""btn btn-secondary"">
                                            <i class=""fa fa-refresh"" aria-hidden=""true""></i> Reset
                                        </button>
                                        <button ng-click=""formSubmit()"" ng-disabled=""form.$invalid || isExist"" type=""button"" class=""btn btn-primary"">
                                            <i class=""fa fa-save fa-lg"" fa-save""></i>
                                            {{action}}
                                        </button>
                                    </div>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
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
                    <div class=""tab-pane fade"" id=""publisher"" role=""tabpanel"" aria-labelledby=""publisher-tab"">Publisher</div>
                    <div class=""tab-pane fade"" id=""photo"" role=""tabpanel"" aria-labelledby=""photo-tab"">Photos</div>
                    <div class=""tab-pane fade"" id=""note"" role=""tabpanel"" aria-labelledby=""note-tab"">Notes</div>
                </div>
            </div>
            </div>
            <div class=""modal-footer"">
                
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
