<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<Buscador.Domain.com.clarin.entities.RankingResult>>" %>
<article class="ranking clearfix">
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                    	<section class="A">
                        	<strong>Ranking</strong> deautos.com
                        </section>
                        
                        <section  class="B">
                        	<ul>
                            	<% for (var pos = 0; pos < Model.Count; pos++) 
                                { %>
                                <li class="ranking<%=pos + 1 %> pngfix"><a href="<%=Model[pos].Url%>" title="<%=Model[pos].Make + ' ' + Model[pos].Model%>"><%= Model[pos].Make + ' ' + Model[pos].Model%></a></li>                                
                                <% } %>
                            </ul>
                        </section>
                                                
                        <section class="C">
                        	<section class="A">
                            Últimos
                        	<strong>Lanzamientos</strong>
                        </section>
                        
                        <section  class="B">
                        	<ul>
                            	<li class="one pngfix"><a href="#" title="#nombre del auto">Chevrolet Cruze</a></li>
                                <li class="two pngfix"><a href="#" title="#nombre del auto">Fiat Uno</a></li>
                                <li class="tree pngfix"><a href="#" title="#nombre del auto">Renault Fluence</a></li>
                                <li class="four pngfix"><a href="#" title="#nombre del auto">Audi A3</a></li>
                                <li class="five pngfix"><a href="#" title="#nombre del auto">Renault Megane III</a></li>
                                <li class="six pngfix"><a href="#" title="#nombre del auto">BMW 120d</a></li>
                            </ul>
                        </section>
                        </section>
                    	
                    </article>
