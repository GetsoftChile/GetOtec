<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GetOtec.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Twitter -->
    <meta name="twitter:site" content="@themepixels">
    <meta name="twitter:creator" content="@themepixels">
    <meta name="twitter:card" content="summary_large_image">
    <meta name="twitter:title" content="Starlight">
    <meta name="twitter:description" content="Premium Quality and Responsive UI for Dashboard.">
    <meta name="twitter:image" content="http://themepixels.me/starlight/img/starlight-social.png">

    <!-- Facebook -->
    <meta property="og:url" content="http://themepixels.me/starlight">
    <meta property="og:title" content="Starlight">
    <meta property="og:description" content="Premium Quality and Responsive UI for Dashboard.">

    <meta property="og:image" content="http://themepixels.me/starlight/img/starlight-social.png">
    <meta property="og:image:secure_url" content="http://themepixels.me/starlight/img/starlight-social.png">
    <meta property="og:image:type" content="image/png">
    <meta property="og:image:width" content="1200">
    <meta property="og:image:height" content="600">

    <!-- Meta -->
    <meta name="description" content="Premium Quality and Responsive UI for Dashboard.">
    <meta name="author" content="ThemePixels">

    <title>Ingreso - GetOTEC</title>

    <!-- vendor css -->
    <link href="Assets/template/lib/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="Assets/template/lib/Ionicons/css/ionicons.css" rel="stylesheet" />


    <!-- Starlight CSS -->
    <link rel="stylesheet" href="Assets/template/css/starlight.css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

</head>
<body>
    <div class="d-flex align-items-center justify-content-center bg-sl-primary ht-100v">
        <form id="form1" runat="server">
            <div class="login-wrapper wd-300 wd-xs-350 pd-25 pd-xs-40 bg-white">
                <div class="signin-logo tx-center tx-24 tx-bold tx-inverse">GetOTEC <span class="tx-info tx-normal">Admin</span></div>
                <div class="tx-center mg-b-30">Innovación y Gestión de Procesos OTEC</div>

                <div class="form-group">
                    <input id="TxtUsuario" runat="server" type="text" class="form-control" placeholder="Ingrese su Usuario" required="required">
                </div>
                <!-- form-group -->
                <div class="form-group">
                    <input id="TxtPassword" runat="server" type="password" class="form-control" placeholder="Ingrese su password" required="required">
                    <%--<a href="" class="tx-info tx-12 d-block mg-t-10">Forgot password?</a>--%>
                </div>
                <!-- form-group -->
                
                <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" CssClass="btn btn-info btn-block" />

                <div class="mg-t-60 tx-center">No tienes cuenta? <a href="page-signup.html" class="tx-info">Registrate</a></div>
            </div>
            <!-- login-wrapper -->
        </form>

    </div>
    <!-- d-flex -->

    <script src="Assets/template/lib/jquery/jquery.js"></script>
    <script src="Assets/template/lib/popper.js/popper.js"></script>
    <script src="Assets/template/lib/bootstrap/bootstrap.js"></script>

</body>
</html>
