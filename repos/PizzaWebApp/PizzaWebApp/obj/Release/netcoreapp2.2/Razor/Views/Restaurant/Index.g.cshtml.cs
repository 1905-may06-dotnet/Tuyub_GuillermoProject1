#pragma checksum "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d653eba38eb598dcc7466c91a43d29264fc0fb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurant_Index), @"mvc.1.0.view", @"/Views/Restaurant/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Restaurant/Index.cshtml", typeof(AspNetCore.Views_Restaurant_Index))]
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
#line 1 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\_ViewImports.cshtml"
using PizzaWebApp;

#line default
#line hidden
#line 2 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\_ViewImports.cshtml"
using PizzaWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d653eba38eb598dcc7466c91a43d29264fc0fb8", @"/Views/Restaurant/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecafee7b281a8aa538eeabe8240a060d1702a2d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurant_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PizzaWebApp.Models.ResLocation>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
  
    ViewData["Title"] = "Restaurant Options";


#line default
#line hidden
            BeginContext(110, 137, true);
            WriteLiteral("\r\n    <h1>Choose Restaurant:</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th width=\"256px\">\r\n\r\n                ");
            EndContext();
            BeginContext(248, 43, false);
#line 15 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ResName));

#line default
#line hidden
            EndContext();
            BeginContext(291, 71, true);
            WriteLiteral("\r\n            </th>\r\n            <th width=\"128px\">\r\n\r\n                ");
            EndContext();
            BeginContext(363, 41, false);
#line 19 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
            EndContext();
            BeginContext(404, 69, true);
            WriteLiteral("\r\n            </th>\r\n            <th width=\"128px\">\r\n                ");
            EndContext();
            BeginContext(474, 40, false);
#line 22 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(514, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(570, 43, false);
#line 25 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(613, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(731, 62, true);
            WriteLiteral("        <tr>\r\n            <td width=\"256px\">\r\n                ");
            EndContext();
            BeginContext(794, 72, false);
#line 34 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.ActionLink(item.ResName,"Pizzabuilder", new {id = item.LocationId}));

#line default
#line hidden
            EndContext();
            BeginContext(866, 85, true);
            WriteLiteral("                \r\n            </td>\r\n            <td width=\"128px\">\r\n                ");
            EndContext();
            BeginContext(952, 40, false);
#line 37 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.State));

#line default
#line hidden
            EndContext();
            BeginContext(992, 69, true);
            WriteLiteral("\r\n            </td>\r\n            <td width=\"128px\">\r\n                ");
            EndContext();
            BeginContext(1062, 39, false);
#line 40 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
            EndContext();
            BeginContext(1101, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1157, 42, false);
#line 43 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Zipcode));

#line default
#line hidden
            EndContext();
            BeginContext(1199, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1255, 74, false);
#line 46 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
           Write(Html.ActionLink("CheckInventory","Inventory", new { id = item.LocationId}));

#line default
#line hidden
            EndContext();
            BeginContext(1329, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 49 "C:\Users\guill\source\repos\PizzaWebApp\PizzaWebApp\Views\Restaurant\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1368, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PizzaWebApp.Models.ResLocation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
