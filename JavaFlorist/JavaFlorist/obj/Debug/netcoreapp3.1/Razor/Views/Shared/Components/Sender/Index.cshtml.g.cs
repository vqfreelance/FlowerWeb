#pragma checksum "C:\Users\avMacWin\Documents\FlowerWeb\JavaFlorist\JavaFlorist\Views\Shared\Components\Sender\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b27bd24dd88ab45f0b6993573bd5366d016dcd90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Sender_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Sender/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b27bd24dd88ab45f0b6993573bd5366d016dcd90", @"/Views/Shared/Components/Sender/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Views_Shared_Components_Sender_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<JavaFlorist.Models.Account>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("20"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/home-1.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/eco-friendly.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("get-sender-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""border-wrapp"">
    <div class=""customer-address"">
        <p class=""title"">Sender Info</p>

        <div class=""kt-radio-list"">
            <label class=""kt-radio kt-radio--success"">
                <input type=""radio"" name=""send_type"" value=""user"" checked>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b27bd24dd88ab45f0b6993573bd5366d016dcd904827", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("This User<span></span>\r\n            </label>\r\n            <label class=\"kt-radio kt-radio--success\">\r\n                <input type=\"radio\" name=\"send_type\" value=\"sender\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b27bd24dd88ab45f0b6993573bd5366d016dcd906121", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("Sender<span></span>\r\n            </label>\r\n        </div>\r\n\r\n        <div class=\"sender-info\" id=\"blk-sender\" style=\"display:none\">\r\n            <div class=\"row\">\r\n                <div class=\"col-lg-12 col-xs-12\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b27bd24dd88ab45f0b6993573bd5366d016dcd907490", async() => {
                WriteLiteral(@"
                        <div class=""form-group"">
                            <label>Name</label>
                            <input class=""form-control"" type=""text"" name=""sender_name"" id=""sender_name"" placeholder=""Name"">
                        </div>
                        <div class=""form-group"">
                            <label>Phone Number</label>
                            <input class=""form-control"" type=""text"" name=""sender_phone"" id=""sender_phone"" placeholder=""Phone Number"">
                        </div>
                        <div class=""form-group"">
                            <label>Email</label>
                            <input class=""form-control"" type=""email"" name=""sender_email"" id=""sender_email"" placeholder=""Email"">
                        </div>
                        <div class=""form-group"">
                            <label>Address</label>
                            <input class=""form-control"" type=""text"" name=""sender_address"" id=""sender_address"" placeholder=""Addres");
                WriteLiteral("s\">\r\n                        </div>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
        </div>

        <div class=""sender-info"" id=""blk-user"" >
            <div class=""row"">
                <div class=""col-lg-12 col-xs-12"">
                    <table>
                        <tr>
                            <td width=60px height=30px>Name: </td>
                            <td><b>");
#nullable restore
#line 46 "C:\Users\avMacWin\Documents\FlowerWeb\JavaFlorist\JavaFlorist\Views\Shared\Components\Sender\Index.cshtml"
                              Write(ViewBag.acc.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td width=60px height=30px>Address: </td>\r\n                            <td><b>");
#nullable restore
#line 50 "C:\Users\avMacWin\Documents\FlowerWeb\JavaFlorist\JavaFlorist\Views\Shared\Components\Sender\Index.cshtml"
                              Write(ViewBag.acc.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td width=60px height=30px>Phone: </td>\r\n                            <td><b>");
#nullable restore
#line 54 "C:\Users\avMacWin\Documents\FlowerWeb\JavaFlorist\JavaFlorist\Views\Shared\Components\Sender\Index.cshtml"
                              Write(ViewBag.acc.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td width=60px height=30px>Email: </td>\r\n                            <td><b>");
#nullable restore
#line 58 "C:\Users\avMacWin\Documents\FlowerWeb\JavaFlorist\JavaFlorist\Views\Shared\Components\Sender\Index.cshtml"
                              Write(ViewBag.acc.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<JavaFlorist.Models.Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
