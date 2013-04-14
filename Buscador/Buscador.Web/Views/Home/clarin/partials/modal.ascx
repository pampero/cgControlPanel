<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<div class="boxMiAuto">
          <h2 class="auto">Mi auto</h2>
          <form method="post" action="">
            <fieldset>
			
				<p>
				  <label for="tipodocumento">Tipo Doc.:</label>
				  <select class="bordeforms" id="tipodocumento" name="tipodocumento"><option value="1">DNI
</option><option value="2">LC
</option><option value="3">LE
</option><option value="7">CI
</option><option value="8">PAS
</option><option value="5">CUIT
</option><option value="6">CUIL
</option></select>
				</p>
				<p>
				  <label for="txtdocumento">Nro. Doc.:</label>
				  <input type="text" id="txtdocumento" name="txtdocumento" class="inputField">			 
				</p>
				<p>
				  <label for="txtpassword">Contraseña:</label>
				  <input type="password" id="txtpassword" name="txtpassword" class="inputField">
				</p>
				<p>
				  <input type="Submit" value="Entrar" class="btnEntrar">
				</p>
			
            </fieldset>
          </form>
          <!--<div class="autosBanner"></div>-->
        </div>