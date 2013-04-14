<%@ Page Title="Log In" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CGControlPanel.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login | CG Control Panel</title>
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/custom/general.js"></script>
    <script type="text/javascript" src="../js/custom/index.js"></script>
    <!--[if IE 9]>
    <link rel="stylesheet" media="screen" href="css/style.ie9.css"/>
<![endif]-->
    <!--[if IE 8]>
    <link rel="stylesheet" media="screen" href="css/style.ie8.css"/>
<![endif]-->
    <!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
<![endif]-->
</head>

<body class="loginpage">
    <div class="loginbox">
        <div class="loginboxinner">

            <div class="logo">
                <h1>CG.<span>ControlPanel</span></h1>
                <p>Todos los procesos. Un solo lugar</p>
            </div>
            <!--logo-->

            <br clear="all" />
            <br />


            <form id="login" runat="server">
            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
                <LayoutTemplate>

                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>

                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                        ValidationGroup="LoginUserValidationGroup" />

                    <div class="accountInfo">
                        <fieldset class="login">
                            <%--<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario:</asp:Label>--%>
                            <div class="username">
                                <asp:TextBox ID="UserName" runat="server" CssClass="usernameinner"></asp:TextBox>
                            </div>
                            
                            <div class="nousername">
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    CssClass="loginmsg" ErrorMessage="User Name is required." ToolTip="Usuario requerido."
                                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>

                            <%--<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Clave:</asp:Label>--%>
                            <div class="password">
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordinner" TextMode="Password"></asp:TextBox>
                            </div>
                           
                            <div class="nopassword">
                             <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                CssClass="loginmsg" ErrorMessage="Password is required." ToolTip="Clave requerida."
                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </div>

                        </fieldset>
                        
                            <asp:Button  ID="LoginButton" runat="server" CommandName="Login" Text="INGRESAR" ValidationGroup="LoginUserValidationGroup" />
                        
                        <div class="keep">
                        <asp:CheckBox ID="RememberMe" runat="server" />
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Permanecer logueado</asp:Label>
                          </div>
                    </div>
                </LayoutTemplate>
            </asp:Login>
            </form>
        </div>
    </div>
</body>
</html>
