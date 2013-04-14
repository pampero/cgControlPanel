<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="" CodeBehind="Default.aspx.cs" Inherits="dateRange._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
 <script type="text/javascript">

     function SetDifference() {
         var diff = CheckDifference();
         if (diff > 0) {
             clientResult.SetText(diff.toString());
         }

     }

     function CheckDifference() {
         var startDate = new Date();
         var endDate = new Date();
         startDate = dtDateFrom.GetDate();
         if (startDate != null) {
             endDate = dtDateTo.GetDate();
             if (endDate < startDate) {
                 return false;
             }
         }
         return true;
     }
</script>
<body>
    <form id="form1" runat="server">
    <div>
    	<h1>Welcome to DevExpress ASP.NET project!</h1>
        <p>You've got an empty application that is ready for using DevExpress ASP.NET AJAX controls. You can drop here the required DevExpress controls from the Toolbox.</p>
        <div>Desde: <dx:ASPxDateEdit runat="server" ID="dtDateFrom"></dx:ASPxDateEdit></div>
        <div>Hasta: <dx:ASPxDateEdit runat="server" ID="dtDateTo">
                        <validationsettings CausesValidation="True" ErrorText="Error de Rango" />
                    <clientsideevents Validation="function(s,e){e.isValid = CheckDifference(); }"/>

                    </dx:ASPxDateEdit></div>
        <dx:ASPxButton runat="server" ID="button" AutoPostBack="False" Text="Aceptar"></dx:ASPxButton>
    </div>
    </form>
</body>
</html>