#pragma checksum "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "649ac57fc31143b2ad078f2053e63725242f44d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_PaypalConfirm), @"mvc.1.0.view", @"/Views/Account/PaypalConfirm.cshtml")]
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
#line 1 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"649ac57fc31143b2ad078f2053e63725242f44d0", @"/Views/Account/PaypalConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Views_Account_PaypalConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
  
    ViewData["Title"] = "PaypalConfirm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"document-box\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "649ac57fc31143b2ad078f2053e63725242f44d03761", async() => {
                WriteLiteral(@"

        <div class=""col-md-12"">
            <div class=""document-box"">
                <div class=""row"" id=""main-content"">
                    <div class=""customer-address col-lg-6"" style=""border:3px"">
                        <p class=""title"">Order Info</p>
                        <table>
                            <tr>
                                <td width=100px height=30px>Oderer: </td>
                                <td><b>");
#nullable restore
#line 18 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                  Write(ViewBag.acc.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                            </tr>\r\n                        </table>\r\n\r\n");
#nullable restore
#line 22 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                         if (ViewBag.sender.Name != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <p class=""title"">Sender Info</p>
                            <table>
                                <tr>
                                    <td width=100px height=30px>Sender: </td>
                                    <td><b>");
#nullable restore
#line 28 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.sender.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px>Sender Address: </td>\r\n                                    <td><b>");
#nullable restore
#line 32 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.sender.Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px>Phone: </td>\r\n                                    <td><b>");
#nullable restore
#line 36 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.sender.Phone);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px>Email: </td>\r\n                                    <td><b>");
#nullable restore
#line 40 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.sender.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px></td>\r\n                                </tr>\r\n                            </table>\r\n");
#nullable restore
#line 46 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <p class=\"title\">Reciver Info</p>\r\n                        <table>\r\n");
#nullable restore
#line 50 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                             if (ViewBag.receiver.Name != null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td width=100px height=30px>Receiver: </td>\r\n                                    <td><b>");
#nullable restore
#line 54 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.receiver.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px>Sender Address: </td>\r\n                                    <td><b>");
#nullable restore
#line 58 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.receiver.Address);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px>Phone: </td>\r\n                                    <td><b>");
#nullable restore
#line 62 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.receiver.Phone);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px>Email: </td>\r\n                                    <td><b>");
#nullable restore
#line 66 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      Write(ViewBag.receiver.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td width=100px height=30px></td>\r\n                                </tr>\r\n");
#nullable restore
#line 71 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <tr>
                                    <td width=100px height=30px>Receive: </td>
                                    <td><b>Receive goods at the store</b></td>
                                </tr>
                                <tr>
                                    <td width=100px height=30px></td>
                                </tr>
");
#nullable restore
#line 81 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </table>
                        <p class=""title"">Order Status</p>
                        <table>
                            <tr>
                                <td width=100px height=30px>Time Delivery: </td>
                                <td><b>");
#nullable restore
#line 87 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                  Write(ViewBag.order.ReceivingTime);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td width=100px height=30px>Message: </td>\r\n                                <td><b>");
#nullable restore
#line 91 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                  Write(ViewBag.order.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</b></td>
                            </tr>
                        </table>
                    </div>

                    <div class=""col-lg-4 col-xs-12"">
                        <div class=""sidebar__inner"" id=""cart-summary"">
                            <div class=""border-wrapp padding-0"">
                                <div class=""order-cart-header hover-cursor"" onClick=""if ($(this).find('.fa').hasClass('fa-angle-down')) { $(this).find('.fa').removeClass('fa-angle-down').addClass('fa-angle-up'); } else { $(this).find('.fa').removeClass('fa-angle-up').addClass('fa-angle-down'); };$(this).next().toggle('fast');"">
                                    <p>Product</p>
                                    <p class=""total-item"" style=""float: right"">1 Product <i class=""fa fa-angle-down""></i></p>
                                </div>
                                <div class=""order-cart-content"">

");
#nullable restore
#line 105 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                      
                                        var index = 1;
                                    

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 109 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                     foreach (var i in ViewBag.cart)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div class=\"order-cart-content-item\">\r\n                                            <p>\r\n                                                <a");
                BeginWriteAttribute("title", " title=\"", 5755, "\"", 5778, 1);
#nullable restore
#line 113 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 5763, i.Bouquet.Name, 5763, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 113 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                                                      Write(i.Bouquet.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                                                <span> x ");
#nullable restore
#line 114 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                                    Write(i.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                            </p>\r\n                                            <p style=\"float: right\">\r\n                                                ");
#nullable restore
#line 117 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                            Write((i.Quantity * i.Bouquet.Price).ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 6193, "\"", 6218, 2);
                WriteAttributeValue("", 6200, "item_number_", 6200, 12, true);
#nullable restore
#line 119 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6212, index, 6212, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 6219, "\"", 6240, 1);
#nullable restore
#line 119 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6227, i.Bouquet.Id, 6227, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 6314, "\"", 6337, 2);
                WriteAttributeValue("", 6321, "item_name_", 6321, 10, true);
#nullable restore
#line 120 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6331, index, 6331, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 6338, "\"", 6361, 1);
#nullable restore
#line 120 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6346, i.Bouquet.Name, 6346, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 6435, "\"", 6455, 2);
                WriteAttributeValue("", 6442, "amount_", 6442, 7, true);
#nullable restore
#line 121 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6449, index, 6449, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 6456, "\"", 6480, 1);
#nullable restore
#line 121 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6464, i.Bouquet.Price, 6464, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                                <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 6554, "\"", 6576, 2);
                WriteAttributeValue("", 6561, "quantity_", 6561, 9, true);
#nullable restore
#line 122 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6570, index, 6570, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 6577, "\"", 6596, 1);
#nullable restore
#line 122 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6585, i.Quantity, 6585, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                            </p>\r\n                                        </div>\r\n");
#nullable restore
#line 125 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                        index++;
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <input type=\"hidden\" name=\"handling_cart\"");
                BeginWriteAttribute("value", " value=\"", 6866, "\"", 6887, 1);
#nullable restore
#line 127 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 6874, ViewBag.ship, 6874, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">

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
#line 138 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                                          Write(ViewBag.sum.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                    </div>
                                    <div class=""order-cart-content-item shipping_price"">
                                        <p>Ship</p>
                                        <p style=""float:right"">");
#nullable restore
#line 142 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                                          Write(ViewBag.ship.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                    </div>
                                    <hr>
                                    <div class=""order-cart-content-item cart-all-total"">
                                        <p>Total</p>
                                        <p style=""float:right"">
                                            <span class=""no_ship"">");
#nullable restore
#line 148 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
                                                             Write(ViewBag.total.ToString("C", CultureInfo.CurrentCulture));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""btn-box"">
                    <input class=""btn btn-primary"" type=""submit"" value=""Pay with PayPal"" />
                </div>
            </div>
        </div>

        <input type=""hidden"" name=""upload"" value=""1"" />
        <input type=""hidden"" name=""business""");
                BeginWriteAttribute("value", " value=\"", 8807, "\"", 8845, 1);
#nullable restore
#line 163 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 8815, ViewBag.paypalConfig.Business, 8815, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"cmd\" value=\"_cart\" />\r\n        <input type=\"hidden\" name=\"return\"");
                BeginWriteAttribute("value", " value=\"", 8951, "\"", 9008, 3);
#nullable restore
#line 165 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 8959, ViewBag.paypalConfig.ReturnUrl, 8959, 31, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8990, "/", 8990, 1, true);
#nullable restore
#line 165 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
WriteAttributeValue("", 8991, ViewBag.order.Id, 8991, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 8 "C:\Aptech\WindowsForms\ASPNetCoreEproject\JavaFlorist2\JavaFlorist\JavaFlorist\Views\Account\PaypalConfirm.cshtml"
AddHtmlAttributeValue("", 173, ViewBag.paypalConfig.PostUrl, 173, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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