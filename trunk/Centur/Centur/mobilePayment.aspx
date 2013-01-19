<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mobilePayment.aspx.vb" Inherits="Centur.mobilePayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="ltlMercadoPago" runat="server"></asp:Literal>
    </div>
    </form>

    <!-- Pega este código antes de cerrar la etiqueta </body> -->
    <script type="text/javascript">
        (function () {
            function $MPBR_load() {
                window.$MPBR_loaded !== true && (function () {
                    var s = document.createElement("script"); s.type = "text/javascript"; s.async = true;
                    s.src = ("https:" == document.location.protocol ? "https://www.mercadopago.com/org-img/jsapi/mptools/buttons/" : "http://mp-tools.mlstatic.com/buttons/") + "render.js";
                    var x = document.getElementsByTagName('script')[0]; x.parentNode.insertBefore(s, x); window.$MPBR_loaded = true;
                })();
            }
            window.$MPBR_loaded !== true ? (window.attachEvent ? window.attachEvent('onload', $MPBR_load) : window.addEventListener('load', $MPBR_load, false)) : null;
        })();
    </script>
</body>
</html>
