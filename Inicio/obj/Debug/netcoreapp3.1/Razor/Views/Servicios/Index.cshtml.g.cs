#pragma checksum "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a70ee87259215a45c7c513425c97f72047a7d077"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Servicios_Index), @"mvc.1.0.view", @"/Views/Servicios/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Servicios/Index.cshtml", typeof(AspNetCore.Views_Servicios_Index))]
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
#line 1 "X:\web\PortalRequisiciones\Inicio\Views\_ViewImports.cshtml"
using Inicio;

#line default
#line hidden
#line 2 "X:\web\PortalRequisiciones\Inicio\Views\_ViewImports.cshtml"
using Inicio.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a70ee87259215a45c7c513425c97f72047a7d077", @"/Views/Servicios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b65c8bb7fcba6c4c21c5e584c0edacef356624", @"/Views/_ViewImports.cshtml")]
    public class Views_Servicios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Datos.Models.REQUISC>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
  
    ViewData["Title"] = "Requisiciones de Servicios";
    var datos_json = Json.Serialize(ViewBag.ListadoServicios);
    DateTime hoy = DateTime.Now;

    string miVariable = hoy.ToString("dd/MM/yyyy");
    ViewBag.FechaHoy = miVariable;
    miVariable = hoy.ToString("MM/yyyy");
    ViewBag.Fecha1 = "01/"+miVariable;

#line default
#line hidden
            BeginContext(378, 190, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row mt-1\">\r\n        <div class=\"col-sm-12\">\r\n            <ol class=\"breadcrumb float-sm-right\">\r\n                <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(569, 67, false);
#line 18 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                                       Write(Html.ActionLink(ViewData["Title"].ToString(), "Index", "Servicios"));

#line default
#line hidden
            EndContext();
            BeginContext(636, 225, true);
            WriteLiteral("</li>\r\n            </ol>\r\n        </div>\r\n    </div>\r\n    <div class=\"row mb-4\">\r\n        <div class=\"col-sm-4 col-md-2\">\r\n            <label>Fecha Desde</label>\r\n            <input id=\"fecha_desde\" class=\"form-control fecha\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 861, "\"", 884, 1);
#line 25 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
WriteAttributeValue("", 869, ViewBag.Fecha1, 869, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(885, 164, true);
            WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-sm-4 col-md-2\">\r\n            <label>Fecha Hasta</label>\r\n            <input id=\"fecha_hasta\" class=\"form-control fecha\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1049, "\"", 1074, 1);
#line 29 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
WriteAttributeValue("", 1057, ViewBag.FechaHoy, 1057, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1075, 613, true);
            WriteLiteral(@" />
        </div>
        <div class=""col-sm-4 col-md-2"">
            <label>&nbsp;</label><br />
            <button class=""btn btn-primary"" onclick=""buscar_index()"">
                <i class=""fa fa-search""></i>
                Buscar
            </button>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""card card-danger card-outline"">
                <div class=""card-header mb-1"">
                    <h5 class=""float-left"">
                        Listado de Requisiciones de Servicios
                    </h5>
                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1688, "\"", 1729, 1);
#line 46 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
WriteAttributeValue("", 1695, Url.Action("Create", "Servicios"), 1695, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1730, 494, true);
            WriteLiteral(@" class=""btn btn-primary float-right"">
                        <i class=""fa fa-plus""></i>
                        Nuevo
                    </a>
                </div>
                <div class=""card-body p-2"">
                    <table id=""GridServiciosIndex"" class=""table table-hover table-striped pre-scrollable2 dataTables"">
                        <thead class=""bg-info"">
                            <tr>
                                <th>
                                    ");
            EndContext();
            BeginContext(2225, 42, false);
#line 56 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NUMERO));

#line default
#line hidden
            EndContext();
            BeginContext(2267, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2383, 47, false);
#line 59 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.SOLICITANTE));

#line default
#line hidden
            EndContext();
            BeginContext(2430, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2546, 40, false);
#line 62 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.AREA));

#line default
#line hidden
            EndContext();
            BeginContext(2586, 134, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th style=\"width: 30%\">\r\n                                    ");
            EndContext();
            BeginContext(2721, 41, false);
#line 65 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.FECHA));

#line default
#line hidden
            EndContext();
            BeginContext(2762, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2878, 42, false);
#line 68 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.ESTADO));

#line default
#line hidden
            EndContext();
            BeginContext(2920, 766, true);
            WriteLiteral(@"
                                </th>
                                <th style=""max-width: 5px""></th>
                                <th style=""max-width: 5px""></th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    $(function () {
        $("".fecha"").datepicker({
            language: 'es',
            format: 'dd/mm/yyyy',
            autoclose: true,
            startDate: '-1Y',
            endDate: '+1Y',
            orientation: 'bottom'
        });

        $("".fecha"").inputmask('99/99/9999', { numericInput: true });

        var datos = JSON.parse('");
            EndContext();
            BeginContext(3687, 20, false);
#line 94 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                           Write(Html.Raw(datos_json));

#line default
#line hidden
            EndContext();
            BeginContext(3707, 324, true);
            WriteLiteral(@"');
        activar_datos(datos.value);
    });

    function buscar_index() {
        var fecha_desde = $(""#fecha_desde"").val();
        var fecha_hasta = $(""#fecha_hasta"").val();

        if ((fecha_desde != """") && (fecha_hasta != """")) {
            $.ajax({
                type: 'POST',
                url: '");
            EndContext();
            BeginContext(4032, 43, false);
#line 105 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                 Write(Url.Action("ListadoServicios", "Servicios"));

#line default
#line hidden
            EndContext();
            BeginContext(4075, 1362, true);
            WriteLiteral(@"',
                dataType: ""json"",
                data: 'fecha_desde='+fecha_desde+'&fecha_hasta='+fecha_hasta,
                cache: false,
                success: function (result) {
                    activar_datos(result);
                },
            });
        }
    }

    function activar_datos(datos) {
        $(""#GridServiciosIndex"").DataTable({
            destroy: true,
            bInfo: false,
            data: datos,
            columns: [
                { data: ""numero"" },
                { data: ""solicitante"" },
                { data: ""area"" },
                {
                    ""render"": function (data, type, row) {
                        var arreglo1 = row.fecha.split(""T"");
                        var arreglo = arreglo1[0].split(""-"");
                        if (arreglo[2].length < 2) arreglo[2] = ""0"" + arreglo[2];
                        if (arreglo[1].length < 2) arreglo[1] = ""0"" + arreglo[1];
                        var myDate = arreglo[2] + ""/"" + ");
            WriteLiteral(@"arreglo[1] + ""/"" + arreglo[0];

                        return myDate;
                    }
                },
                { data: ""estado"" },
                {
                    render: function (data, type, row)
                    {
                        return '<a class=""btn btn-info grid_opt"" title=""Editar"" href=""");
            EndContext();
            BeginContext(5438, 39, false);
#line 140 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                                                                                 Write(Url.Content("~/Servicios/Edit?codigo="));

#line default
#line hidden
            EndContext();
            BeginContext(5477, 1109, true);
            WriteLiteral(@"'+row.numero+'""><i class=""fa fa-edit""></i></a>';
                    }
                },
                {
                    data: null, render: function (data, type, row) {
                        return '<a class=""btn btn-danger"" title=""Anular"" href=""#"" onclick=""anular_rServicio(\'' + row.numero + '\')""><i class=""fa fa-trash""></i></a>';
                    }
                },
            ]
        });
    }

    function anular_rServicio(nrorequi) {
        swal({
            title: ""¿Estás seguro?"",
            text: ""Confirmar Anulado del registro: "" + nrorequi,
            type: ""info"",
            showCancelButton: true,
            confirmButtonClass: ""btn-danger"",
            cancelButtonClass: ""btn-secondary"",
            confirmButtonText: ""Aceptar"",
            cancelButtonText: ""Cancelar"",
        },
        function (isConfirm) {
            if (isConfirm) {
                var parametros = ""id="" + nrorequi;
                $.ajax(
                {
               ");
            WriteLiteral("     type: \"POST\",\r\n                    dataType: \"json\",\r\n                    url: \"");
            EndContext();
            BeginContext(6587, 33, false);
#line 170 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                     Write(Url.Content("~/Servicios/Delete"));

#line default
#line hidden
            EndContext();
            BeginContext(6620, 222, true);
            WriteLiteral("\",\r\n                    data: parametros,\r\n                    cache: false,\r\n                    success: function (datos) {\r\n                        if (datos.resultado) {\r\n                            window.location = \'");
            EndContext();
            BeginContext(6843, 27, false);
#line 175 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                                          Write(Url.Content("~/Servicios/"));

#line default
#line hidden
            EndContext();
            BeginContext(6870, 732, true);
            WriteLiteral(@"';
                        } else {
                            swal({
                                title: ""Error"",
                                text: datos.error,
                                type: ""error"",
                                confirmButtonClass: ""btn-danger"",
                            });
                        }
                    },
                    error: function (xhr) {
                        swal({
                            title: ""Error"",
                            text: xhr.responseText,
                            confirmButtonClass: ""btn-danger"",
                        });
                    },
                });
            }
        });
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Datos.Models.REQUISC>> Html { get; private set; }
    }
}
#pragma warning restore 1591
