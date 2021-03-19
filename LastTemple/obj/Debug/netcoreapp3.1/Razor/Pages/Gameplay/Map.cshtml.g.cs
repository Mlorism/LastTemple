#pragma checksum "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\Map.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddb7767443528f389b1f99ecd33cbab82fbea1a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LastTemple.Pages.Gameplay.Pages_Gameplay_Map), @"mvc.1.0.razor-page", @"/Pages/Gameplay/Map.cshtml")]
namespace LastTemple.Pages.Gameplay
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
#line 1 "E:\Repos\LastTemple\LastTemple\Pages\_ViewImports.cshtml"
using LastTemple;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddb7767443528f389b1f99ecd33cbab82fbea1a6", @"/Pages/Gameplay/Map.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3c18532471ce0cf9b00af6aaf5ff81b7c10d676", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Gameplay_Map : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("map"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/map.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mt-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("  <div class=\"text-center\"><h3>Świat po Ciszy</h3></div>\r\n<div id=\"mainDiv\" class=\"mapContainer\">    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ddb7767443528f389b1f99ecd33cbab82fbea1a64040", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"           
    <button id=""temple"" class=""btn btn-light location"" data-tooltip=""koszt podróży: "">Świątynia</button>    
    <button id=""troy"" class=""btn btn-light  location"" data-tooltip=""koszt podróży: "">Troja</button>

    <button id=""thebes"" class=""btn btn-light location"" data-tooltip=""koszt podróży: "">Teby</button>

    <button id=""outpost"" class=""btn btn-light location"" data-tooltip=""koszt podróży: "">Posterunek</button> ");
            WriteLiteral("\r\n    <button id=\"bandits\" class=\"btn btn-light location\" data-tooltip=\"koszt podróży: \">Obóz bandytów</button> ");
            WriteLiteral("\r\n    <button id=\"oracle\" class=\"btn btn-light location\" data-tooltip=\"koszt podróży: \">Wyrocznia</button> ");
            WriteLiteral("\r\n\r\n    <button id=\"library\" class=\"btn btn-light location\" data-tooltip=\"koszt podróży: \">Biblioteka</button> ");
            WriteLiteral("\r\n\r\n    <button id=\"tomb\" class=\"btn btn-light location\" data-tooltip=\"koszt podróży: \">Grobowiec</button> ");
            WriteLiteral("\r\n    \r\n    <button id=\"cathedral\" class=\"btn btn-light location\" data-tooltip=\"koszt podróży: \">Katedra</button> ");
            WriteLiteral(@"
</div>

<script type=""text/javascript"">

    let mainDiv = document.getElementById(""mainDiv"");
    setButtons();
    
    function setButtons() {
        let mapH = document.getElementById(""map"").clientHeight;
        let mapW = document.getElementById(""map"").clientWidth;
        let mapLeft = document.getElementById(""map"").offsetLeft;
        let mapTop = document.getElementById(""map"").offsetTop;

        let buttons = mainDiv.getElementsByTagName('button');

        for (i = 0; i < buttons.length; i++) {
            if (buttons[i].id == ""temple"") {               
               buttons[i].style.top = mapH * 0.77 + 'px';
               buttons[i].style.left = mapW * 0.15 + 'px';

            }

            else if (buttons[i].id == ""troy"") {
                buttons[i].style.top = mapH * 0.55 + 'px';
                buttons[i].style.left = mapW * 0.22 + 'px';
            }

            else if (buttons[i].id == ""thebes"") {
                buttons[i].style.top = mapH * 0.83 + 'px'");
            WriteLiteral(@";
                buttons[i].style.left = mapW * 0.48 + 'px';
            }

            else if (buttons[i].id == ""outpost"") {
                buttons[i].style.top = mapH * 0.625 + 'px';
                buttons[i].style.left = mapW * 0.63 + 'px';
            }

            else if (buttons[i].id == ""bandits"") {
                buttons[i].style.top = mapH * 0.97 + 'px';
                buttons[i].style.left = mapW * 0.60 + 'px';
            }

            else if (buttons[i].id == ""oracle"") {
                buttons[i].style.top = mapH * 0.55 + 'px';
                buttons[i].style.left = mapW * 0.63 + 'px';
            }

            else if (buttons[i].id == ""library"") {
                buttons[i].style.top = mapH * 0.42 + 'px';
                buttons[i].style.left = mapW * 0.42 + 'px';
            }

            else if (buttons[i].id == ""tomb"") {
                buttons[i].style.top = mapH * 0.5 + 'px';
                buttons[i].style.left = mapW * 0.85 + 'px';
            }");
            WriteLiteral("\n\r\n            else if (buttons[i].id == \"cathedral\") {\r\n                buttons[i].style.top = mapH * 0.12 + \'px\';\r\n                buttons[i].style.left = mapW * 0.63 + \'px\';\r\n            }\r\n        }\r\n\r\n    }\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LastTemple.Pages.Gameplay.MapModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LastTemple.Pages.Gameplay.MapModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LastTemple.Pages.Gameplay.MapModel>)PageContext?.ViewData;
        public LastTemple.Pages.Gameplay.MapModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
