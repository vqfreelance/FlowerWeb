#pragma checksum "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5313631ca4fc68dfde7d7d3ca4cc68678ad1cef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bouquet_Detail), @"mvc.1.0.view", @"/Views/Bouquet/Detail.cshtml")]
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
#line 1 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5313631ca4fc68dfde7d7d3ca4cc68678ad1cef", @"/Views/Bouquet/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Views_Bouquet_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "bouquet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("<div class=\"top-detail-product\">\r\n    <ol class=\"breadcrumb\">\r\n        <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5313631ca4fc68dfde7d7d3ca4cc68678ad1cef4966", async() => {
                WriteLiteral("Home");
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
            WriteLiteral("</li>\r\n        <li class=\"breadcrumb-item active\">Bouquet</li>\r\n    </ol>\r\n    <div class=\"bouquet-detail\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-5 text-center\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c5313631ca4fc68dfde7d7d3ca4cc68678ad1cef6541", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 571, "~/images/bouquets/", 571, 18, true);
#nullable restore
#line 18 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
AddHtmlAttributeValue("", 589, ViewBag.bouquet.Photo, 589, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-lg-7\">\r\n                <h1 class=\"title\" itemprop=\"name\">");
#nullable restore
#line 21 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
                                             Write(ViewBag.bouquet.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <div class=\"product-feture\">\r\n                    ");
#nullable restore
#line 23 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
               Write(ViewBag.bouquet.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>

                <div class=""seperate-line""></div>

                <div class=""product-info quantity"">
                    <p>Quantity</p>
                    <p><input id=""quantity"" type=""text"" name=""quantity""></p>
                </div>
                <div class=""product-info"">
                    <p>Price at shop</p>
                    <p class=""price"">");
#nullable restore
#line 34 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
                                Write(ViewBag.bouquet.Price.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                    <div class=\"seperate-line\"></div>\r\n\r\n                    <div class=\"btn-box\">\r\n                        <input hidden");
            BeginWriteAttribute("value", " value=\"", 1471, "\"", 1498, 1);
#nullable restore
#line 39 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
WriteAttributeValue("", 1479, ViewBag.bouquet.Id, 1479, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""bouquetid"" />

                        <input class=""btn btn-success"" type=""button"" value=""Buy Now"" id=""buynow"" />

                        <input class=""btn btn-info"" type=""button"" value=""Add Cart"" id=""addcart"" />
                    </div>
                    <p>
                        <small>Actual product images may differ from its illustration (bloom, accessories, etc)</small>
                    </p>
                    <div class=""services-guarante-bouquet"">
                        <ul>
                            <li>
                                <a><i class=""fa fa-money"" aria-hidden=""true""></i> Fair Price</a>
                            </li>
                            <li>
                                <a><i class=""fa fa-truck"" aria-hidden=""true""></i> Delivery in 5 Hours</a>
                            </li>
                            <li>
                                <a><i class=""fa fa-pagelines"" aria-hidden=""true""></i> Fresh Flowers in 3 Days</a>
                ");
            WriteLiteral(@"            </li>
                            <li>
                                <a><i class=""fa fa-leaf"" aria-hidden=""true""></i> Environment Friendly</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
    </div>
</div>
<div class=""content-detail-product"">
    <h1 class=""title"">");
#nullable restore
#line 69 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
                 Write(ViewBag.bouquet.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>\r\n        ");
#nullable restore
#line 71 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
   Write(ViewBag.bouquet.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n</div>\r\n\r\n<div class=\"seperate-line\"></div>\r\n\r\n<div class=\"related-products group-product-wrapp\">\r\n    <h4 style=\"align-content: center\">RELATED FLOWERS ");
            WriteLiteral("</h4>\r\n    <div class=\"row bouquet-list\">\r\n");
#nullable restore
#line 80 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
         foreach (var b in ViewBag.randombouquets)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\"width: 12rem;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5313631ca4fc68dfde7d7d3ca4cc68678ad1cef12478", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c5313631ca4fc68dfde7d7d3ca4cc68678ad1cef12754", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3473, "~/images/bouquets/", 3473, 18, true);
#nullable restore
#line 84 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
AddHtmlAttributeValue("", 3491, b.Photo, 3491, 8, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 84 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
AddHtmlAttributeValue("", 3506, b.Name, 3506, 7, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
                                                                  WriteLiteral(b.Id);

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
            WriteLiteral("\r\n\r\n                <div class=\"card-body\">\r\n                    <h5 class=\"card-title\">");
#nullable restore
#line 88 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
                                      Write(b.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text\">");
#nullable restore
#line 89 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
                                     Write(b.Price.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 92 "E:\BasicCode\Vu\JavaFlorist\JavaFlorist\Views\Bouquet\Detail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
