#pragma checksum "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c71958cdad4d9fdac94be7833eb1a5d0f1a8f8f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LastTemple.Pages.Gameplay.Pages_Gameplay_BattleField), @"mvc.1.0.razor-page", @"/Pages/Gameplay/BattleField.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c71958cdad4d9fdac94be7833eb1a5d0f1a8f8f", @"/Pages/Gameplay/BattleField.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3c18532471ce0cf9b00af6aaf5ff81b7c10d676", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Gameplay_BattleField : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <div class=\"row\">\r\n        <div id=\"logDiv\" style=\"background:#505050; border-top:20px; border-color:white; overflow: auto; height:400px;\" class=\"col-10\">\r\n            <ul>\r\n                <li>");
#nullable restore
#line 10 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
               Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" atakuje Szczur i zadaje mu 3 puntków obrażeń</li>\r\n                <li>");
#nullable restore
#line 11 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
               Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" atakuje Szczur i zadaje mu 1 puntków obrażeń</li> \r\n                <li>");
#nullable restore
#line 12 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
               Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" atakuje Szczur i pudłuje</li>\r\n                <li>Szczur atakuje ");
#nullable restore
#line 13 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                              Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" i zadaje 3 punkty obrażeń</li>\r\n                <li>Szczur atakuje ");
#nullable restore
#line 14 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                              Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" i zadaje 2 punkty obrażeń</li>           \r\n                <li>");
#nullable restore
#line 15 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
               Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" atakuje Szczur i zadaje mu 5 puntków obrażeń co kończy się jego śmiercią</li>\r\n\r\n            </ul>\r\n        </div>\r\n\r\n        <div id=\"enemies\" class=\"col-2\">\r\n");
#nullable restore
#line 21 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
             foreach(var item in Model.Enemies)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"             <div class=""form-group"">

                 <div class=""btn-group btn-group-toggle"" data-toggle=""buttons"">
                     <label class=""btn btn-outline-warning active"" onclick=""getCheckedValue()"">                         
                         ");
#nullable restore
#line 27 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                     </label>\r\n                 </div>\r\n\r\n                 <br />\r\n                 <span>Życie ");
#nullable restore
#line 32 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                        Write(item.HitPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 32 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                                          Write(item.MaxHP);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 32 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                                                        Write(item.Alive);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> <br />\r\n                 <span>Mana ");
#nullable restore
#line 33 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                       Write(item.Mana);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 33 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                                    Write(item.MaxMana);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> <br />\r\n                 <span>Punkty Akcji ");
#nullable restore
#line 34 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                               Write(item.Mana);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 34 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                                            Write(item.MaxMana);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n             </div>\r\n");
#nullable restore
#line 36 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
                
               
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-10 offset-1 text-center\">\r\n            <p>");
#nullable restore
#line 44 "E:\Repos\LastTemple\LastTemple\Pages\Gameplay\BattleField.cshtml"
          Write(Model.Hero.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            <button class=""btn btn-outline-info"">xxx</button>
            <button class=""btn btn-outline-info"">xxxxx</button>
            <button class=""btn btn-outline-info"">xxxxxxxxx</button>
            <button class=""btn btn-outline-info"">xxxxxx</button>
            <button class=""btn btn-outline-info"">xxxx</button>
        </div>
    </div>
</div>

<script type=""text/javascript"">   
    
    function getCheckedValue() {
        var radios = document.getElementsByName(""enemies"");
       
        for (i = 0; i < radios.length; i++)
        {
            if (radios[i].checked) { // jeżeli jest wybrany to jeśli nie ma jej (if) to dodaj klasę active do label jak nie to ją usuń (jeśli istnieje if)
                if (radios[i].par.classList.contains(""active"")) {
                    radios[i].parentElement.classList.add(""active"");
                }
               
            }
            else
                radios[i].parentElement.classList.remove(""active"");
        }
    }

");
            WriteLiteral("</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LastTemple.Pages.Gameplay.BattlefieldModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LastTemple.Pages.Gameplay.BattlefieldModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LastTemple.Pages.Gameplay.BattlefieldModel>)PageContext?.ViewData;
        public LastTemple.Pages.Gameplay.BattlefieldModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
