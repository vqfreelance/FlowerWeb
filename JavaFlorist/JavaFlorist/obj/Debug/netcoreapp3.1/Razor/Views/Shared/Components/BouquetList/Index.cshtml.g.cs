#pragma checksum "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e491feb457ec086d28773e5648390a9d3c702f1"
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
#line 1 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e491feb457ec086d28773e5648390a9d3c702f1", @"/Views/Shared/Components/BouquetList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Views_Shared_Components_BouquetList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JavaFlorist.Models.Item>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""col-lg-4 col-xs-12"">
    <div class=""sidebar__inner"" id=""cart-summary"">
        <div class=""border-wrapp padding-0"">
            <div class=""order-cart-header hover-cursor"" onClick=""if($(this).find('.fa').hasClass('fa-angle-down')){$(this).find('.fa').removeClass('fa-angle-down').addClass('fa-angle-up');}else{$(this).find('.fa').removeClass('fa-angle-up').addClass('fa-angle-down');};$(this).next().toggle('fast');"">
                <p>Product</p>
                <p class=""total-item"" style=""float:right"">1 Product <i class=""fa fa-angle-down""></i></p>
            </div>
            <div class=""order-cart-content"">
");
#nullable restore
#line 11 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                 foreach (var i in ViewBag.cart)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"order-cart-content-item\">\r\n                        <p>\r\n                            <a");
            BeginWriteAttribute("title", " title=\"", 887, "\"", 910, 1);
#nullable restore
#line 15 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
WriteAttributeValue("", 895, i.Bouquet.Name, 895, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 15 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                                  Write(i.Bouquet.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                            <span> x ");
#nullable restore
#line 16 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                Write(i.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </p>\r\n                        <p style=\"float:right\">");
#nullable restore
#line 18 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                           Write((@i.Quantity* @i.Bouquet.Price).ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 20 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
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
                    <p style=""float:right"">");
#nullable restore
#line 31 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                      Write(ViewBag.total.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
                <div class=""order-cart-content-item shipping_price"" style=""display:none"">
                    <p>Ship</p>
                    <p style=""float:right"">$5.00</p>
                </div>
                <hr>
                <div class=""order-cart-content-item cart-all-total"">
                    <p>Total</p>
                    <p style=""float:right"">
                        <span class=""hidden have_ship"">");
#nullable restore
#line 41 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
                                                   Write((ViewBag.total+5).ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"no_ship\">");
#nullable restore
#line 42 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Shared\Components\BouquetList\Index.cshtml"
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
