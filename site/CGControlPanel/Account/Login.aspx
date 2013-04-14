<%@ Page Title="Log In" Language="C#"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CGControlPanel.Account.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>CG.ControlPanel</title>
    <link rel="stylesheet" href="../css/style.default.css" type="text/css" />
    <script type="text/javascript" src="../js/plugins/jquery-1.7.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.cookie.js"></script>
    <script type="text/javascript" src="../js/plugins/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/custom/general.js"></script>
    <script type="text/javascript" src="../js/custom/index.js"></script>
    <!--[if IE 9]>
    <link rel="stylesheet" media="screen" href="../css/style.ie9.css"/>
<![endif]-->
<!--[if IE 8]>
    <link rel="stylesheet" media="screen" href="../css/style.ie8.css"/>
<![endif]-->
<!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
<![endif]-->
</head>
<body class="loginpage">
    
	<div class="loginbox">
    	<div class="loginboxinner">
        	
            <div class="logo">
            	<h1><span>CG.</span>ControlPanel</h1>
                <p>Todos los procesos. Un solo lugar</p>
            </div><!--logo-->
            
            <br clear="all" />
            
            <div class="nousername">
				<div class="loginmsg">Por favor ingrese el usuario.</div>
            </div><!--nousername-->
            
            <div class="nopassword">
				<div class="loginmsg">Por favor ingrese la clave.</div>
            </div><!--nopassword-->
            
            <form id="login" method="post" runat="server">
            	
                <div class="username">
                	<div class="usernameinner">
                    	<input type="text" name="username" id="username" runat="server" />
                    </div>
                </div>
                
                <div class="password">
                	<div class="passwordinner">
                    	<input type="password" name="password" id="password" runat="server"/>
                    </div>
                </div>
                
                <button>Iniciar Sesión</button>
                
                <div class="keep"><input id="RememberMe" runat="server" type="checkbox" /><label for="RememberMe">Mantener la sesión iniciada</label></div>
            
            </form>
            
        </div><!--loginboxinner-->
    </div><!--loginbox-->
</body>


</html>