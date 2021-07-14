#pragma checksum "D:\ThongTinYTe\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8379eca412e17278fa76e0774590bf3420481312"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\ThongTinYTe\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ThongTinYTe\Views\_ViewImports.cshtml"
using ThongTinYTe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\ThongTinYTe\Views\_ViewImports.cshtml"
using ThongTinYTe.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\ThongTinYTe\Views\_ViewImports.cshtml"
using ThongTinYTe.CovidVnServices.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8379eca412e17278fa76e0774590bf3420481312", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06ac4047343e029f02fe85f5d9009ea3dfb0ebe2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\ThongTinYTe\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .map-container {
        position: absolute;
        top: clamp(9vh, 9%, 15vh);
        left: 0;
        right: 0;
        bottom:40vh;
    }

    .map-frame {
        border: 2px solid black;
        height: 100%;
    }

    #worldmap {
        height: 50vh;
    }
    #map{
        position: absolute;
        top:75%;
    }
</style>
<div class=""map-container"">
    <div class=""map-frame"">
        <div id=""worldmap"" data-value=""");
#nullable restore
#line 28 "D:\ThongTinYTe\Views\Home\Index.cshtml"
                                  Write(ViewBag.countries);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""></div>
    </div>
   
</div>
 
<script>
    var southWest = L.latLng(-89.98155760646617, -180),
        northEast = L.latLng(89.99346179538875, 180);
    var bounds = L.latLngBounds(southWest, northEast);
    var worldmap = L.map('worldmap', {
        center: [39.8282, -98.5795],
        maxBounds: bounds,
        zoom: 3
    });
    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 5,
        minZoom: 3,
        attribution: '&copy; <a href=""http://www.openstreetmap.org/copyright"">OpenStreetMap</a>'
    });

    tiles.addTo(worldmap);
    var countries = $(""#worldmap"").data(""value"");

    var cases = [];
    for (const c of countries) {
        cases.push(c.cases);
    }
    for (const c of countries) {
        const lon = c.countryInfo.long;
        const lat = c.countryInfo.lat;
        const circle = L.circle([lat, lon], {
            radius: 1000000 * (c.cases / Math.max(...cases))
        });

        circle.bindPopup(""");
            WriteLiteral(@"<div style='text-align:center'><img class='img-thumbnail' src='"" + c.countryInfo.flag + ""'/><span><strong>"" + c.country + ""</strong></span></br><p>Cases: "" + c.cases + "" </p><p>Deaths: "" + c.deaths + "" </p><p>Recovered: "" + c.recovered + "" </p></div>"");
        circle.addTo(worldmap);
    }



</script>
");
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
