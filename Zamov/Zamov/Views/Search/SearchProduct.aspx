<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Product>>" %>
<%@ Import Namespace="Zamov.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchProduct
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function submitForm() {
        //collectChanges(items, "items");
        $get("addToCart").submit();
    }
</script>
    <h2>Результаты поиска</h2>

    <table class="commonTable">
        <tr>
            <th>
                Название
            </th>
            <th>
                Продавец
            </th>
            <th>
                Единица измерения
            </th>
            <th>
                Цена
            </th>
            <th>
                Количество
            </th>
            <th>
                Заказать
            </th>
        </tr>

    <%
        
        using (Ajax.BeginForm("AddToCart", "Search", new AjaxOptions { HttpMethod = "POST" }, new { id="addToCart" }))
        {

            if (Model != null)
                foreach (var item in Model)
                { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Name)%>
            </td>
            <td>
                <%= Html.Encode(item.Dealer.Name)%>
                <%=Html.Hidden("dealer_"+ item.Id,item.Dealer.Id)%>
            </td>
            <td>
                
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Price))%>
            </td>
            <td>
                
            </td>
            <td>
              <%= Html.CheckBox("order_" + item.Id, false)%>
            </td>
            
        </tr>
    
    <% }
            %>
          
            <%
        } %>
    </table>
<input type="button" value="<%=Html.ResourceString("AddToCart") %>" onclick="submitForm()" />  
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

