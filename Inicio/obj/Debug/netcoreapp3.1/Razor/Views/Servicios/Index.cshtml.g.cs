#pragma checksum "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f0d81ae50edaec02038a020940959454af0d3a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Servicios_Index), @"mvc.1.0.view", @"/Views/Servicios/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f0d81ae50edaec02038a020940959454af0d3a9", @"/Views/Servicios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b65c8bb7fcba6c4c21c5e584c0edacef356624", @"/Views/_ViewImports.cshtml")]
    public class Views_Servicios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Datos.Models.REQUISC_PORTALModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
  
    ViewData["Title"] = "Requisiciones de Servicios";
    var datos_json = Json.Serialize(ViewBag.ListadoServicios);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row mt-1\">\r\n        <div class=\"col-sm-12\">\r\n            <ol class=\"breadcrumb float-sm-right\">\r\n                <li class=\"breadcrumb-item\">");
#nullable restore
#line 12 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                                       Write(Html.ActionLink(ViewData["Title"].ToString(), "Index", "Servicios"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
            </ol>
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
            BeginWriteAttribute("href", " href=\"", 812, "\"", 853, 1);
#nullable restore
#line 23 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
WriteAttributeValue("", 819, Url.Action("Create", "Servicios"), 819, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
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
#nullable restore
#line 33 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NROREQUI));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 36 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.CODSOLIC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 39 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.FECREQUI));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th style=\"width: 30%\">\r\n                                    ");
#nullable restore
#line 42 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.GLOSA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 45 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.AREA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 48 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.TIPOREQUI));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </th>
                                <th>
                                    Estatus
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
        /*$.ajax({
            type: 'POST',
            url: 'Url.Action(""ListadoServicios"", ""Servicios"")',
            data: '',
            cache: false,
            success: function (result) {
                datos_json = result;
                console.log(result);
                //activar_datos();
            },
        });*/
        var datos = JSON.parse('");
#nullable restore
#line 77 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                           Write(Html.Raw(datos_json));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        activar_datos(datos.value);
    });

    function activar_datos(datos) {
        $(""#GridServiciosIndex"").DataTable({
            destroy: true,
            bInfo: false,
            data: datos,
            columns: [
                { data: ""nrorequi"" },
                { data: ""codsolic"" },
                {
                    ""render"": function (data, type, row) {
                        var arreglo1 = row.fecrequi.split(""T"");
                        var arreglo = arreglo1[0].split(""-"");
                        if (arreglo[2].length < 2) arreglo[2] = ""0"" + arreglo[2];
                        if (arreglo[1].length < 2) arreglo[1] = ""0"" + arreglo[1];
                        var myDate = arreglo[2] + ""/"" + arreglo[1] + ""/"" + arreglo[0];

                        return myDate;
                    }
                },
                { data: ""glosa"" },
                { data: ""area"" },
                { data: ""tiporequi"" },
                { data: ""tipoDocumento"" },
    ");
            WriteLiteral("            {\r\n                    render: function (data, type, row)\r\n                    {\r\n                        return \'<a class=\"btn btn-info grid_opt\" title=\"Editar\" href=\"");
#nullable restore
#line 107 "X:\web\PortalRequisiciones\Inicio\Views\Servicios\Index.cshtml"
                                                                                 Write(Url.Content("~/Servicios/Edit?codigo="));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'+row.nrorequi+'""><i class=""fa fa-edit""></i></a>';
                    }
                },
                {
                    data: null, render: function (data, type, row) {
                        return '<a class=""btn btn-danger"" title=""Anular"" href=""#"" onclick=""anular_rcompra(\'' + row.nrorequi + '\')""><i class=""fa fa-trash""></i></a>';
                    }
                },
            ]
        });
    }

    function anular_rcompra(nrorequi) {
        swal({
            title: ""¿Estás seguro?"",
            text: ""Confirmar Anulado del registro: "" + nrorequi,
            type: ""warning"",
            showCancelButton: true,
            confirmButtonClass: ""btn-danger"",
            cancelButtonClass: ""btn-secondary"",
            confirmButtonText: ""Aceptar"",
            cancelButtonText: ""Cancelar"",
        },
        function (isConfirm) {
            if (isConfirm) {
                console.log(nrorequi);
                /*$.ajax(
                {
                    ty");
            WriteLiteral(@"pe: ""POST"",
                    dataType: ""json"",
                    url: ""Url.Content(""~/Servicios/Edit?codigo="")""+row.nrorequi,
                    data: parametros,
                    cache: false,
                    success: function (Resultado) {
                        loading_hide();
                        window.parent.MostrarMensaje(Resultado.color, Resultado.data);
                        if (Resultado.respuesta) {
                            $('#ProveedorIndexGrid').DataTable().ajax.reload();
                        }

                    },
                    error: function (xhr) { // if error occured
                        loading_hide();
                        console.log(xhr);
                        window.parent.MostrarMensaje(""Rojo"", xhr.responseText);
                        //$(placeholder).append(xhr.statusText + xhr.responseText);
                    },
                });*/
            }
        });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Datos.Models.REQUISC_PORTALModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
