#pragma checksum "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\ProductsByPublisher.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85c90082b9df69de382ff6331bdbbf9a4111fad6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ProductsByPublisher), @"mvc.1.0.view", @"/Views/Product/ProductsByPublisher.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85c90082b9df69de382ff6331bdbbf9a4111fad6", @"/Views/Product/ProductsByPublisher.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"404d8e866f71427d3308fb77e70630b138676721", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ProductsByPublisher : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("products_submit.php"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("accept-charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app/Controllers/public/homeController.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Projects\Monir\Ecommerce\Ecommerce\Ecom.App\Views\Product\ProductsByPublisher.cshtml"
  
    ViewData["Title"] = "Publisher wise products";
    Layout = "~/Views/Shared/Public/_PublicLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div ng-controller=""homeController as $ctrl"">
    <div class=""row"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-sm-2 col-md-2 col-lg-2"">
                    <div class=""sidebar-products-main"">
                        <div class=""sidebar-single"">
                            <div class=""sidebar-title"">
                                <a data-toggle=""collapse"" class=""pointer"" aria-expanded=""true"" data-target=""#brandCollapse"" aria-controls=""#brandCollapse"">
                                    <span class=""pull-left title-sidebar"">Filter By Brand</span>
                                    <span class=""pull-right""><i class=""fa fa-plus""></i></span>
                                    <span class=""pull-right""><i class=""fa fa-minus""></i></span>
                                    <div class=""clearfix""></div>
                                </a>
                            </div> <!--End Sidebar title div-->

                            <div id=""bran");
            WriteLiteral("dCollapse\" class=\"collapse in\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c90082b9df69de382ff6331bdbbf9a4111fad66262", async() => {
                WriteLiteral("\r\n                                    <input type=\"search\" name=\"brand_name\" class=\"form-control\"");
                BeginWriteAttribute("value", " value=\"", 1376, "\"", 1384, 0);
                EndWriteAttribute();
                WriteLiteral(@" placeholder=""Type Brand Name"" />

                                    <input type=""checkbox"" id=""c1"" name=""prodcut_id[]"" />
                                    <label for=""c1""><span></span>T-Shirt</label><br />

                                    <input type=""checkbox"" id=""c2"" name=""prodcut_id[]"" />
                                    <label for=""c2""><span></span>Pant</label><br />

                                    <input type=""checkbox"" id=""c3"" name=""prodcut_id[]"" />
                                    <label for=""c3""><span></span>Genji</label><br />

                                    <input type=""checkbox"" id=""c4"" name=""prodcut_id[]"" />
                                    <label for=""c4""><span></span>Full Shirt</label><br />

                                    <input type=""checkbox"" id=""c5"" name=""prodcut_id[]"" />
                                    <label for=""c5""><span></span>Half Shirt</label><br />

                                    <input type=""submit"" name=""submit_brand_searc");
                WriteLiteral("h\" class=\"btn btn-red pull-right btn-sm\" value=\"Search\">\r\n                                    <div class=\"clearfix\"></div>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div> <!--End Single Sidebar-->

                        <div class=""sidebar-single"">
                            <div class=""sidebar-title"">
                                <a data-toggle=""collapse"" class=""pointer"" aria-expanded=""true"" data-target=""#brandPriceCollapse"" aria-controls=""#brandPriceCollapse"">
                                    <span class=""pull-left title-sidebar"">Filter By Price</span>

                                    <span class=""pull-right""><i class=""fa fa-plus""></i></span>
                                    <span class=""pull-right""><i class=""fa fa-minus""></i></span>
                                    <div class=""clearfix""></div>
                                </a>
                            </div> <!--End Sidebar title div-->

                            <div id=""brandPriceCollapse"" class=""collapse in"">

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c90082b9df69de382ff6331bdbbf9a4111fad610366", async() => {
                WriteLiteral(@"

                                    <input type=""checkbox"" id=""price1"" name=""prodcut_price[]"" />
                                    <label for=""price1""><span></span>0-100TK</label><br />

                                    <input type=""checkbox"" id=""price2"" name=""prodcut_price[]"" />
                                    <label for=""price2""><span></span>100-500TK</label><br />

                                    <input type=""checkbox"" id=""price3"" name=""prodcut_price[]"" />
                                    <label for=""price3""><span></span>500-1000TK</label><br />

                                    <input type=""checkbox"" id=""price4"" name=""prodcut_price[]"" />
                                    <label for=""price4""><span></span>1000-2000TK</label><br />

                                    <input type=""checkbox"" id=""price5"" name=""prodcut_price[]"" />
                                    <label for=""price5""><span></span>2000-500TK</label><br />

                                    <input type=");
                WriteLiteral(@"""checkbox"" id=""price6"" name=""prodcut_price[]"" />
                                    <label for=""price6""><span></span>5000-1000TK</label><br />

                                    <input type=""checkbox"" id=""price7"" name=""prodcut_price[]"" />
                                    <label for=""price7""><span></span>10000-20000TK</label><br />

                                    <input type=""checkbox"" id=""price9"" name=""prodcut_price[]"" />
                                    <label for=""price9""><span></span>20000-100000TK</label><br />

                                    <input type=""checkbox"" id=""price10"" name=""prodcut_price[]"" />
                                    <label for=""price10""><span></span>100000- + TK</label><br />

                                    <input type=""submit"" name=""submit_brand_search"" class=""btn btn-red pull-right btn-sm"" value=""Search"">
                                    <div class=""clearfix""></div>
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div> <!--End Single Sidebar-->

                        <div class=""sidebar-single"">
                            <div class=""sidebar-title"">
                                <a data-toggle=""collapse"" class=""pointer"" aria-expanded=""true"" data-target=""#productColorCollapse"" aria-controls=""#productColorCollapse"">
                                    <span class=""pull-left title-sidebar"">Filter By Color</span>

                                    <span class=""pull-right""><i class=""fa fa-plus""></i></span>
                                    <span class=""pull-right""><i class=""fa fa-minus""></i></span>
                                    <div class=""clearfix""></div>
                                </a>
                            </div> <!--End Sidebar title div-->

                            <div id=""productColorCollapse"" class=""collapse in"">

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c90082b9df69de382ff6331bdbbf9a4111fad615070", async() => {
                WriteLiteral(@"

                                    <input type=""checkbox"" id=""color0"" name=""prodcut_color[]"" />
                                    <label for=""color0"" style=""color:#9c9""><span></span>White</label><br />

                                    <input type=""checkbox"" id=""color1"" name=""prodcut_color[]"" />
                                    <label for=""color1"" style=""color:#f00""><span></span>Red</label><br />

                                    <input type=""checkbox"" id=""color2"" name=""prodcut_color[]"" />
                                    <label for=""color2"" style=""color:#00f""><span></span>Blue</label><br />

                                    <input type=""checkbox"" id=""color3"" name=""prodcut_color[]"" />
                                    <label for=""color3"" style=""color:#008000""><span></span>Green</label><br />

                                    <input type=""checkbox"" id=""color4"" name=""prodcut_color[]"" />
                                    <label for=""color4"" style=""color:#ffc0cb""><span></");
                WriteLiteral(@"span>Pink</label><br />

                                    <input type=""checkbox"" id=""color5"" name=""prodcut_color[]"" />
                                    <label for=""color5"" style=""color:#ffd700""><span></span>Gold</label><br />

                                    <input type=""checkbox"" id=""color6"" name=""prodcut_color[]"" />
                                    <label for=""color6"" style=""color:#ffa500""><span></span>Orange</label><br />

                                    <input type=""checkbox"" id=""color7"" name=""prodcut_color[]"" />
                                    <label for=""color7"" style=""color:#ffa500""><span></span>Other</label><br />
                                    <input type=""name"" id=""color7"" class=""form-control"" placeholder=""Color name"" name=""prodcut_color[]"" /><br />


                                    <input type=""submit"" name=""submit_brand_search"" class=""btn btn-red pull-right btn-sm"" value=""Search"">
                                    <div class=""clearfix""></div>
        ");
                WriteLiteral("                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div> <!--End Single Sidebar-->

                        <div class=""sidebar-single"">
                            <div class=""sidebar-title"">
                                <a data-toggle=""collapse"" class=""pointer"" aria-expanded=""true"" data-target=""#productReviewCollapse"" aria-controls=""#productReviewCollapse"">
                                    <span class=""pull-left title-sidebar"">Filter By Review</span>

                                    <span class=""pull-right""><i class=""fa fa-plus""></i></span>
                                    <span class=""pull-right""><i class=""fa fa-minus""></i></span>
                                    <div class=""clearfix""></div>
                                </a>
                            </div> <!--End Sidebar title div-->

                            <div id=""productReviewCollapse"" class=""collapse in"">

                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c90082b9df69de382ff6331bdbbf9a4111fad619898", async() => {
                WriteLiteral(@"

                                    <input type=""checkbox"" id=""review1"" name=""prodcut_review[]"" />
                                    <label for=""review1"" style=""color:#008000"">
                                        <span></span>
                                        <i class=""fa fa-star""></i> <i class=""fa fa-star""></i> <i class=""fa fa-star""></i> <i class=""fa fa-star""></i> <i class=""fa fa-star""></i>
                                    </label><br />
                                    <input type=""checkbox"" id=""review2"" name=""prodcut_review[]"" />
                                    <label for=""review2"" style=""color:#6f6"">
                                        <span></span>
                                        <i class=""fa fa-star""></i> <i class=""fa fa-star""></i> <i class=""fa fa-star""></i> <i class=""fa fa-star""></i>
                                    </label><br />
                                    <input type=""checkbox"" id=""review3"" name=""prodcut_review[]"" />
                      ");
                WriteLiteral(@"              <label for=""review3"" style=""color:#9c9"">
                                        <span></span>
                                        <i class=""fa fa-star""></i> <i class=""fa fa-star""></i> <i class=""fa fa-star""></i>
                                    </label><br />
                                    <input type=""checkbox"" id=""review4"" name=""prodcut_review[]"" />
                                    <label for=""review4"" style=""color:#f99"">
                                        <span></span>
                                        <i class=""fa fa-star""></i> <i class=""fa fa-star""></i>
                                    </label><br />
                                    <input type=""checkbox"" id=""review5"" name=""prodcut_review[]"" />
                                    <label for=""review5"" style=""color:#fc9"">
                                        <span></span>
                                        <i class=""fa fa-star""></i>
                                    </label><br />


  ");
                WriteLiteral("                                  <input type=\"submit\" name=\"submit_brand_search\" class=\"btn btn-red pull-right btn-sm\" value=\"Search\">\r\n                                    <div class=\"clearfix\"></div>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div> <!--End Single Sidebar-->



                    </div>
                </div>
                <div class=""col-sm-10 col-md-10 col-lg-10"">
                    <div class=""all-products"">
                        <div");
            BeginWriteAttribute("class", " class=\"", 12332, "\"", 12340, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <h2 class=""title-div wow slideInRight"" data-wow-duration=""1s"" data-wow-delay=""0s"" data-wow-offset=""10"">Our Latest Products available</h2>
                            <div class=""products"">
                                <div class=""row"" ng-repeat=""product in products"">
                                    <div class=""col-md-3"" style=""float:left"">
                                        <div class=""product-item"">
                                            <div class=""product-borde-inner"">
                                                <a href=""product_single.html"">
                                                    <img src=""{{imageRootDirectory+product.image}}"" alt=""{{product.name}}"" class=""img img-responsive"" />
                                                </a>
                                                <div class=""product-price"">
                                                    <a href=""product_single.html"">{{product.name}}</a><br />
                  ");
            WriteLiteral(@"                                  <span class=""prev-price"" ng-show=""product.oldPrice > product.price"">
                                                        <del>{{product.oldPrice}}</del>
                                                    </span>
                                                    <span class=""current-price"">
                                                        {{product.price}}
                                                    </span>
                                                </div>

                                                <a href=""cart.html"" class=""btn btn-cart text-center add-to-cart pull-right"">
                                                    <i class=""fa fa-cart-plus""></i>
                                                    Add to cart
                                                </a>
                                                <div class=""clear""></div>
                                            </div>
                                     ");
            WriteLiteral(@"   </div>
                                    </div><!-- End Latest products[single] -->
                                    
                                    <div class=""clear""></div>
                                </div> <!-- End Latest products row-->
                                <a class=""btn btn-blue btn-lg pull-right btn-more wow slideInRight"" data-wow-duration=""1s"" data-wow-delay=""0s"" data-wow-offset=""10"">
                                    <span>See More products.. </span>
                                </a>
                                <div class=""clear""></div>
                            </div> <!-- End products div-->
                        </div> <!-- End container latest products-->
                    </div>  <!-- End Latest products -->
                </div>
            </div>



        </div>
    </div>
</div>


");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "85c90082b9df69de382ff6331bdbbf9a4111fad627525", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
