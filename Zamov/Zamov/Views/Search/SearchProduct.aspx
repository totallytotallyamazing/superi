<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SearchProduct
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>���������� ������</h2>

    <table class="commonTable">
        <tr>
            <th>
                ��������
            </th>
            <th>
                ��������
            </th>
            <th>
                ������� ���������
            </th>
            <th>
                ����
            </th>
            <th>
                ����������
            </th>
            <th>
                ��������
            </th>
        </tr>

    <%
        if(Model!=null)
        foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Dealer.Name) %>
            </td>
            <td>
                
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:F}", item.Price)) %>
            </td>
            <td>
                
            </td>
            <td>
              
            </td>
            
        </tr>
    
    <% } %>
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
</asp:Content>

