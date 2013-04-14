<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="JobAM.aspx.cs" Inherits="CGControlPanel.JobAM" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="centercontent">
        
        <script type="text/javascript">

            function OnCallbackComplete(s, e) {
                
                var loadingPanel = document.getElementById("lp");
                loadingPanel.style.display = "none";

                if (e.result == "UPDATEDOK") {
                    var divSuccess = document.getElementById("divSuccess");
                    divSuccess.style.display = "block";
                }
                if (e.result == "NEWOK") {
                    window.location.href = "/BackOffice/Jobs.aspx";
                    alert("Creado Correctamente");
                }

                document.getElementById("btnAccept").disabled = false;
            }

            function OnCallbackError(s, e) {
                var loadingPanel = document.getElementById("lp");
                loadingPanel.style.display = "none";

                document.getElementById("btnAccept").disabled = false;
            };

            function OnClick() {
                var isFormValid = ASPxClientEdit.ValidateGroup("Accept");
                if (isFormValid) {
                    var loadingPanel = document.getElementById("lp");
                    loadingPanel.style.display = "";

                    document.getElementById("btnAccept").disabled = true;

                    aspxCallBack.PerformCallback('NEW');
                }
                return false;
            }
        </script>
        
        <div class="pageheader notab">
            <h1 class="pagetitle">Modificación de Proceso</h1>
            <span class="pagedesc">Configure los datos del proceso</span>      
        </div><!--pageheader-->
        
        <div id="Div1" class="contentwrapper">
        	 <div class="notibar msginfo" style="display:none">
                        <a class="close"></a>
                        <p>This is an information message.</p>
                    </div><!-- notification msginfo -->
                    
                    <div id="divSuccess" class="notibar msgsuccess" style="display:none">
                        <a class="close"></a>
                        <p>Proceso modificado correctamente.</p>
                    </div><!-- notification msgsuccess -->
                    
                    <div class="notibar msgalert" style="display:none">
                        <a class="close"></a>
                        <p>No se modificó el procesos ya que tiene ejecuciones agendadas.</p>
                    </div><!-- notification msgalert -->
                    
                    <div class="notibar msgerror" style="display:none">
                        <a class="close"></a>
                        <p>This is an error message.</p>
            </div><!-- notification msgerror -->
            </div>
        <form id="Form1" class="stdform stdform2" runat="server">
        <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
            OnCallback="aspxCallback_Callback">
            <ClientSideEvents CallbackComplete="OnCallbackComplete" CallbackError="OnCallbackError">
            </ClientSideEvents>
        </dxc:ASPxCallback>
        <div id="contentwrapper" class="contentwrapper">
            <div id="basicform" class="subcontent">
                <div class="par">
                    <label>
                        Grupo</label>
                    <div class="field longinput">
                        <dxe:ASPxTextBox runat="server" ID="txtGroup" MaxLength="50">
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                                <RequiredField IsRequired="True" ErrorText="Requerido" />
                            </ValidationSettings>
                        </dxe:ASPxTextBox>
                    </div>
                </div>
                <div class="par">
                    <label>
                        Nombre</label>
                    <div class="field mediuminput">
                        <dxe:ASPxTextBox runat="server" ID="txtName" MaxLength="50">
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                                <RequiredField IsRequired="True" ErrorText="Requerido" />
                            </ValidationSettings>
                        </dxe:ASPxTextBox>
                    </div>
                </div>
                <div class="par">
                    <label>
                        Descripcion</label>
                    <div class="field smallinput">
                        <dxe:ASPxMemo runat="server" ID="txtDescription" Rows="5" MaxLength="200" />
                    </div>
                </div>
                <div class="par">
                    <label>
                        Tipo de Agendamiento</label>
                    <div class="field">
                        <dxe:ASPxComboBox ID="cmbJobType" CssClass="combobox" runat="server" SelectedIndex="0">
                            <Items>
                                <dxe:ListEditItem Value="1" Text="Automático" />
                                <dxe:ListEditItem Value="2" Text="Manual" />
                            </Items>
                        </dxe:ASPxComboBox>
                    </div>
                </div>
                <div class="par">
                    <label>Es Favorito?</label>
                    <div class="field">
                        <dxe:ASPxCheckBox runat="server" ID="chkFavorite"  />
                    </div>
                </div>
                <div class="par">
                    <label>Es Diario?</label>
                    <div class="field">
                        <dxe:ASPxCheckBox runat="server" ID="chkDaily" />
                    </div>
                </div>
                <div class="par">
                    <label>
                        Proceso de Configuración Dinámico</label>
                    <div class="field">
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaProcedure" MaxLength="50" />
                    </div>
                </div>
                <div class="par">
                    <label>
                        Datos Fijos</label>
                    <div class="field">
                        <dxe:ASPxMemo runat="server" ID="txtFixedParametersProcedure" Rows="5" />
                    </div>
                </div>
                <div class="par">
                    <label>
                        Servidor</label>
                    <div class="field">
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaServerName" MaxLength="40">
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                                <RequiredField IsRequired="True" ErrorText="Requerido" />
                            </ValidationSettings>
                        </dxe:ASPxTextBox>
                    </div>
                </div>
                <div class="par">
                    <label>
                        Base de Datos</label>
                    <div class="field">
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaDataBaseName" MaxLength="40">
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                                <RequiredField IsRequired="True" ErrorText="Requerido" />
                            </ValidationSettings>
                        </dxe:ASPxTextBox>
                    </div>
                </div>
                <div class="par">
                    <label>
                        Usuario</label>
                    <div class="field">
                        <dxe:ASPxTextBox runat="server" ID="txtInputSchemaUserName" MaxLength="15">
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                                <RequiredField IsRequired="True" ErrorText="Requerido" />
                            </ValidationSettings>
                        </dxe:ASPxTextBox>
                    </div>
                </div>
                <div class="par">
                    <label>
                        Password</label>
                    <div class="field">
                        <dxe:ASPxTextBox runat="server" Password="True" ID="txtInputSchemaPassword" MaxLength="15">
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept" />
                        </dxe:ASPxTextBox>
                    </div>
                </div>
                <div class="par">
                    <label>
                        Procedimiento a Ejecutar</label>
                    <div class="field">
                        <dxe:ASPxTextBox runat="server" ID="txtExecProcedure" MaxLength="50" />
                    </div>
                </div>
                <div class="par stdformbutton">
                    
                    <span id="lp" style="display: none;"><small>Procesando&hellip;  </small><img src="/Styles/Images/loader2.gif" alt="loading"  style="vertical-align:middle" /></span>
                    <button id="btnAccept" class="stdbtn btn_yellow" onclick="return OnClick();">Aceptar</button>
                    <input type="reset" class="reset radius2" value="Cancelar" onclick="location.href='Jobs.aspx';" />
                </div>
                <asp:HiddenField runat="server" ID="hdnJobId" />
            </div>
            <!--subcontent-->
        </div>
        <!--contentwrapper-->
        
        </form>
    </div>
</asp:Content>
