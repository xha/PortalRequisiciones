#pragma checksum "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e16ca5a9780b9260bc939b70727376b596d7a47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Servicios_Edit), @"mvc.1.0.view", @"/Views/Servicios/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Servicios/Edit.cshtml", typeof(AspNetCore.Views_Servicios_Edit))]
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
#line 1 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\_ViewImports.cshtml"
using Inicio;

#line default
#line hidden
#line 2 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\_ViewImports.cshtml"
using Inicio.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e16ca5a9780b9260bc939b70727376b596d7a47", @"/Views/Servicios/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58b65c8bb7fcba6c4c21c5e584c0edacef356624", @"/Views/_ViewImports.cshtml")]
    public class Views_Servicios_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Datos.Models.REQUISC_PORTAL>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "RS", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
  
    ViewData["Title"] = "Ediar Requisición de Servicios No.";

#line default
#line hidden
            BeginContext(108, 118, true);
            WriteLiteral("\r\n<hr />\r\n<div class=\"card card-danger\">\r\n    <div class=\"card-header\">\r\n        <h5 class=\"float-left\">\r\n            ");
            EndContext();
            BeginContext(227, 17, false);
#line 11 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
       Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(244, 4, true);
            WriteLiteral(" <b>");
            EndContext();
            BeginContext(249, 14, false);
#line 11 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
                             Write(Model.NROREQUI);

#line default
#line hidden
            EndContext();
            BeginContext(263, 74, true);
            WriteLiteral("</b>\r\n        </h5>\r\n    </div>\r\n    <div class=\"card-body p-2\">\r\n        ");
            EndContext();
            BeginContext(337, 1025, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e16ca5a9780b9260bc939b70727376b596d7a476990", async() => {
                BeginContext(361, 49, true);
                WriteLiteral("\r\n            <div class=\"row\">\r\n                ");
                EndContext();
                BeginContext(410, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7e16ca5a9780b9260bc939b70727376b596d7a477423", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 17 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TipoDocumento);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(487, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(505, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7e16ca5a9780b9260bc939b70727376b596d7a479560", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 18 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TIPOREQUI);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(580, 87, true);
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"detalle\" id=\"detalle\" />\r\n                ");
                EndContext();
                BeginContext(668, 27, false);
#line 20 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
           Write(Html.Partial(nameof(Datos)));

#line default
#line hidden
                EndContext();
                BeginContext(695, 660, true);
                WriteLiteral(@"
            </div>
            <div class=""row my-1"">
                <div class=""col-sm-12 text-right"">
                    <div class=""form-group"">
                        <button type=""reset"" class=""btn btn-danger"">
                            <i class=""fa fa-times""></i>
                            Cancelar
                        </button>
                        <button type=""submit"" class=""btn btn-success"" onclick=""enviar_datos()"">
                            <i class=""fa fa-save""></i>
                            Grabar
                        </button>
                    </div>
                </div>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1362, 48, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"my-2\">\r\n    ");
            EndContext();
            BeginContext(1410, 118, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e16ca5a9780b9260bc939b70727376b596d7a4714138", async() => {
                BeginContext(1458, 66, true);
                WriteLiteral("\r\n        <i class=\"fa fa-arrow-left\"></i>\r\n        Regresar\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1528, 1544, true);
            WriteLiteral(@"
</div>
<script>
    $(document).on(""keydown"", "":input:not(textarea)"", function (event) {
        if (event.key == ""Enter"") {
            event.preventDefault();
            return false;
        }

        if ($(""#error"").val() != """") {
            swal({
                title: ""Error"",
                text: $(""#error"").val(),
                type: ""danger"",
                confirmButtonText: ""Aceptar"",
            })
        }
    });

    function enviar_datos() {
        var details = [];

        $(""#tabla_articulo tr"").each(function (index) {
            var td = $(this).children(""td"");
            if (td.eq(0).text() != """") {
                details.push({
                    codigo: td.eq(1).text(),
                    descripcion: td.eq(2).text(),
                    unidad: td.eq(3).text(),
                    cantidad: td.eq(4).text(),
                    fecha_req: td.eq(5).text(),
                    centro_costo: td.eq(6).text(),
                    nro_maquina: t");
            WriteLiteral(@"d.eq(7).text(),
                    orden_fabricacion: td.eq(8).text(),
                    glosa_articulo: td.eq(9).text(),
                });
            }
            $(""#detalle"").val(JSON.stringify(details));
        });

        if (($(""#detalle"").val() != """") && ($(""#NROREQUI"").val() != """")) {
            $(""#TipoDocumento"").val(""RS"");
            document.forms[0].submit();
        } else {
            MostrarMensaje(""Rojo"", ""Los campos con * son obligatorios"");
        }

    }
</script>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3090, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 94 "C:\Users\Xha\source\repos\PortalRequisiciones\Inicio\Views\Servicios\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Datos.Models.REQUISC_PORTAL> Html { get; private set; }
    }
}
#pragma warning restore 1591
