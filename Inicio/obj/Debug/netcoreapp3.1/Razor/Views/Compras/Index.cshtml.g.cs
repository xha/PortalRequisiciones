#pragma checksum "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48a8c693f711e4bc5d3abb54348ca971736e4cd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Compras_Index), @"mvc.1.0.view", @"/Views/Compras/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Compras/Index.cshtml", typeof(AspNetCore.Views_Compras_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48a8c693f711e4bc5d3abb54348ca971736e4cd4", @"/Views/Compras/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b65c8bb7fcba6c4c21c5e584c0edacef356624", @"/Views/_ViewImports.cshtml")]
    public class Views_Compras_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Datos.Models.REQUISC>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
  
    ViewData["Title"] = ViewBag.Titulo;
    var datos_json = Json.Serialize(ViewBag.ListadoCompras);
    DateTime hoy = DateTime.Now;

    string miVariable = hoy.ToString("dd/MM/yyyy");
    ViewBag.FechaHoy = miVariable;
    miVariable = hoy.ToString("MM/yyyy");
    ViewBag.Fecha1 = "01/"+miVariable;

#line default
#line hidden
            BeginContext(362, 81, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <input type=\"hidden\" id=\"error\" name=\"error\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 443, "\"", 465, 1);
#line 15 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 451, ViewBag.error, 451, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(466, 162, true);
            WriteLiteral(" />\r\n    <div class=\"row mt-1\">\r\n        <div class=\"col-sm-12\">\r\n            <ol class=\"breadcrumb float-sm-right\">\r\n                <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(629, 85, false);
#line 19 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                       Write(Html.ActionLink("Requisiciones de "+ViewData["Title"].ToString(), "Index", "Compras"));

#line default
#line hidden
            EndContext();
            BeginContext(714, 225, true);
            WriteLiteral("</li>\r\n            </ol>\r\n        </div>\r\n    </div>\r\n    <div class=\"row mb-4\">\r\n        <div class=\"col-sm-4 col-md-2\">\r\n            <label>Fecha Desde</label>\r\n            <input id=\"fecha_desde\" class=\"form-control fecha\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 939, "\"", 962, 1);
#line 26 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 947, ViewBag.Fecha1, 947, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(963, 164, true);
            WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-sm-4 col-md-2\">\r\n            <label>Fecha Hasta</label>\r\n            <input id=\"fecha_hasta\" class=\"form-control fecha\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1127, "\"", 1152, 1);
#line 30 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 1135, ViewBag.FechaHoy, 1135, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1153, 550, true);
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
                        Listado Requisiciones de ");
            EndContext();
            BeginContext(1704, 28, false);
#line 45 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                            Write(ViewData["Title"].ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1732, 51, true);
            WriteLiteral("\r\n                    </h5>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1783, "\"", 1822, 1);
#line 47 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 1790, Url.Action("Create", "Compras"), 1790, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1823, 492, true);
            WriteLiteral(@" class=""btn btn-primary float-right"">
                        <i class=""fa fa-plus""></i>
                        Nuevo
                    </a>
                </div>
                <div class=""card-body p-2"">
                    <table id=""GridComprasIndex"" class=""table table-hover table-striped pre-scrollable2 dataTables"">
                        <thead class=""bg-info"">
                            <tr>
                                <th>
                                    ");
            EndContext();
            BeginContext(2316, 42, false);
#line 57 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NUMERO));

#line default
#line hidden
            EndContext();
            BeginContext(2358, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2474, 47, false);
#line 60 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.SOLICITANTE));

#line default
#line hidden
            EndContext();
            BeginContext(2521, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2637, 40, false);
#line 63 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.AREA));

#line default
#line hidden
            EndContext();
            BeginContext(2677, 134, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th style=\"width: 30%\">\r\n                                    ");
            EndContext();
            BeginContext(2812, 41, false);
#line 66 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.FECHA));

#line default
#line hidden
            EndContext();
            BeginContext(2853, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2969, 42, false);
#line 69 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.ESTADO));

#line default
#line hidden
            EndContext();
            BeginContext(3011, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(3127, 51, false);
#line 72 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NRO_REQUISICION));

#line default
#line hidden
            EndContext();
            BeginContext(3178, 726, true);
            WriteLiteral(@"
                                </th>
                                <th>Acci&oacute;n</th>
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

        revisar_error();
        
        var datos = JSON.parse('");
            EndContext();
            BeginContext(3905, 20, false);
#line 99 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                           Write(Html.Raw(datos_json));

#line default
#line hidden
            EndContext();
            BeginContext(3925, 381, true);
            WriteLiteral(@"');
        activar_datos(datos.value);
        if (datos.value.error!= undefined) session_finalizada();
    });

    function session_finalizada() {
        swal({
            title: ""Alerta"",
            text: ""La sesión ha caducado"",
            type: ""info"",
            confirmButtonText: ""Aceptar"",
        });

        setTimeout(function(){ window.location = '");
            EndContext();
            BeginContext(4307, 31, false);
#line 112 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                             Write(Url.Action("Logout", "Account"));

#line default
#line hidden
            EndContext();
            BeginContext(4338, 669, true);
            WriteLiteral(@"'; }, 3000);
    }

    function revisar_error() {
        if ($(""#error"").val() != """") {
            swal({
                title: ""Alerta"",
                text: $(""#error"").val(),
                type: ""info"",
                confirmButtonText: ""Aceptar"",
            });
            //MostrarMensaje(""Rojo"", $(""#error"").val());
            $(""#error"").val("""");
        }
    }

    function buscar_index() {
        var fecha_desde = $(""#fecha_desde"").val();
        var fecha_hasta = $(""#fecha_hasta"").val();

        if ((fecha_desde != """") && (fecha_hasta != """")) {
            $.ajax({
                type: 'POST',
                url: '");
            EndContext();
            BeginContext(5008, 39, false);
#line 135 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                 Write(Url.Action("ListadoCompras", "Compras"));

#line default
#line hidden
            EndContext();
            BeginContext(5047, 1702, true);
            WriteLiteral(@"',
                dataType: ""json"",
                data: 'fecha_desde='+fecha_desde+'&fecha_hasta='+fecha_hasta,
                cache: false,
                success: function (result) {
                    activar_datos(result);
                    if (result.error!= undefined) session_finalizada();
                },
            });
        }
    }

    function activar_datos(datos) {
        $(""#GridComprasIndex"").DataTable({
            destroy: true,
            bInfo: false,
            data: datos,
            columnDefs:
            [{
                targets: [6],
                orderable: false,
                searchable: false
            }],
            columns: [
                { data: ""numero"" },
                { data: ""solicitante"" },
                { data: ""area"" },
                {
                    ""render"": function (data, type, row) {
                        var arreglo1 = row.fecha.split(""T"");
                        var arreglo = arreglo1[0].split");
            WriteLiteral(@"(""-"");
                        if (arreglo[2].length < 2) arreglo[2] = ""0"" + arreglo[2];
                        if (arreglo[1].length < 2) arreglo[1] = ""0"" + arreglo[1];
                        var myDate = arreglo[2] + ""/"" + arreglo[1] + ""/"" + arreglo[0];

                        return myDate;
                    }
                },
                { data: ""estado"" },
                { data: ""nrO_REQUISICION"" },
                {
                    render: function (data, type, row)
                    {
                        if (row.estado == ""P"") {
                            var cadena = '<a class=""btn btn-primary mr-1"" title = ""Consultar"" href=""");
            EndContext();
            BeginContext(6750, 42, false);
#line 179 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                                               Write(Url.Content("~/Compras/Consultar?codigo="));

#line default
#line hidden
            EndContext();
            BeginContext(6792, 3219, true);
            WriteLiteral(@"' + row.numero + '"" > <i class=""fa fa-search""></i></a > ';
                            cadena+= '<a class=""btn btn-danger mr-1"" title=""Eliminar"" href=""#"" onclick=""anular_rcompra(\'' + row.numero + '\')""><i class=""fa fa-trash""></i></a>';
                            return cadena;
                        } else {
                            return '';
                        }
                        
                    }
                },
                /*{
                    render: function (data, type, row)
                    {
                        if (row.estado == ""P"") {
                            return '<a class=""btn btn-info grid_opt"" title=""Editar"" href=""Url.Content(""~/Compras/Edit?codigo="")'+row.numero+'""><i class=""fa fa-edit""></i></a>';
                        } else {
                            return '';
                        }
                        
                    }
                },
                {
                    data: null, render: function (data,");
            WriteLiteral(@" type, row) {
                        if (row.estado == ""P"") {
                            return '<a class=""btn btn-danger"" title=""Eliminar"" href=""#"" onclick=""anular_rcompra(\'' + row.numero + '\')""><i class=""fa fa-trash""></i></a>';
                            //return '<a class=""btn btn-danger"" title=""Eliminar""  href=""Url.Content(""~/Compras/Delete?codigo="")'+row.numero+'""><i class=""fa fa-trash""></i></a>';
                        } else {
                            return '';
                        }                        
                    }
                },*/
            ]
        });
    }
    
    function anular_rcompra(nrorequi) {
        swal({
            title: ""¿Estás seguro?"",
            text: ""Confirmar Anulado del registro: "" + nrorequi,
            type: ""info"",
            showCancelButton: true,
            confirmButtonClass: ""btn-danger"",
            cancelButtonClass: ""btn-secondary"",
            confirmButtonText: ""Aceptar"",
            cancelButtonText: ""Can");
            WriteLiteral(@"celar"",
        },
        function (isConfirm) {
            if (isConfirm) {
                var parametros = ""id="" + nrorequi;
                /*$.ajax(
                {
                    type: ""POST"",
                    dataType: ""json"",
                    url: ""Url.Content(""~/Compras/Delete"")"",
                    data: parametros,
                    cache: false,
                    success: function (datos) {
                        if (datos.error != """") {
                            //MostrarMensaje(""Rojo"", datos.error);
                            $(""#error"").val(datos.error);
                            revisar_error();
                        } else {
                            window.location = 'Url.Content(""~/Compras/Index"")';
                        };
                    },
                    error: function (xhr) {
                        swal({
                            title: ""Alerta"",
                            text: xhr.responseText,
                   ");
            WriteLiteral("         confirmButtonClass: \"btn-danger\",\r\n                        });\r\n                    },\r\n                });*/\r\n                var url = \'");
            EndContext();
            BeginContext(10012, 54, false);
#line 251 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                      Write(Url.Action("Delete", "Compras", new { codigo = "Id" }));

#line default
#line hidden
            EndContext();
            BeginContext(10066, 204, true);
            WriteLiteral("\';\r\n                url = url.replace(\'Id\', encodeURIComponent(nrorequi));\r\n                window.location.href = url;\r\n                //console.log(url);\r\n            }\r\n        });\r\n    }\r\n</script>\r\n");
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
