<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManualJobInputDialog.aspx.cs" Inherits="CGControlPanel.Dialogs.ManualJobInputDialog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">

    function ReturnToParentPage() {
        var parentWindow = window.parent;
        parentWindow.RefreshGrdDailyJobs();
        window.close();
    }
    
    function CheckDifference(dateFrom, dateTo) {
        var startDate = new Date();
        var endDate = new Date();
        startDate = dateFrom.GetDate();
        if (startDate != null) {
            endDate = dateTo.GetDate();
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
    
    <asp:Table runat="server" CellSpacing="3" ID="tblControls" Width="100%" BorderWidth="0px">
        <asp:TableRow>
            <asp:TableHeaderCell Width="30%"></asp:TableHeaderCell>
            <asp:TableHeaderCell Width="80%"></asp:TableHeaderCell>
        </asp:TableRow>
    </asp:Table>
    <input type="button" onclick="ReturnToParentPage()" value="OK" />
    </div>
    </form>
</body>
</html>
