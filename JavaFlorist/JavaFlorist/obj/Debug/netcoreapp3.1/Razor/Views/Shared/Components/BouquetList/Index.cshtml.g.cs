#pragma checksum "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2b4d4c27048394249a85dadfaec15a2722b7261"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_BouquetList_Index), @"mvc.1.0.view", @"/Views/Shared/Components/BouquetList/Index.cshtml")]
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
#line 1 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2b4d4c27048394249a85dadfaec15a2722b7261", @"/Views/Shared/Components/BouquetList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Views_Shared_Components_BouquetList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JavaFlorist.Models.Item>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:60px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""col-lg-3 col-xs-12"">
    <div class=""sidebar__inner"" id=""cart-summary"">
        <div class=""border-wrapp padding-0"">
            <div class=""order-cart-header hover-cursor"" onClick=""if($(this).find('.fa').hasClass('fa-angle-down')){$(this).find('.fa').removeClass('fa-angle-down').addClass('fa-angle-up');}else{$(this).find('.fa').removeClass('fa-angle-up').addClass('fa-angle-down');};$(this).next().toggle('fast');"">
                <p>Product</p>
                <p class=""total-item"">1 Product <i class=""fa fa-angle-down""></i></p>
            </div>
            <div class=""order-cart-content "">
");
#nullable restore
#line 11 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                 foreach (var i in ViewBag.cart)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"order-cart-content-item\">\r\n                        <p style=\"width: 25%; flex: 0 0 25%\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f2b4d4c27048394249a85dadfaec15a2722b72614865", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 910, "~/images/bouquets/", 910, 18, true);
#nullable restore
#line 15 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
AddHtmlAttributeValue("", 928, i.Bouquet.Photo, 928, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 15 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
AddHtmlAttributeValue("", 993, i.Bouquet.Name, 993, 15, false);

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
            WriteLiteral("\r\n                        </p>\r\n                        <p>\r\n                            <a class=\"p-name\" style=\"color: #333\"");
            BeginWriteAttribute("href", " href=\"", 1138, "\"", 1145, 0);
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1146, "\"", 1169, 1);
#nullable restore
#line 18 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
WriteAttributeValue("", 1154, i.Bouquet.Name, 1154, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 18 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                                                                             Write(i.Bouquet.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a><br>\r\n                            <span>x ");
#nullable restore
#line 19 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                               Write(i.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </p>\r\n                        <p>");
#nullable restore
#line 21 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                       Write((@i.Quantity* @i.Bouquet.Price).ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 23 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <div class=""border-wrapp padding-0"">
            <div class=""order-cart-header"">
                <p>Order summary</p>
            </div>
            <div class=""order-cart-content"">
                <div class=""order-cart-content-item"">
                    <p>Provisonal Sum</p>
                    <p>");
#nullable restore
#line 34 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                  Write(ViewBag.total.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
                <div class=""order-cart-content-item shipping_price"" style=""display:none"">
                    <p>Ship</p>
                    <p>$5.00</p>
                </div>
                <hr>
                <div class=""order-cart-content-item cart-all-total"">
                    <p>Total</p>
                    <p>
                        <span class=""hidden have_ship"">");
#nullable restore
#line 44 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                                   Write((ViewBag.total+5).ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"no_ship\">");
#nullable restore
#line 45 "C:\Aptech\WindowsForms\JavaFlorist\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                         Write(ViewBag.total.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JavaFlorist.Models.Item> Html { get; private set; }
    }
}
#pragma warning restore 1591
