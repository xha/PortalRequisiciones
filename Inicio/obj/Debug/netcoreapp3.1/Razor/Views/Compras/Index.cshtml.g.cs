#pragma checksum "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ceece3b3c77efeb539e71d317acc836505b46712"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ceece3b3c77efeb539e71d317acc836505b46712", @"/Views/Compras/Index.cshtml")]
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
  
    ViewData["Title"] = "Requisiciones de Compras";
    var datos_json = Json.Serialize(ViewBag.ListadoCompras);

#line default
#line hidden
            BeginContext(166, 190, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row mt-1\">\r\n        <div class=\"col-sm-12\">\r\n            <ol class=\"breadcrumb float-sm-right\">\r\n                <li class=\"breadcrumb-item\">");
            EndContext();
            BeginContext(357, 65, false);
#line 12 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                       Write(Html.ActionLink(ViewData["Title"].ToString(), "Index", "Compras"));

#line default
#line hidden
            EndContext();
            BeginContext(422, 370, true);
            WriteLiteral(@"</li>
            </ol>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""card card-danger card-outline"">
                <div class=""card-header mb-1"">
                    <h5 class=""float-left"">
                        Listado de Requisiciones de Compras
                    </h5>
                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 792, "\"", 831, 1);
#line 23 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
WriteAttributeValue("", 799, Url.Action("Create", "Compras"), 799, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(832, 493, true);
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
            BeginContext(1326, 42, false);
#line 33 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.NUMERO));

#line default
#line hidden
            EndContext();
            BeginContext(1368, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1484, 47, false);
#line 36 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.SOLICITANTE));

#line default
#line hidden
            EndContext();
            BeginContext(1531, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1647, 40, false);
#line 39 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.AREA));

#line default
#line hidden
            EndContext();
            BeginContext(1687, 134, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th style=\"width: 30%\">\r\n                                    ");
            EndContext();
            BeginContext(1822, 41, false);
#line 42 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.FECHA));

#line default
#line hidden
            EndContext();
            BeginContext(1863, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1979, 42, false);
#line 45 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.ESTADO));

#line default
#line hidden
            EndContext();
            BeginContext(2021, 799, true);
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
        /*$.ajax({
            type: 'POST',
            url: 'Url.Action(""ListadoCompras"", ""Compras"")',
            data: '',
            cache: false,
            success: function (result) {
                datos_json = result;
                console.log(result);
                //activar_datos();
            },
        });*/
        var datos = JSON.parse('");
            EndContext();
            BeginContext(2821, 20, false);
#line 71 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                           Write(Html.Raw(datos_json));

#line default
#line hidden
            EndContext();
            BeginContext(2841, 1117, true);
            WriteLiteral(@"');
        activar_datos(datos.value);
    });

    function activar_datos(datos) {
        $(""#GridComprasIndex"").DataTable({
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
                        var myDate = arreglo[2] + ""/"" + arreglo[1] + ""/"" + arreglo[0];

                        return myDate;
                    }
                },
                { data: ""estado"" },
                {
                    render: function (data, type, row)
                ");
            WriteLiteral("    {\r\n                        return \'<a class=\"btn btn-info grid_opt\" title=\"Editar\" href=\"");
            EndContext();
            BeginContext(3959, 37, false);
#line 99 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                                                                 Write(Url.Content("~/Compras/Edit?codigo="));

#line default
#line hidden
            EndContext();
            BeginContext(3996, 1105, true);
            WriteLiteral(@"'+row.numero+'""><i class=""fa fa-edit""></i></a>';
                    }
                },
                {
                    data: null, render: function (data, type, row) {
                        return '<a class=""btn btn-danger"" title=""Anular"" href=""#"" onclick=""anular_rcompra(\'' + row.numero + '\')""><i class=""fa fa-trash""></i></a>';
                    }
                },
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
            cancelButtonText: ""Cancelar"",
        },
        function (isConfirm) {
            if (isConfirm) {
                var parametros = ""id="" + nrorequi;
                $.ajax(
                {
                   ");
            WriteLiteral(" type: \"POST\",\r\n                    dataType: \"json\",\r\n                    url: \"");
            EndContext();
            BeginContext(5102, 31, false);
#line 129 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                     Write(Url.Content("~/Compras/Delete"));

#line default
#line hidden
            EndContext();
            BeginContext(5133, 222, true);
            WriteLiteral("\",\r\n                    data: parametros,\r\n                    cache: false,\r\n                    success: function (datos) {\r\n                        if (datos.resultado) {\r\n                            window.location = \'");
            EndContext();
            BeginContext(5356, 25, false);
#line 134 "X:\web\PortalRequisiciones\Inicio\Views\Compras\Index.cshtml"
                                          Write(Url.Content("~/Compras/"));

#line default
#line hidden
            EndContext();
            BeginContext(5381, 734, true);
            WriteLiteral(@"';
                        } else {
                            swal({
                                title: ""Error"",
                                text: datos.error,
                                type: ""error"",
                                confirmButtonClass: ""btn-danger"",
                            });
                        };
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
