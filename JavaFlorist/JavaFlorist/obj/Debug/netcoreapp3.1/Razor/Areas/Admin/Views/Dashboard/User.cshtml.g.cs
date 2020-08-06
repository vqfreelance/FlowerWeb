#pragma checksum "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b46bf31289b1c092335e546a286fef73cad8c0d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_User), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/User.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b46bf31289b1c092335e546a286fef73cad8c0d2", @"/Areas/Admin/Views/Dashboard/User.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dashboard_User : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("user photo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
  
    ViewData["Title"] = "User";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Main content -->\r\n<section class=\"content\">\r\n\r\n    <!-- Default box -->\r\n    <div class=\"card card-solid\">\r\n        <div class=\"card-body pb-0\">\r\n            <div class=\"row d-flex align-items-stretch\">\r\n");
#nullable restore
#line 14 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                 foreach (var user in ViewBag.users)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-12 col-sm-6 col-md-4 d-flex align-items-stretch"">
                        <div class=""card bg-light"">
                            <div class=""card-header text-muted border-bottom-0"">
                                User ID: ");
#nullable restore
#line 19 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                                    Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />\r\n                                Username: ");
#nullable restore
#line 21 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                                     Write(user.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""card-body pt-0"">
                                <div class=""row"">
                                    <div class=""col-7"">
                                        <h2 class=""lead""><b>");
#nullable restore
#line 26 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                                                       Write(user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b></h2>                               
                                        <ul class=""ml-4 mb-0 fa-ul text-muted"">
                                            <li class=""small""><span class=""fa-li""><i class=""fas fa-lg fa-building""></i></span> Address: ");
#nullable restore
#line 28 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                                                                                                                                   Write(user.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                            <li class=\"small\"><span class=\"fa-li\"><i class=\"fas fa-lg fa-phone\"></i></span> Phone #: +84 ");
#nullable restore
#line 29 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                                                                                                                                    Write(user.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                            <li class=\"small\"><span class=\"fa-li\"><i class=\"fas fa-lg fa-envelope\"></i></span> Email: ");
#nullable restore
#line 30 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                                                                                                                                 Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                        </ul>\r\n                                    </div>\r\n                                    <div class=\"col-5 text-center\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b46bf31289b1c092335e546a286fef73cad8c0d27712", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1824, "~/images/user/", 1824, 14, true);
#nullable restore
#line 34 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
AddHtmlAttributeValue("", 1838, user.Photo, 1838, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                            </div>
                            <div class=""card-footer"">
                                <div class=""text-right"">
                                    <a href=""#"" class=""btn btn-sm bg-teal"">
                                        <i class=""fas fa-comments""></i>
                                    </a>
                                    <a href=""#"" class=""btn btn-sm btn-primary"">
                                        <i class=""fas fa-user""></i> View Profile
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
");
#nullable restore
#line 50 "D:\Aptech ADSE\eProject - S3\Source Tree\JavaFlorist\JavaFlorist\Areas\Admin\Views\Dashboard\User.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>
        <!-- /.card-body -->
        <div class=""card-footer"">
            <nav aria-label=""Contacts Page Navigation"">
                <ul class=""pagination justify-content-center m-0"">
                    <li class=""page-item active""><a class=""page-link"" href=""#"">1</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">2</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">4</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">5</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">6</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">7</a></li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">8</a></li>
                </ul>
            </nav>
        </div>
        <!-- /.card-footer -->
    </div>
    <!-- /.car");
            WriteLiteral("d -->\r\n\r\n</section>\r\n<!-- /.content -->\r\n");
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
