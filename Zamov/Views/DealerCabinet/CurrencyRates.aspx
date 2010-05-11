<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.DealerCurrencyRates>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Курсы валют</h2>
<% using (Html.BeginForm("UpdateCurrencyRates", "DealerCabinet"))
   { %>
    <table class="adminTable" style="border:1px dotted #ccc" >
        <tr>
            <th style="display:none">
                Id
            </th>
            <th>
                Валюта
            </th>
            <th>
                Курс
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td style="display:none">
                <%= Html.TextBox("currency_" + item.CurrencyId, item.CurrencyId)%>
            </td>
            <td>
                <%= Html.Encode(item.Currencies.Name)%>
            </td>
            <td>
                <%=Html.TextBox("rate_" + item.CurrencyId, String.Format("{0:F}", item.Rate))%>
            </td>
        </tr>
    
    <% } %>

    </table>
 <input type="submit" value="<%= Html.ResourceString("Save") %>" />
    <%} %>

<% using (Html.BeginForm("InsertCurrencyRate", "DealerCabinet"))
   { %>
    <table class="adminTable">
        <tr>
            <th>
                Валюта    
            </th>
            <th>
                Курс
            </th>
        </tr>
        <tr>
            <td>
                <%= Html.DropDownList("currencysList", (List<SelectListItem>)ViewData["currencies"])%> 
            </td>
            <td>
                <%= Html.TextBox("rate") %>
            </td>
        </tr>
    </table>
    <input type="submit" value="<%= Html.ResourceString("Add") %>" />
    <%} %>

     

</asp:Content>
