<%@ Page Title="" Language="C#" MasterPageFile="Manage.Master" Inherits="System.Web.Mvc.ViewPage<List<Pandemiia.Models.Entity>>" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	�����
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>�����</h2>
    <%
        Html.RenderPartial("DateFilter", ViewData);     
        
    %>
    <br />
    
    <p>
        <%= Html.ActionLink("�������", "CreateEntity") %>
    </p>
    
    
    <table>
        <tr>
            <th></th>
            <th>
                �
            </th>
            <th>
                ���������
            </th>
            <th>
                ����
            </th>
            <th>
                ���
            </th>
            <th>
                ���
            </th>
        </tr>

    <% foreach (Pandemiia.Models.Entity item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("��������", "EditEntity", new { id=item.ID }) %> | 
                <%= Html.ActionLink("�������", "DeleteEntity", new { id = item.ID })%> | 
                <% 
                    switch(item.EntityType.Name)
                    {
                        case "�����":
                            Response.Write(Html.PopUpWindowAction("�����", "Videos", "Manage", item.ID, 400, 500));
                            break;
                        case "������":
                            Response.Write(Html.PopUpWindowAction("������", "Music", "Manage", item.ID, 600, 500));
                            break;
                        case "�����������":
                            Response.Write(Html.PopUpWindowAction("�����������", "Images", "Manage", item.ID, 600, 500));
                            break;
                    }
           
                %>
            </td>
            <td>
                <%= Html.Encode(item.ID) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.Date)) %>
            </td>
            <td>
                <%= Html.Encode(item.EntityType.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.EntitySource.Name) %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

