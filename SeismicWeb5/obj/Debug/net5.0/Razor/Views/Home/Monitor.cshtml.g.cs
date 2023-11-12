#pragma checksum "C:\Users\Arthur\source\repos\SeismicWeb5\SeismicWeb5\Views\Home\Monitor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6481d9991aff3e1a6a6c40ce1a2328b82843e527"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Monitor), @"mvc.1.0.view", @"/Views/Home/Monitor.cshtml")]
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
#line 1 "C:\Users\Arthur\source\repos\SeismicWeb5\SeismicWeb5\Views\_ViewImports.cshtml"
using SeismicWeb5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Arthur\source\repos\SeismicWeb5\SeismicWeb5\Views\_ViewImports.cshtml"
using SeismicWeb5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6481d9991aff3e1a6a6c40ce1a2328b82843e527", @"/Views/Home/Monitor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"002829d3e5efd7810669afd13dbd18c75a262c4e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Monitor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SeismicWeb5.Controllers.DataModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Arthur\source\repos\SeismicWeb5\SeismicWeb5\Views\Home\Monitor.cshtml"
  
    ViewData["Title"] = "Seismic Monitoring";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\Arthur\source\repos\SeismicWeb5\SeismicWeb5\Views\Home\Monitor.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<div>
    <!-- Your chart container -->
    <canvas id=""seismographChart"" width=""800"" height=""400""></canvas>
</div>

<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/4.4.0/chart.min.js""></script>

<!-- JavaScript code -->
<script>
    $(document).ready(function () {
        $.ajax({
            url: '");
#nullable restore
#line 21 "C:\Users\Arthur\source\repos\SeismicWeb5\SeismicWeb5\Views\Home\Monitor.cshtml"
             Write(Url.Action("GetDataFromFirebase", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                renderChart(data);
            },
            error: function (error) {
                console.error('Error fetching data from Firebase:', error);
            }
        });

        function renderChart(data) {
            var ctx = document.getElementById('seismographChart').getContext('2d');

            var chart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: data.map(item => item.timestamp),
                    datasets: [
                        {
                            label: 'X-Axis',
                            data: data.map(item => item.x),
                            borderColor: 'rgba(255, 99, 132, 1)',
                            borderWidth: 1,
                            fill: false
                        },
                        {
                            label: 'Y-Axis',
                  ");
            WriteLiteral(@"          data: data.map(item => item.y),
                            borderColor: 'rgba(75, 192, 192, 1)',
                            borderWidth: 1,
                            fill: false
                        },
                        {
                            label: 'Z-Axis',
                            data: data.map(item => item.z),
                            borderColor: 'rgba(153, 102, 255, 1)',
                            borderWidth: 1,
                            fill: false
                        }
                    ]
                },
                options: {
                    // Configure chart options as needed
                }
            });
        }
    });
</script>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SeismicWeb5.Controllers.DataModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
