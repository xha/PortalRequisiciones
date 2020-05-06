#pragma checksum "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e41bb294f0d78054ad884a953822da8753aecb2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Compras_Index), @"mvc.1.0.view", @"/Views/Compras/Index.cshtml")]
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
#line 1 "X:\web\PortalRequisiciones\Inicio\Views\_ViewImports.cshtml"
using Inicio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "X:\web\PortalRequisiciones\Inicio\Views\_ViewImports.cshtml"
using Inicio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e41bb294f0d78054ad884a953822da8753aecb2", @"/Views/Compras/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b65c8bb7fcba6c4c21c5e584c0edacef356624", @"/Views/_ViewImports.cshtml")]
    public class Views_Compras_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Datos.Models.REQUISC>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
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
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <input type=\"hidden\" id=\"error\" name=\"error\"");
            BeginWriteAttribute("value", " value=\"", 443, "\"", 465, 1);
#nullable restore
#line 15 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 451, ViewBag.error, 451, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <div class=\"row mt-1\">\r\n        <div class=\"col-sm-12\" style=\"background-color: #e9ecef\">\r\n            <ul class=\"breadcrumb float-right\">\r\n                <li class=\"breadcrumb-item active\">");
#nullable restore
#line 19 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                              Write(Html.ActionLink("Inicio de "+ViewData["Title"].ToString(), "Index", "Compras"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n    <div class=\"row mb-4 mt-1\">\r\n        <div class=\"col-sm-4 col-md-2\">\r\n            <label>Fecha Desde</label>\r\n            <input id=\"fecha_desde\" class=\"form-control fecha\"");
            BeginWriteAttribute("value", " value=\"", 975, "\"", 998, 1);
#nullable restore
#line 26 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 983, ViewBag.Fecha1, 983, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onblur", " onblur=\"", 999, "\"", 1056, 5);
            WriteAttributeValue("", 1008, "if", 1008, 2, true);
            WriteAttributeValue(" ", 1010, "(this.value==\'\')", 1011, 17, true);
            WriteAttributeValue(" ", 1027, "this.value=\'", 1028, 13, true);
#nullable restore
#line 26 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 1040, ViewBag.Fecha1, 1040, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1055, "\'", 1055, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n        </div>\r\n        <div class=\"col-sm-4 col-md-2\">\r\n            <label>Fecha Hasta</label>\r\n            <input id=\"fecha_hasta\" class=\"form-control fecha\"");
            BeginWriteAttribute("value", " value=\"", 1221, "\"", 1246, 1);
#nullable restore
#line 30 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 1229, ViewBag.FechaHoy, 1229, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onblur", " onblur=\"", 1247, "\"", 1306, 5);
            WriteAttributeValue("", 1256, "if", 1256, 2, true);
            WriteAttributeValue(" ", 1258, "(this.value==\'\')", 1259, 17, true);
            WriteAttributeValue(" ", 1275, "this.value=\'", 1276, 13, true);
#nullable restore
#line 30 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 1288, ViewBag.FechaHoy, 1288, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1305, "\'", 1305, 1, true);
            EndWriteAttribute();
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
                <div class=""card-header"">
                    <h5 class=""float-left"">
                        Listado Requisiciones de ");
#nullable restore
#line 45 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                            Write(ViewData["Title"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h5>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1932, "\"", 1971, 1);
#nullable restore
#line 47 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 1939, Url.Action("Create", "Compras"), 1939, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary float-right"">
                        <i class=""fa fa-plus""></i>
                        Nuevo
                    </a>
                </div>
                <div class=""card-body p-2 table-responsive"">
                    <table id=""GridComprasIndex"" class=""table table-hover table-striped pre-scrollable2 dataTables"">
                        <thead class=""bg-info"">
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 57 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NUMERO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 60 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.SOLICITANTE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 63 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.AREA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th style=\"width: 30%\">\r\n                                    ");
#nullable restore
#line 66 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.FECHA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 69 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.ESTADO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 72 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NRO_REQUISICION));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </th>
                                <th style=""width: 200px"" id=""titulo_act""></th>
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
#nullable restore
#line 99 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                           Write(Html.Raw(datos_json));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        activar_datos(datos.value);
        if (datos.value.error != undefined) session_finalizada();

        $("".table tbody tr"").hover(function() {
            $(this).addClass(""bg-secondary text-white"");
        }, function() {
            $(this).removeClass(""bg-secondary text-white"");
        });
    });

    function session_finalizada() {
        Swal.fire({
            title: ""Alerta"",
            text: ""La sesión ha caducado"",
            type: ""info"",
            confirmButtonText: ""Aceptar"",
        });

        setTimeout(function(){ window.location = '");
#nullable restore
#line 118 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                             Write(Url.Action("Logout", "Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'; }, 3000);
    }

    function revisar_error() {
        if ($(""#error"").val() != """") {
            Swal.fire({
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
#nullable restore
#line 141 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                 Write(Url.Action("ListadoCompras", "Compras"));

#line default
#line hidden
#nullable disable
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
        if (datos.length > 0) {
            $(""#titulo_act"")[0].innerHTML = ""Acción"";
        } else {
            $(""#titulo_act"")[0].innerHTML = """";
        }
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
           ");
            WriteLiteral(@"         ""render"": function (data, type, row) {
                        var arreglo1 = row.fecha.split(""T"");
                        var arreglo = arreglo1[0].split(""-"");
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
                        if ((row.estado == ""P"") || (row.estado == ""Pendiente"")) {
                            var cadena = '<a class=""btn btn-primary"" title = ""Consultar"" href=""");
#nullable restore
#line 190 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                                          Write(Url.Content("~/Compras/Consultar?codigo="));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + row.numero + \'\" > <i class=\"fa fa-search\"></i></a > \';\r\n                            cadena+= \'<a class=\"btn btn-info\" title=\"Editar\" href=\"");
#nullable restore
#line 191 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                              Write(Url.Content("~/Compras/Edit?codigo="));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + row.numero + '""><i class=""fa fa-edit""></i></a> ';
                            cadena+= '<a class=""btn btn-danger"" title=""Eliminar"" href=""#"" onclick=""anular_rcompra(\'' + row.numero + '\',\'' + row.nrO_REQUISICION + '\')""><i class=""fa fa-trash""></i></a> ';
                            cadena+= '<a class=""btn btn-warning"" target=""_blank"" title=""Imprimir"" href=""");
#nullable restore
#line 193 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                                                   Write(Url.Content("~/Compras/Imprimir?codigo="));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + row.numero + \'\"><i class=\"fa fa-print\"></i></a>\';\r\n                        } else {\r\n                            var cadena = \'<a class=\"btn btn-primary\" title = \"Consultar\" href=\"");
#nullable restore
#line 195 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                                          Write(Url.Content("~/Compras/Consultar?codigo="));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + row.numero + \'\" > <i class=\"fa fa-search\"></i></a > \';\r\n                            cadena+= \'<a class=\"btn btn-warning\" target=\"_blank\" title=\"Imprimir\" href=\"");
#nullable restore
#line 196 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                                                   Write(Url.Content("~/Compras/Imprimir?codigo="));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"' + row.numero + '""><i class=""fa fa-print""></i></a>';
                        }
                        return cadena;
                    }
                },
            ]
        });
    }
    
    function anular_rcompra(nrointerno,nrorequi) {
        Swal.fire({
            title: ""Eliminar"",
            text: ""Desea eliminar la Requisición Nro. "" + nrorequi,
            type: ""question"",
            showCancelButton: true,
            confirmButtonClass: ""btn-danger"",
            cancelButtonClass: ""btn-secondary"",
            confirmButtonText: ""SI"",
            cancelButtonText: ""NO"",
        }).then((result) => {
            if (result.value) {
                var parametros = ""id="" + nrointerno;

                var url = '");
#nullable restore
#line 219 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                      Write(Url.Action("Delete", "Compras", new { codigo = "Id" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n                url = url.replace(\'Id\', encodeURIComponent(nrointerno));\r\n                window.location.href = url;\r\n            }\r\n        });\r\n    }\r\n</script>\r\n");
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
