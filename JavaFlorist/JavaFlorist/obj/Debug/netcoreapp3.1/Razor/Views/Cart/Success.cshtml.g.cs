#pragma checksum "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bc0c13604ab61e5732a5d8b1cbdfd261eb177d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Success), @"mvc.1.0.view", @"/Views/Cart/Success.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bc0c13604ab61e5732a5d8b1cbdfd261eb177d8", @"/Views/Cart/Success.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Views_Cart_Success : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
  
    ViewData["Title"] = "Success";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Transaction Details</h1>\r\n<div>\r\n    \r\n    ");
#nullable restore
#line 10 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.GrossTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n    ");
#nullable restore
#line 11 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.InvoiceNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 12 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.PaymentStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 13 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.PayerFirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 14 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.PaymentFee);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 15 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.BusinessEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 16 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.PayerEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 17 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.TxToken);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 18 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.PayerLastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 19 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.ReceiverEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 20 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.ItemName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 21 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.Currency);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 22 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.TransactionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 23 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.SubscriberId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 24 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Cart\Success.cshtml"
Write(ViewBag.result.Custom);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
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