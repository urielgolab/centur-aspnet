<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="MisGrupos.aspx.vb" Inherits="Centur.MisGrupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $ID("ButtonVerDetalle").button();
            $ID("ButtonCrearGrupo").button();
            $ID("ButtonSolPendientes").button();
            $ID("ButtonVerDetalleAd").button();
        });

        (function ($) {
            $.widget("ui.combobox", {
                _create: function () {
                    var input,
					self = this,
					select = this.element.hide(),
					selected = select.children(":selected"),
					value = selected.val() ? selected.text() : "",
					wrapper = this.wrapper = $("<span>")
						.addClass("ui-combobox")
						.insertAfter(select);

                    input = $("<input>")
					.appendTo(wrapper)
					.val(value)
					.addClass("ui-state-default ui-combobox-input")
					.autocomplete({
					    delay: 0,
					    minLength: 0,
					    source: function (request, response) {
					        var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
					        response(select.children("option").map(function () {
					            var text = $(this).text();
					            if (this.value && (!request.term || matcher.test(text)))
					                return {
					                    label: text.replace(
											new RegExp(
												"(?![^&;]+;)(?!<[^<>]*)(" +
												$.ui.autocomplete.escapeRegex(request.term) +
												")(?![^<>]*>)(?![^&;]+;)", "gi"
											), "<strong>$1</strong>"),
					                    value: text,
					                    option: this
					                };
					        }));
					    },
					    select: function (event, ui) {
					        ui.item.option.selected = true;
					        self._trigger("selected", event, {
					            item: ui.item.option
					        });
					    },
					    change: function (event, ui) {
					        if (!ui.item) {
					            var matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex($(this).val()) + "$", "i"),
									valid = false;
					            select.children("option").each(function () {
					                if ($(this).text().match(matcher)) {
					                    this.selected = valid = true;
					                    return false;
					                }
					            });
					            if (!valid) {
					                // remove invalid value, as it didn't match anything
					                $(this).val("");
					                select.val("");
					                input.data("autocomplete").term = "";
					                return false;
					            }
					        }
					    }
					})
					.addClass("ui-widget ui-widget-content ui-corner-left");

                    input.data("autocomplete")._renderItem = function (ul, item) {
                        return $("<li></li>")
						.data("item.autocomplete", item)
						.append("<a>" + item.label + "</a>")
						.appendTo(ul);
                    };

                    $("<a>")
					.attr("tabIndex", -1)
					.appendTo(wrapper)
					.button({
					    icons: {
					        primary: "ui-icon-triangle-1-s"
					    },
					    text: false
					})
					.removeClass("ui-corner-all")
					.addClass("ui-corner-right ui-combobox-toggle")
					.click(function () {
					    // close if already visible
					    if (input.autocomplete("widget").is(":visible")) {
					        input.autocomplete("close");
					        return;
					    }

					    // work around a bug (likely same cause as #5265)
					    $(this).blur();

					    // pass empty string as value to search for, displaying all results
					    input.autocomplete("search", "");
					    input.focus();
					});
                },

                destroy: function () {
                    this.wrapper.remove();
                    this.element.show();
                    $.Widget.prototype.destroy.call(this);
                }
            });
        })(jQuery);


        $(function () {
            $ID("DropDownListGruposPropios").combobox();
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p align="left" class="tituloPrincipal" > Mis grupos</p>
<div id="propios" Runat="Server">
<p class="busqueda">Grupos Propios</p>
    <div><asp:Label ID="Label1" runat="server" Text="Seleccionar grupo: "></asp:Label>
        <asp:DropDownList ID="DropDownListGruposPropios" cssclass="GruposCombo" runat="server" DataTextField="Nombre" DataValueField="ID">
            <asp:ListItem Value="none">No posee grupos</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonVerDetalle" cssclass="ButtonDerechoVerDetalle" runat="server" Text="Ver Detalle..."></asp:Button>
        <br />
    </div>
    
        <div class="DivGruposLinks">
        <asp:Button ID="ButtonCrearGrupo" runat="server" PostBackUrl="~/CrearGrupo.aspx" Text="Crear grupo"></asp:Button>
        <asp:Button ID="ButtonSolPendientes" CssClass="ButtonDerecho" runat="server" Text="Solicitudes pendientes"></asp:Button>
        </div>
    </div>

<br />
<div id="adheridos" class="GruposAdheridos">
<p class="busqueda">Grupos Adheridos</p>
    <div><asp:Label ID="Label2" runat="server" Text="Seleccionar grupo: "></asp:Label>
        <asp:DropDownList ID="DropDownListGruposAdheridos" cssclass="GruposCombo" runat="server">
            <asp:ListItem Value="none">No tiene grupos adheridos</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="ButtonVerDetalleAd" CssClass="ButtonDerecho" runat="server" Text="Ver Detalle..."></asp:Button>
    </div>

</div>


</asp:Content>

