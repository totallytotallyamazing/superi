<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.CarAd>>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if(Request.IsAuthenticated){ %>  
        <table>
            <tr>
                <td>
                    <%= Html.ActionLink("Марки машин", "Brands", "Admin") %>
                </td>
                <td>
                    <%= Html.ActionLink("Добавить машину", "AddEditCarAd", "Admin") %>
                </td>
            </tr>
        </table>
    <%} %>
   <div id="catalog">
    
     <% foreach (var item in Model)
       {
           
       }
         %>
    
    
               <div class="carPreviewBox">
               <div class="carPreviewPhoto">
               <img src="img/car1.jpg" alt="car1">
               <h3><a href="#">“Lacetti”</a> (2006)</h3>
               <p>5 мест;</p>
			   <p>Кондиционер;</p>
               <h4><a href="#">Добавить в заявку</a></h4>
               </div></div>
               
               <div class="carPreviewBox">
               <div class="carPreviewPhoto">
               <img src="img/car2.jpg" alt="car1">
               <h3><a href="#">“Spark”</a> (2007)</h3>
               <p>5 мест;</p>
			   <p>Кондиционер;</p>
               <h4><a href="#">Добавить в заявку</a></h4>
               </div></div>
               
               <div class="carPreviewBox">
               <div class="carPreviewPhoto">
               <img src="img/car3.jpg" alt="car1">
               <h3><a href="#">“Impala”</a> (1959)</h3>
               <p>5 мест;</p>
			   <p>Кондиционер;</p>
               <h4><a href="#">Добавить в заявку</a></h4>
               </div></div>
               
               <div class="carPreviewBox">
               <div class="carPreviewPhoto">
               <img src="img/car4.jpg" alt="car1">
               <h3><a href="#">“Rezzo”</a> (2008)</h3>
               <p>5 мест;</p>
			   <p>Кондиционер;</p>
               <h4><a href="#">Добавить в заявку</a></h4>
               </div></div>
               
               <div class="carPreviewBox">
               <div class="carPreviewPhoto">
               <img src="img/car5.jpg" alt="car1">
               <h3><a href="#">“Avio”</a> (2008)</h3>
               <p>5 мест;</p>
			   <p>Кондиционер;</p>
               <h4><a href="#">Добавить в заявку</a></h4>
               </div></div>
               
               <div class="carPreviewBox">
               <div class="carPreviewPhoto">
               <img src="img/car6.jpg" alt="car1">
               <h3><a href="#">“Tacuma”</a> (2005)</h3>
               <p>5 мест;</p>
			   <p>Кондиционер;</p>
               <h4><a href="#">Добавить в заявку</a></h4>
               </div></div></div>
               <div class="clearBoth"></div>
               
                         <div class="line">
                         <p><a href="#">1</a>..<a href="#">2</a>..<a href="#">3</a>  </p></div>
                        </div></div></div>
                       
                		
						</div>
                        <div id="leftImageBox2">
                        <div id="greyCar"></div>
                        </div>

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources.WebResources, OurCatalogue %>"
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="leftSide">
    <% Html.RenderPartial("AdsNavigator", ViewData["brandClasses"]); %>
</asp:Content>