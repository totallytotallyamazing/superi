<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Trips.Mvc.Models.CarAd>>" %>
<%@ Import Namespace="Trips.Mvc.Models" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Trips.Mvc.Helpers" %>
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
       {%>
       <div class="carPreviewBox">
           <div class="carPreviewPhoto">
               <%= Html.ActionLink("[IMAGE]", "Details", new {id = item.Id}).Replace("[IMAGE]",
                   Html.Image(GraphicsHelper.GetCachedImage("~/Content/AdImages", item.Images.Where(i=>i.Default).Select(i=>i.ImageSource).FirstOrDefault(), "thumbnail1")))%>
               <h3>
                   <%= Html.ActionLink(item.Model, "Details", new {id = item.Id}) %> (<%= item.Year %>)
               </h3>
               <p>
                    <%= item.Descriptions.Where(d=>d.Language == LocaleHelper.GetCultureName()).Select(d=>d.ShortDescription).FirstOrDefault() %>
               </p>
               <h4>
                <%= Html.ResourceActionLink("AddCar", "AddCar", new {id=item.Id}) %>    
               </h4>
           </div>
       </div>
<%     }%>
</div>
<div class="clearBoth"></div>
    <%-- Pager --%>           
     <div class="line">
     <p><a href="#">1</a>..<a href="#">2</a>..<a href="#">3</a>  </p></div>
    <%-- /Pager --%>           
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources:WebResources, OurCatalogue %>"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="leftSide">
    <% Html.RenderPartial("AdsNavigator", ViewData["brandClasses"]); %>
</asp:Content>