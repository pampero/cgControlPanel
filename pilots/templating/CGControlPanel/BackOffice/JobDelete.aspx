<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="JobDelete.aspx.cs" Inherits="CGControlPanel.JobDelete" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript">

    function OnCallbackComplete(s, e) {

        var loadingPanel = document.getElementById("lp");
        loadingPanel.style.display = "none";

        if (e.result == "DELETEOK") {
            alert("Eliminado Correctamente");
            window.location.href = "/BackOffice/Jobs.aspx";
        }
        if (e.result == "DELETENOOK") {
            alert("No se eliminó el proceso. Existen agendamientos pendientes de Ejecución");
        }
        btnDelete.SetEnabled(true);
    }

    function OnCallbackError(s, e) {
        var loadingPanel = document.getElementById("lp");
        loadingPanel.style.display = "none";
        btnDelete.SetEnabled(true);
    };


    function OnClick() {

        var loadingPanel = document.getElementById("lp");
        loadingPanel.style.display = "";

        aspxCallBack.PerformCallback('DELETE');
        
        btnDelete.SetEnabled(false);
    }

</script>
    <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"  OnCallback="aspxCallback_Callback">
        <ClientSideEvents CallbackComplete="OnCallbackComplete" CallbackError="OnCallbackError"></ClientSideEvents>
    </dxc:ASPxCallback>
    
      <div id="contentwrapper" class="contentwrapper">
        	
        	<div id="basicform" class="subcontent">
       
            <div class="contenttitle2">
                        <h3>Seguro que desea eliminar el proceso?</h3>
                    </div>

            
                    	<p>
                        	<label>Grupo</label>
                            <dxe:ASPxTextBox runat="server" ID="txtGroup" MaxLength="50" Width="50%" />
                        </p>
                        
                         <p>
                            <label>Nombre</label>
                            <dxe:ASPxTextBox runat="server" ID="txtName" MaxLength="50" Width="50%" />
                        </p>
                        
                        <p>
                            <label>Descripcion</label>
                            <dxe:ASPxMemo runat="server" ID="txtDescription" Rows="5" Width="50%"/>
                        </p>
                        <p>
                            <label>Tipo de Agendamiento</label>
                            <dxe:ASPxComboBox ID="cmbJobType" runat="server" SelectedIndex="0" Width="25%">
                                <Items>
                                    <dxe:ListEditItem Value="1" Text="Automático" />
                                    <dxe:ListEditItem Value="2" Text="Manual" />
                                </Items>
                            </dxe:ASPxComboBox>
                    </p>

                    <dxe:ASPxCheckBox runat="server" ID="chkFavorite" Text="Es Favorito?" />
  
                    <dxe:ASPxCheckBox runat="server" ID="chkDaily" Text="Es Diario?" />

                    <p>
                        <label>Proceso de Configuración Dinámico</label>
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaProcedure" Width="40%" />
                    
                    </p>
                    <p>
                        <label>Datos Fijos</label>
                        <dxe:ASPxMemo runat="server" ID="txtFixedParametersProcedure" Rows="5" Width="40%" />
                    </p>
                    <p>
                        <label>Servidor</label>
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaServerName" Width="40%" />
                    </p>
                    <p>
                        <label>Base de Datos</label>
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaDataBaseName" Width="40%" />
                    </p>
                    <p>
                        <label>Usuario</label>
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaUserName" Width="40%" />
                    </p>
                    <p>
                         <label>Password</label>
                         <dxe:ASPxTextBox runat="server" Password="True" ID="txtInputSchemaPassword" Width="40%" />
                    </p>
                    <p>
                        <label>Procedimiento a Ejecutar</label>
                        <dxe:ASPxTextBox runat="server" Password="True" ID="txtExecProcedure" Width="40%"/>
                    </p>              
                    
             <p>
                    Triggers Pendientes de Ejecución

                    <dxg:ASPxGridView  runat="server"  ID="grdJobTriggers" KeyFieldName="JobTriggerId"  ClientInstanceName="grdJobTriggers" Width="80%" >
                        <Columns>
                            <dxg:GridViewDataColumn Width="30px" FieldName="JobTriggerId" Caption="ID Log" VisibleIndex="1" />
                            <dxg:GridViewDataColumn FieldName="StartExecutionDate" Caption="Fecha Ejecución" VisibleIndex="2" />
                            <dxg:GridViewDataColumn FieldName="XmlFormInputValues" Caption="Valores de Entrada" VisibleIndex="3" />
                            <dxg:GridViewDataColumn FieldName="CreatedBy" Caption="Creado Por" VisibleIndex="4" />
                        </Columns>
                        <SettingsBehavior AllowSort="False"></SettingsBehavior>
                    </dxg:ASPxGridView>
              </p>
              
              <asp:Label runat="server" ID="lblCanDelete" ForeColor="red"></asp:Label>
               <p>
                    <div id="lp" class="loadingPanel" style="display: none;">
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="float: left" />
                        <div class="loadingTxt">
                            Procesando&hellip;</div>
                        <b class="clear"></b>
                    </div>
                    <dxe:ASPxButton style="float:right;" runat="server" ID="btnCancel" PostBackUrl="/BackOffice/Jobs.aspx" Text="Volver"   ></dxe:ASPxButton>
                    <dxe:ASPxButton style="float:right; padding-right: 10px;" runat="server" AutoPostBack="false" CausesValidation="false" ID="btnDelete"  ClientInstanceName="btnDelete" Text="Eliminar" >
                    <ClientSideEvents Click="OnClick" />
                    </dxe:ASPxButton>
               </p>

                <asp:HiddenField runat="server" ID="hdnJobId"/>
            </div><!--subcontent-->
       
        </div><!--contentwrapper-->

</asp:Content>
