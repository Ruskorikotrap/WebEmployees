#pragma checksum "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "562fa3d5ab849cc0cd46b1587dd6b0d7f513ec50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_File_Upload), @"mvc.1.0.view", @"/Views/File/Upload.cshtml")]
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
#line 1 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\_ViewImports.cshtml"
using WebEmployees;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\_ViewImports.cshtml"
using WebEmployees.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"562fa3d5ab849cc0cd46b1587dd6b0d7f513ec50", @"/Views/File/Upload.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2305f2296a52ab9402e996cb960b91f40c0747db", @"/Views/_ViewImports.cshtml")]
    public class Views_File_Upload : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml"
  ViewData["Title"] = "Upload File"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Upload File</h1>

<div id=""MyPopup"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">
                    &times;
                </button>
                <h4 class=""modal-title""></h4>
            </div>
            <div class=""modal-body"">
                <span id=""lblError""></span>
            </div>
            <div class=""modal-footer"">
                <input type=""button"" id=""btnClosePopup"" value=""Close"" class=""btn btn-danger"" data-dismiss=""modal"" />
            </div>
        </div>
    </div>
</div>
");
#nullable restore
#line 23 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml"
 if (ViewBag.ErrorMessage != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n            window.onload = function () {\r\n                $(\"#lblError\").html(\'");
#nullable restore
#line 27 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml"
                                Write(Html.Raw(ViewBag.ErrorMessage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n                $(\"#MyPopup\").modal(\"show\");\r\n            };\r\n    </script>\r\n");
#nullable restore
#line 31 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml"
 using (Html.BeginForm("Upload", "File", FormMethod.Post, new { enctype = "multipart/form-data" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input type=\"file\" name=\"file\" />\r\n    <input type=\"submit\" value=\"OK\" />\r\n");
#nullable restore
#line 36 "C:\Users\kents\source\repos\WebEmployees\WebEmployees\Views\File\Upload.cshtml"
}

#line default
#line hidden
#nullable disable
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
