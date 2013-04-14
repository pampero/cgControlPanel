<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Details.Master"  %>

<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <!-- muestra y oculta div de cuotas -->
    <div id="contenedor">
        <div id="two-box-top">
            <div id="navtrail"></div>
        </div>
        <div id="colum-left">               
            <div class="layout noDispon">
                 <div class="colLeft">
                    <div class="cajaError" >
                        <div class="textCont">
                            <!--<span>La publicación correspondiente al aviso <b><%=ViewData["URLSeo"]%></b>, en el que estabas interesado se encuentra finalizada. Debajo encontrarás algunas ofertas similares.</span>-->
                            <span>El aviso que buscas no se encuentra disponible.<br />Por favor realiza una <a href="http://www.deautos.com/autos" style="font-size:14px;">nueva búsqueda</a></span><br /><br />
                               
                        </div>
                        
                    </div>
                  </div>  
                  
             
             <div class="botCont" style="display:inline-block;margin-left:20px;margin-top:20px; *margin-top:80px; ">    
                <a title="Enviar" href="http://www.deautos.com/autos" class="btnNar" >
                    <span class="L"></span>
                    <span class="M" style="color: white; font-weight: bold;">Nueva Búsqueda</span>
                    <span class="R"></span>
                </a>
             </div>   
                 
                 <div class="noDisponSpace"></div>
                 </div>
                 
            </div>

         </div>


            <div class="boxavisos" style="display:none">
                      
                <div class="sombra"></div>
            </div>
            <!--<div class="banner315x50">
                <%=ViewData["bannerDerecha4"]%>
                </script>
            </div>-->
        </div>
        <div id="colum-right" style="display:none">

            <div class="topform"></div>
            <!--<div class="banner214x120">
                <%=ViewData["bannerDerecha3"]%>
                </script>
            </div>-->
           
            <!-- ocultable -->
            <!--<div class="banner214x120">
                <%=ViewData["bannerDerecha1"]%>
                </script>
            </div>-->
            <!--<div class="banner214x120">
                <%=ViewData["bannerDerecha2"]%>
                </script>
            </div>-->
            <!-- <div class="banner315x50"><img src="img/315x50.gif" /></div>
<div class="banner315x50"><img src="img/315x50.gif" /></div> -->
            <!--<div class="banner-iAvisos-230x300">
                <%=ViewData["bannerDerecha5"]%>
                </script>
            </div>-->
        </div>

        <!--<div class="banner-footer">
            <%=ViewData["bannerBottomHtml"] %>
            </script>
        </div>-->
        
    
    
</asp:Content>
