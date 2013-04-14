<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.filters" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.slices" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<% if (Model is Slice)
   { %>
        <a href="<%=((Slice)Model).Url %>">
            <%= Html.Encode(((Slice)Model).Localize().ToProper())%><b> (</b><%=Html.Encode(((Slice)Model).Value)%><b>) </b>
        </a>
        
<% } %>


<% if (Model is DynamicRangeSlice)
   { %>

        <form name='inputRangeForm' method='get' url='<%=((DynamicRangeSlice)Model).Url %>' onsubmit="return OnSubmitRangeForm(this,'<%=((DynamicRangeSlice)Model).CodifiedName %>');">
            <span class='facetText'>Desde <input type='text' id='txtDesde' onkeypress = "return isNumberKey(event)"  /></span>
            <span class='facetText'>Hasta <input type='text' id='txtHasta' onkeypress = "return isNumberKey(event)"  /></span>
            <div>
                <input type='submit' value=''/>
            </div>
        </form>

<% }  %>
